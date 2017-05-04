using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yamon.FileMonitor.Component;
using Yamon.Framework.DBUtility;
using System.Data;
using Yamon.Framework.Common.DataBase;
using System.Timers;

namespace Yamon.FileMonitor.PlugIn_SMB
{
    public class Copy5Days : IPlugIn
    {
        Timer _timer;
        public void Run()
        {
            _timer = new Timer();
            _timer.Interval = 1000 * 60 * 10;
            _timer.Enabled = true;
            _timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            Copy();
            CopyTodayWeather();
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Copy();
            CopyTodayWeather();
        }

        public void Copy()
        {
            try
            {
                string sql1 = "select top 1 * from Tbl_Weather where SerialNumber='58362' order by ID desc";
                DataRow row = DbHelper.GetConn("SoWeatherData").ExecuteDataRowSql(sql1);

                StringBuilder sb = new StringBuilder();
                sb.Append("Update Tbl_Weather Set ReportDate=@ReportDate,");
                sb.Append("Weather24=@Weather24,Weather48=@Weather48,Weather72=@Weather72,Weather96=@Weather96,Weather120=@Weather120,");
                sb.Append("Temp24=@Temp24,Temp48=@Temp48,Temp72=@Temp72,Temp96=@Temp96,Temp120=@Temp120,");
                sb.Append("Wind24=@Wind24,Wind48=@Wind48,Wind72=@Wind72,Wind96=@Wind96,Wind120=@Wind120,");
                sb.Append("TextWeather24=@TextWeather24,TextWeather48=@TextWeather48,TextWeather72=@TextWeather72,TextWeather96=@TextWeather96,TextWeather120=@TextWeather120 ");
                sb.Append("Where SerialNumber=58362");

                Parameters p = new Parameters();
                p.AddInParameter("@ReportDate", DbType.DateTime, row["ReportDate"]);
                p.AddInParameter("@Weather24", DbType.AnsiString, row["Weather24"]);
                p.AddInParameter("@Weather48", DbType.AnsiString, row["Weather48"]);
                p.AddInParameter("@Weather72", DbType.AnsiString, row["Weather72"]);
                p.AddInParameter("@Weather96", DbType.AnsiString, row["Weather96"]);
                p.AddInParameter("@Weather120", DbType.AnsiString, row["Weather120"]);
                p.AddInParameter("@Temp24", DbType.AnsiString, row["Temp24"]);
                p.AddInParameter("@Temp48", DbType.AnsiString, row["Temp48"]);
                p.AddInParameter("@Temp72", DbType.AnsiString, row["Temp72"]);
                p.AddInParameter("@Temp96", DbType.AnsiString, row["Temp96"]);
                p.AddInParameter("@Temp120", DbType.AnsiString, row["Temp120"]);
                p.AddInParameter("@Wind24", DbType.AnsiString, row["Wind24"]);
                p.AddInParameter("@Wind48", DbType.AnsiString, row["Wind48"]);
                p.AddInParameter("@Wind72", DbType.AnsiString, row["Wind72"]);
                p.AddInParameter("@Wind96", DbType.AnsiString, row["Wind96"]);
                p.AddInParameter("@Wind120", DbType.AnsiString, row["Wind120"]);
                p.AddInParameter("@TextWeather24", DbType.AnsiString, row["TextWeather24"]);
                p.AddInParameter("@TextWeather48", DbType.AnsiString, row["TextWeather48"]);
                p.AddInParameter("@TextWeather72", DbType.AnsiString, row["TextWeather72"]);
                p.AddInParameter("@TextWeather96", DbType.AnsiString, row["TextWeather96"]);
                p.AddInParameter("@TextWeather120", DbType.AnsiString, row["TextWeather120"]);
                DbHelper.GetConn("WeatherData").ExecuteNonQuerySql(sb.ToString(), p);
                //Common.RunHttpTask("http://192.168.160.122:88/Default.aspx?m=InfoIndex&CategoryID=3481eeea-4d00-4dde-ae8f-65b028d7cb8c&createhtml=1");
            }
            catch (Exception ex)
            {
                FileServiceException.HandleFileServiceException(ex);
            }
        }


        public void CopyTodayWeather()
        {
            try
            {
                DbHelper.GetConn("WeatherData").ExecuteNonQuerySql("Delete From WeatherInfo");
                Convert("WeatherInfo", "SoWeatherData", "WeatherData", "");
                //Common.RunHttpTask("http://192.168.160.122:88/Default.aspx?m=InfoIndex&CategoryID=3481eeea-4d00-4dde-ae8f-65b028d7cb8c&createhtml=1");
            }
            catch (Exception ex)
            {
                FileServiceException.HandleFileServiceException(ex);
            }
        }


        public void Convert(string table, string srcConn, string desConn, string strSql, string field = "*")
        {
            try
            {
                string item = table;

                List<ColumnInfo> columnList = DbHelper.GetConn(desConn).GetColumnInfoList(item.ToString());
                using (NullableDataReader reader = DbHelper.GetConn(srcConn).ExecuteReaderSql(string.Format("Select {2} from {0} {1}", item.ToString(), strSql, field)))
                {
                    int j = 0;
                    while (reader.Read())
                    {
                        string sql = CreateInsertIntoSql(columnList, table);
                        Parameters p = CreateParameters(desConn, columnList, reader);
                        DbHelper.GetConn(desConn).ExecuteNonQuerySql(sql, p);
                        j++;
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                //LogHelper.Error("同步松江数据库失败" + table, ex);
            }
        }

        public Parameters CreateParameters(string conn, List<ColumnInfo> columnList, NullableDataReader reader)
        {
            Dictionary<string, DbType> dbType = DbHelper.GetConn(conn).GetDicDbType();
            Parameters p = new Parameters();
            foreach (ColumnInfo col in columnList)
            {
                p.AddInParameter("P_" + col.ColumnName.ToUpper(), dbType[col.TypeName], reader.GetValue(col.ColumnName));
            }
            return p;
        }


        public string CreateInsertIntoSql(List<ColumnInfo> columnList, string tableName)
        {
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            int i = 0;
            foreach (ColumnInfo col in columnList)
            {
                sb1.Append("[" + col.ColumnName.ToUpper() + "]");
                sb2.Append("@P_" + col.ColumnName.ToUpper());
                if (i < columnList.Count - 1)
                {
                    sb1.Append(",");
                    sb2.Append(",");
                }
                i++;
            }
            StringBuilder sb = new StringBuilder("INSERT INTO " + tableName.ToUpper());
            sb.Append(" (");
            sb.Append(sb1.ToString());
            sb.Append(") ");
            sb.Append("Values(");
            sb.Append(sb2.ToString());
            sb.Append(")");
            return sb.ToString();
        }
    }
}
