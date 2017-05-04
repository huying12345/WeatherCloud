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

namespace Yamon.FileMonitor.PlugIn_SMB
{
    public class CopyQpWeatherForecast : IPlugIn
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
                string url = "http://qp.yamon.cn/Service/QPServices.aspx?action=WISHService_GetQP7Days";
                HttpHelper httpHelper = new HttpHelper();
                string result = httpHelper.Get(url);
                DataTable commentTable = JsonConvert.DeserializeObject<DataTable>(result);
                List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();

                string sql =
                        "INSERT INTO Tbl_Forecast(StationID,CityName,Longitude,Latitude,Altitude,Ftype,Hours,MaxTemp,MinTepm,Weather,Wind,WindSpeed,DataTime,UpdateTime,ForeTime,WeatherNight,Wind2,WindSpeed2)" +
                        "VALUES(@StationID,@CityName,@Longitude,@Latitude,@Altitude,@Ftype,@Hours,@MaxTemp,@MinTepm,@Weather,@Wind,@WindSpeed,@DataTime,@UpdateTime,@ForeTime,@WeatherNight,@Wind2,@WindSpeed2)";
                for (int i = 0; i < commentTable.Rows.Count; i++)
                {
                    DateTime dataTime = DataConverter.ToDate(commentTable.Rows[i]["releasetime"].ToString());
                    if (i == 0)
                    {
                        sqllist.Add((new SqlParametersKeyValue("Delete Tbl_Forecast where StationID='58461' AND Ftype='Local' AND DataTime='" + dataTime.AddHours(17).ToString("yyyy-MM-dd HH:mm") + "'", null)));
                    }
                    Parameters db = new Parameters();
                    db.AddInParameter("@UpdateTime", DbType.DateTime, DateTime.Now);
                    db.AddInParameter("@StationID", DbType.String, "58461");
                    db.AddInParameter("@CityName", DbType.String, "青浦");
                    db.AddInParameter("@Longitude", DbType.String, "121.11");
                    db.AddInParameter("@Latitude", DbType.String, "31.15");
                    db.AddInParameter("@Altitude", DbType.String, "7.6");
                    db.AddInParameter("@Ftype", DbType.String, "Local");
                    db.AddInParameter("@Hours", DbType.String, (i + 1) * 24);
                    db.AddInParameter("@Weather", DbType.String, commentTable.Rows[i]["Weather"].ToString()); //天气
                    db.AddInParameter("@WeatherNight", DbType.String, commentTable.Rows[i]["Weather"].ToString()); //天气
                    db.AddInParameter("@Wind", DbType.String, commentTable.Rows[i]["direction"].ToString()); //风向
                    db.AddInParameter("@WindSpeed", DbType.String, commentTable.Rows[i]["windpower"].ToString()); //风力
                    db.AddInParameter("@Wind2", DbType.String, commentTable.Rows[i]["direction"].ToString()); //风向
                    db.AddInParameter("@WindSpeed2", DbType.String, commentTable.Rows[i]["windpower"].ToString()); //风力
                    db.AddInParameter("@MaxTemp", DbType.String, commentTable.Rows[i]["maxtemp"].ToString()); //最高温度
                    db.AddInParameter("@MinTepm", DbType.String, commentTable.Rows[i]["mintemp"].ToString()); //最低温度
                    db.AddInParameter("@DataTime", DbType.DateTime, dataTime.AddHours(17)); //预报时间
                    db.AddInParameter("@ForeTime", DbType.DateTime, commentTable.Rows[i]["forecastday"].ToString()); //发布时间
                    sqllist.Add(new SqlParametersKeyValue(sql, db));
                }

                DbHelper.GetConn("WeatherData").ExecuteNonQueryTran(sqllist);
            }
            catch (Exception ex)
            {
                FileServiceException.AddLog("CopyQpWeatherForecast Download Error:" + ex.Message);
            }
        }
    }
}
