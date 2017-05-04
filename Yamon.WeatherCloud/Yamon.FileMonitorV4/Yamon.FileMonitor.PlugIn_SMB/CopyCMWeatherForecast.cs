using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Timers;
using Newtonsoft.Json;
using Yamon.FileMonitor.Component;
using Yamon.Framework.Common;
using Yamon.Framework.Common.DataBase;
using Yamon.Framework.DBUtility;
using System.Collections;

namespace Yamon.FileMonitor.PlugIn_SMB
{
    public class CopyCMWeatherForecast : IPlugIn
    {

        Timer _timer;
        public void Run()
        {
            _timer = new Timer();
            _timer.Interval = 1000 * 60;
            _timer.Enabled = true;
            _timer.Elapsed += _timer_Elapsed;
            DownLoad();
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DownLoad();
        }
        public void DownLoad()
        {
            try
            {
                string url = "http://cm.yamon.cn/Service/Interface.aspx?action=CmService_Get5Days";
                HttpHelper httpHelper = new HttpHelper();
                string result = httpHelper.Get(url);
                DataTable dt = JsonConvert.DeserializeObject<DataTable>('['+result+']');
                DataTable commentTable = new DataTable();
                commentTable.Columns.Add("forecastdate");
                commentTable.Columns.Add("datetime");
                commentTable.Columns.Add("weather1");
                commentTable.Columns.Add("weather2");
                commentTable.Columns.Add("mintemp");
                commentTable.Columns.Add("maxtemp");
                commentTable.Columns.Add("winddirection1");
                commentTable.Columns.Add("windlevel1");
                commentTable.Columns.Add("winddirection2");
                commentTable.Columns.Add("windlevel2");
                commentTable.Columns.Add("weather");
                for (int p = 0; p < 5; p++)
                {
                    DataRow dr = commentTable.NewRow();
                    dr["datetime"] = Convert.ToString(dt.Rows[0]["reportdate"]); 
                    if (p==0)
                    {
                        dr["forecastdate"] = DataConverter.ToDate(dt.Rows[0]["reportdate"]).AddDays(1).ToString("yyyy-MM-dd"); 

                    }
                    else
                    {
                        dr["forecastdate"] = DataConverter.ToDate(commentTable.Rows[p - 1]["forecastdate"]).AddDays(1).ToString("yyyy-MM-dd");
                    }


                    dr["weather1"] = Convert.ToString(dt.Rows[0]["weather" + (p + 1) * 24]);
                    dr["weather2"] = Convert.ToString(dt.Rows[0]["weather" + (p + 1) * 24]);
                    string [] temp = Convert.ToString(dt.Rows[0]["temp" + (p+1) * 24]).Replace("℃","").Split('-');
                    if (DataConverter.ToInt(temp[0])>DataConverter.ToInt(temp[1]))
                    {
                        dr["mintemp"] = temp[1];
                        dr["maxtemp"] = temp[0];
                    }
                    else if (DataConverter.ToInt(temp[0]) <= DataConverter.ToInt(temp[1]))
                    {
                        dr["mintemp"] = temp[0];
                        dr["maxtemp"] = temp[1];
                    }
                    string[] wed = Convert.ToString(dt.Rows[0]["wind" + (p + 1) * 24]).Replace("风力","").Split(' ');

                    string[] wind = wed[0].Replace("到", "|").Split('|');
                    if (wind.Length>1)
                    {
                        dr["winddirection1"] = wind[0];
                        dr["winddirection2"] = wind[1];
                    }
                    else
                    {
                        dr["winddirection1"] = wind[0];
                        dr["winddirection2"] = wind[0];
                    }

                    dr["windlevel1"] = wed[1];
                    dr["windlevel2"] = wed[1];
                    dr["weather"] = Convert.ToString(dt.Rows[0]["weather" + (p + 1) * 24]);
                    commentTable.Rows.Add(dr);
                }

                List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();

                string sql =
                    "INSERT INTO Tbl_Forecast(StationID,CityName,Longitude,Latitude,Altitude,Ftype,Hours,MaxTemp,MinTepm,Weather,Wind,WindSpeed,DataTime,UpdateTime,ForeTime,WeatherNight,Wind2,WindSpeed2)" +
                    "VALUES(@StationID,@CityName,@Longitude,@Latitude,@Altitude,@Ftype,@Hours,@MaxTemp,@MinTepm,@Weather,@Wind,@WindSpeed,@DataTime,@UpdateTime,@ForeTime,@WeatherNight,@Wind2,@WindSpeed2)";
                for (int i = 0; i < commentTable.Rows.Count; i++)
                {
                    DateTime dataTime = DataConverter.ToDate(commentTable.Rows[i]["datetime"].ToString())
                    ;
                    if (i == 0)
                    {
                        sqllist.Add(
                            (new SqlParametersKeyValue(
                                "Delete Tbl_Forecast where StationID='58366' AND Ftype='Local' AND DataTime='" +
                                dataTime.AddHours(17).ToString("yyyy-MM-dd HH:mm") + "'", null)));
                    }
                    Parameters db = new Parameters();
                    db.AddInParameter("@UpdateTime", DbType.DateTime, DateTime.Now);
                    db.AddInParameter("@StationID", DbType.String, "58366");
                    db.AddInParameter("@CityName", DbType.String, "崇明");
                    db.AddInParameter("@Longitude", DbType.String, "121.45");
                    db.AddInParameter("@Latitude", DbType.String, "31.61");
                    db.AddInParameter("@Altitude", DbType.String, "8.9");
                    db.AddInParameter("@Ftype", DbType.String, "Local");
                    db.AddInParameter("@Hours", DbType.String, (i + 1) * 24);
                    db.AddInParameter("@Weather", DbType.String, commentTable.Rows[i]["weather"].ToString()); //天气
                    db.AddInParameter("@WeatherNight", DbType.String, commentTable.Rows[i]["weather"].ToString()); //天气
                    db.AddInParameter("@Wind", DbType.String, commentTable.Rows[i]["winddirection1"].ToString()); //风向
                    db.AddInParameter("@WindSpeed", DbType.String, commentTable.Rows[i]["windlevel1"].ToString()); //风力
                    db.AddInParameter("@Wind2", DbType.String, commentTable.Rows[i]["winddirection2"].ToString()); //风向
                    db.AddInParameter("@WindSpeed2", DbType.String, commentTable.Rows[i]["windlevel2"].ToString()); //风力
                    db.AddInParameter("@MaxTemp", DbType.String, commentTable.Rows[i]["maxtemp"].ToString()); //最高温度
                    db.AddInParameter("@MinTepm", DbType.String, commentTable.Rows[i]["mintemp"].ToString()); //最低温度
                    db.AddInParameter("@DataTime", DbType.DateTime, dataTime.AddHours(17)); //预报时间
                    db.AddInParameter("@ForeTime", DbType.DateTime, commentTable.Rows[i]["forecastdate"].ToString());
                    //发布时间
                    sqllist.Add(new SqlParametersKeyValue(sql, db));
                }

                DbHelper.GetConn("WeatherData").ExecuteNonQueryTran(sqllist);
            }
            catch (Exception ex)
            {
                FileServiceException.AddLog("CopyCMWeatherForecast Download Error:" + ex.Message);
            }
        }
    }
}
