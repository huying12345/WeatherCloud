using System;
using Yamon.FileMonitor.Component;
using Yamon.Framework.Common;
using Yamon.Framework.DBUtility;
using System.IO;

using Yamon.Framework.Common.IO;

namespace Yamon.FileMonitor.SMB_ZDZ
{
    public class TyphoonList : IFileExec
    {
        #region IFileExec 成员
        private readonly char[] m_columSplitor = new char[] { ',' };
        private readonly char[] m_LineSplitor = new char[] { '\r', '\n' };
        public DateTime dataTime = DateTime.Now;
        public string ExecFile(FileInfo file, out int nodeId)
        {
            nodeId = 0;
            if (file.Exists)
            {
                dataTime = file.LastWriteTime;
                string filename = file.Name.ToLower();
                try
                {
                    if (file.Name.StartsWith("zdz"))
                    {
                        ReadZDZFromFile(file);
                    }
                    else
                    {
                        ReadYLZFromFile(file);
                    }
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


        public void ReadZDZFromFile(FileInfo file)
        {
            string fields = "date,station,sun_rad,aver_rad,max_rad,max_rad_time,uv,aver_uv,max_uv,max_uv_time,instant_vis,ten_aver_vis,two_aver_wd,two_aver_ws,ten_aver_wd,ten_aver_ws,ten_max_wd,ten_max_ws,ten_maxws_time,instant_wd,instant_ws,max_flu_wd,max_flu_ws,max_flu_time,one_rain,temper,max_temper,max_temp_time,min_temper,min_temp_time,rel_humi,min_relhumi,min_relhumi_time,vap_press,dew_point,air_press, max_press,max_press_time,min_press,min_press_time,surf_temp,max_surf_temp,max_sutemp_time,min_surf_temp,min_sutemp_time";
            string content = IOHelper.ReadFile(file.FullName);
            content = content.Replace(":\"", "\"");
            string[] arrLine = content.Split(m_LineSplitor, StringSplitOptions.RemoveEmptyEntries);
            string sql = "";
            string countSql = "";
            for (int i = 0; i < arrLine.Length; i++)
            {
                string[] arrContent = arrLine[i].Replace("\"", "").Replace("(", "").Replace(")", "").Split(m_columSplitor, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    countSql = string.Format("select count(1) from  zdz_instant where date='{0}' and  station={1}", arrContent[0], arrContent[1]);
                    if (DbHelper.GetConn("WeatherData").GetSingleInt(countSql) == 0)
                    {
                        sql = string.Format("Insert Into zdz_instant({0}) Values {1}", fields, arrLine[i].Replace("\"", "'"));
                        DbHelper.GetConn("WeatherData").ExecuteNonQuerySql(sql);
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
        }

        public void ReadYLZFromFile(FileInfo file)
        {
            //string delsql = string.Format("delete from zdz_instant where date<='{0}'", DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd HH:mm:ss"));
            //try
            //{
            //    DbHelper.GetConn("SJZDZ_DES").ExecuteNonQuerySql(delsql);
            //}
            //catch (Exception ex)
            //{
            //    string msg = ex.Message;
            //}
            string content = IOHelper.ReadFile(file.FullName);
            string[] arrLine = content.Split(m_LineSplitor, StringSplitOptions.RemoveEmptyEntries);
            string sql = "";
            string countSql = "";
            for (int i = 0; i < arrLine.Length; i++)
            {
                string[] arrContent = arrLine[i].Split(m_columSplitor, StringSplitOptions.RemoveEmptyEntries);
                if (arrContent.Length == 3)
                {
                    try
                    {
                        countSql = string.Format("select count(1) from  zdz_instant where date='{0}' and  station='{1}'", arrContent[0], arrContent[1]);
                        if (DbHelper.GetConn("WeatherData").GetSingleInt(countSql) == 0)
                        {
                            sql = string.Format("Insert Into zdz_instant(date,station,one_rain) Values ('{0}','{1}',{2})", arrContent);
                            DbHelper.GetConn("WeatherData").ExecuteNonQuerySql(sql);
                        }

                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                    }
                }
            }
        }
        public string GetBackupPath()
        {
            //return ConfigHelper.GetConfigString("TxtHistoryPath");
            string path = ConfigHelper.GetConfigString("TxtHistoryPath");
            string year = dataTime.ToString("yyyy-MM-dd");
            path = path + "\\" + year.Replace("-", "\\");
            return path;
        }

        public string[] GetFileNameRegxp()
        {
            return new string[] { "^\\d{12}.txt", "zdz-\\d{10}.txt" };
        }
        #endregion
    }
}
