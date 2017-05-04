using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yamon.FileMonitor.Component;
using Yamon.Framework.Common;
using Yamon.Framework.DBUtility;
using System.Data;
using System.IO;
using System.Collections;
using Yamon.Framework.Common.DataBase;
using System.Reflection;
using System.Data.SqlClient;
using Yamon.Module.Typhoon.Entity;
using Yamon.Module.Typhoon.DAL;

namespace Yamon.FileMonitor.SMB_Typhoon
{
    public class TyphoonList : IFileExec
    {
        #region IFileExec 成员

        public string ExecFile(FileInfo file,out int nodeId)
        {
            nodeId = 0;
            if (file.Exists)
            {
                string filename = file.Name.ToLower();
                try
                {
                    ImportToDatabase(file);
                    return filename;
                }
                catch (Exception ex)
                {
                    //AddLog("同步气象预警失败" + ex.Message);
                    return "";
                }
            }
            return "";
        }

        public string GetBackupPath()
        {
            //return ConfigHelper.GetConfigString("TxtHistoryPath");
            string path = ConfigHelper.GetConfigString("TxtHistoryPath");
            string year = DateTime.Now.ToString("yyyy-MM-dd");
            path = path + "\\" + year.Replace("-", "\\");
            return path;
        }

        public string[] GetFileNameRegxp()
        {
            return new string[] { "typhoon_\\w{4}_\\d{4}.dat" };
        }
        #endregion


        private readonly char[] m_columSplitor = new char[] { ' ', '\r' };
        private readonly char[] m_LineSplitor = new char[] { '\r', '\n' };

        /// <summary>
        /// 创建数据列
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public DataTable CreateDataColumns(string[] columns)
        {
            DataTable datable = new DataTable();
            foreach (string column in columns)
            {
                datable.Columns.Add(column);
            }
            return datable;
        }
        public DataTable ReadFormFile(string filepath, ref TyphoonInfo typhoon)
        {
            //创建表列名
            DataSet ds = new DataSet();
            string[] columns = new string[] { "PathTime", "Hours", "Longitude", "Latitude", "MaxWindSpeed", "CenterAirPressure", "CenterSevenRadius", "CenterTenRadius", "MoveHeading", "MoveSpeeding" };
            DataTable table = CreateDataColumns(columns);

            try
            {
                //返回台风数据头信息
                List<string> listReTurnResult = new List<string>();

                //读取文件数据到流中
                //StreamReader reader = File.OpenText(filename);
                StreamReader reader = new StreamReader(File.OpenRead(filepath), Encoding.GetEncoding("gb2312"));

                if (reader.EndOfStream)
                {
                    typhoon = null;
                    return null;
                }
                string str = reader.ReadToEnd();
                //获取所有行
                string[] arrLines = str.Split(m_LineSplitor, StringSplitOptions.RemoveEmptyEntries);

                listReTurnResult.AddRange((arrLines[0] + " " + arrLines[1]).Split(this.m_columSplitor, StringSplitOptions.RemoveEmptyEntries));
                listReTurnResult[0] = listReTurnResult[0] + listReTurnResult[1];
                listReTurnResult.RemoveAt(1);

                typhoon.TyphoonID = listReTurnResult[3];
                typhoon.EnName = listReTurnResult[2];
                typhoon.DataInfo = listReTurnResult[1];
                typhoon.ReportCenter = listReTurnResult[4];

                for (int i = 2; i < arrLines.Length; i++)
                {
                    string[] Line = arrLines[i].Trim().Split(m_columSplitor, StringSplitOptions.RemoveEmptyEntries);
                    //去掉空行
                    if (String.IsNullOrEmpty(arrLines[i]) || Line.Length < 13)
                        continue;

                    //添加行数据到表中
                    List<string> list = new List<string>();

                    //添加时间
                    string[] strtimes = arrLines[i].Substring(0, 11).Split(this.m_columSplitor);
                    list.Add(strtimes[0] + "-" + strtimes[1] + "-" + strtimes[2] + " " + strtimes[3] + ":00");

                    for (int j = 4; j < Line.Length; j++)
                    {
                        //排除无效值
                        int value;
                        if (Int32.TryParse(Line[j], out value))
                        {
                            if (value == 9999)
                            {
                                list.Add(string.Empty);
                                continue;
                            }
                        }
                        list.Add(Line[j]);
                    }
                    table.Rows.Add(list.ToArray());
                }

                typhoon.LastReportTime = DataConverter.ToDate(table.Rows[table.Rows.Count - 1]["PathTime"]);
                table.Columns.Add("TyphoonID");
                string id = typhoon.TyphoonID;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i]["TyphoonID"] = typhoon.TyphoonID;
                }

                //id为0908
                if (typhoon.TyphoonID.Length == 4)
                    typhoon.TYear = 2000 + int.Parse(typhoon.TyphoonID.Substring(0, 2));
                //id为908
                else if (id.Length == 3)
                    typhoon.TYear = 2000 + int.Parse(typhoon.TyphoonID.Substring(0, 1));

                //关闭流
                reader.Close();
                return table;
            }
            catch
            {
                //读数据有误
                return null;
            }
        }


        TyphoonInfoDAL typhoonInfoDAL = new TyphoonInfoDAL();
        public void ImportToDatabase(FileInfo file)
        {

            TyphoonInfo typhoon = new TyphoonInfo();
            DataTable dt = this.ReadFormFile(file.FullName, ref typhoon);
            List<TyphoonPath> list = DataTableToTyphoonPathList(dt, typhoon.ReportCenter.ToLower());

            Parameters p = new Parameters();
            p.AddInParameter("@TyphoonID", DbType.AnsiString, typhoon.TyphoonID);
            p.AddInParameter("@ReportCenter", DbType.AnsiString, typhoon.ReportCenter.ToLower());

            List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();

            TyphoonInfo typhoons = typhoonInfoDAL.GetInfoByID(typhoon.TyphoonID);


            if (typhoons == null)
            {
                sqllist.Add(AddTyphoon(typhoon));

            }
            else
            {
                TyphoonInfo typhoonUpdate = new TyphoonInfo();
                typhoonUpdate.TyphoonID = typhoon.TyphoonID;
                typhoonUpdate.LastReportTime = typhoon.LastReportTime;
                typhoonInfoDAL.UpdateByModel(typhoonUpdate);
            }
            sqllist.Add(new SqlParametersKeyValue("Delete Typhoon_Path where TyphoonID=@TyphoonID AND ReportCenter=@ReportCenter", p));
            foreach (TyphoonPath o in list)
            {
                sqllist.Add(AddTyphoonPath(o));
            }
            DbHelper.GetConn("WeatherData").ExecuteNonQueryTran(sqllist);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TyphoonInfo> DataTableToTyphoonList(DataTable dt)
        {
            List<TyphoonInfo> modelList = new List<TyphoonInfo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TyphoonInfo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TyphoonInfo();
                    model.TyphoonID = dt.Rows[n]["TyphoonID"].ToString();
                    model.EnName = dt.Rows[n]["EnName"].ToString();
                    model.CnName = dt.Rows[n]["CnName"].ToString();
                    model.DataInfo = dt.Rows[n]["DataInfo"].ToString();
                    model.ReportCenter = dt.Rows[n]["ReportCenter"].ToString();
                    if (dt.Rows[n]["TYear"].ToString() != "")
                    {
                        model.TYear = int.Parse(dt.Rows[n]["TYear"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TyphoonPath> DataTableToTyphoonPathList(DataTable dt, string reportCenter)
        {
            List<TyphoonPath> modelList = new List<TyphoonPath>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                TyphoonPath model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new TyphoonPath();
                    model.ReportCenter = reportCenter;
                    //model.ID=dt.Rows[n]["ID"].ToString();
                    model.TyphoonID = dt.Rows[n]["TyphoonID"].ToString();
                    if (dt.Rows[n]["PathTime"].ToString() != "")
                    {
                        model.PathTime = DateTime.Parse(dt.Rows[n]["PathTime"].ToString());
                    }
                    if (dt.Rows[n]["Longitude"].ToString() != "")
                    {
                        model.Longitude = DataConverter.ToDouble(dt.Rows[n]["Longitude"].ToString());
                    }
                    if (dt.Rows[n]["Latitude"].ToString() != "")
                    {
                        model.Latitude = DataConverter.ToDouble(dt.Rows[n]["Latitude"].ToString());
                    }
                    if (dt.Rows[n]["Hours"].ToString() != "")
                    {
                        model.Hours = int.Parse(dt.Rows[n]["Hours"].ToString());
                    }
                    if (dt.Rows[n]["CenterAirPressure"].ToString() != "")
                    {
                        model.CenterAirPressure = DataConverter.ToDouble(dt.Rows[n]["CenterAirPressure"].ToString());
                    }
                    if (dt.Rows[n]["MaxWindSpeed"].ToString() != "")
                    {
                        model.MaxWindSpeed = DataConverter.ToDouble(dt.Rows[n]["MaxWindSpeed"].ToString());
                    }
                    if (dt.Rows[n]["MoveHeading"].ToString() != "")
                    {
                        model.MoveHeading = int.Parse(dt.Rows[n]["MoveHeading"].ToString());
                    }
                    if (dt.Rows[n]["MoveSpeeding"].ToString() != "")
                    {
                        model.MoveSpeeding = DataConverter.ToDouble(dt.Rows[n]["MoveSpeeding"].ToString());
                    }
                    if (dt.Rows[n]["CenterSevenRadius"].ToString() != "")
                    {
                        model.CenterSevenRadius = DataConverter.ToDouble(dt.Rows[n]["CenterSevenRadius"].ToString());
                    }
                    if (dt.Rows[n]["CenterTenRadius"].ToString() != "")
                    {
                        model.CenterTenRadius = DataConverter.ToDouble(dt.Rows[n]["CenterTenRadius"].ToString());
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public SqlParametersKeyValue AddTyphoon(TyphoonInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Typhoon_Info(");
            strSql.Append("TyphoonID,EnName,CnName,DataInfo,ReportCenter,TYear)");
            strSql.Append(" values (");
            strSql.Append("@TyphoonID,@EnName,@CnName,@DataInfo,@ReportCenter,@TYear)");

            string enName=model.EnName.Replace("(" + model.TyphoonID + ")", "");
            string cnName = GetTyphoonName(enName);

            Parameters p = new Parameters();
            p.AddInParameter("@TyphoonID", DbType.AnsiString, model.TyphoonID);
            p.AddInParameter("@EnName", DbType.AnsiString, enName);
            p.AddInParameter("@CnName", DbType.AnsiString, cnName);
            p.AddInParameter("@DataInfo", DbType.AnsiString, model.DataInfo);
            p.AddInParameter("@ReportCenter", DbType.AnsiString, model.ReportCenter);
            p.AddInParameter("@TYear", DbType.Int32, model.TYear);
            return new SqlParametersKeyValue(strSql.ToString(), p);
        }

        // <summary>
        /// 增加一条数据
        /// </summary>
        public SqlParametersKeyValue AddTyphoonPath(TyphoonPath model)
        {
            string strSql = "";
            Parameters parameters = BuildInsertSql(model, "Typhoon_Path", "ID", out strSql);
            return new SqlParametersKeyValue(strSql, parameters);
        }

        public Parameters BuildInsertSql(object obj, string tableName, string keyname, out string sql)
        {
            Parameters parameters = new Parameters();
            StringBuilder strSql1 = new StringBuilder("Insert Into " + tableName + "(");
            StringBuilder strSql2 = new StringBuilder(") values(");
            foreach (PropertyInfo proInfo in obj.GetType().GetProperties())
            {

                if ((proInfo.Name != keyname) && (proInfo.GetValue(obj, null) != null))
                {
                    strSql1.Append(proInfo.Name + ",");
                    strSql2.Append("@" + proInfo.Name + ",");
                    parameters.AddInParameter("@" + proInfo.Name, (DbType)Enum.Parse(typeof(DbType), GetNullEnableType(proInfo.PropertyType.FullName.ToString())), proInfo.GetValue(obj, null).ToString());
                }
            }
            string sql1 = strSql1.ToString();
            if (sql1.EndsWith(","))
            {
                sql1 = sql1.Remove(sql1.Length - 1);
            }
            string sql2 = strSql2.ToString();
            if (sql2.EndsWith(","))
            {
                sql2 = sql2.Remove(sql2.Length - 1);
            }
            sql = sql1 + sql2 + ")";
            return parameters;
        }

        public string GetNullEnableType(string typeName)
        {
            if (typeName.StartsWith("System.Nullable`1[[System."))
            {
                typeName = typeName.Substring("System.Nullable`1[[System.".Length, typeName.IndexOf(",") - "System.Nullable`1[[System.".Length);
            }
            if (typeName.StartsWith("System."))
            {
                typeName = typeName.Substring(7);
            }
            return typeName;
        }

        public string  GetTyphoonName(string name_en)
        {
            string name_cn = name_en;
            TyphoonNameDAL tNameDal = new TyphoonNameDAL();
            TyphoonName typhoonName = tNameDal.GetEntityModel("name_en=?", new object[] { name_en });
            if (typhoonName != null && !string.IsNullOrEmpty(typhoonName.name_cn))
            {
                name_cn = typhoonName.name_cn;
            }
            return name_cn;
        }

       
    }
}
