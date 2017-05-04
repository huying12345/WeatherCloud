using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Yamon.Framework.Common;
using Yamon.Framework.MVC;
using Yamon.Module.Weather.WebApi.SHAQI;

namespace Yamon.Module.Weather.WebApi
{
    public class SoweatherController : BaseController
    {
        //根据资源编号获取图片数据
        [NoCheckLogin]
        public ActionResult GetSoWeatherData(string dataType)
        {
            HttpHelper httpHelper = new HttpHelper();
            string result = "";
            try
            {
                string soweatherUrl = "http://www.soweather.com/DataService/GetData.aspx?DataType=" + dataType;
                result = httpHelper.Get(soweatherUrl);
                if (dataType == "WeatherForecast")
                {
                    hash["data"] = GetWeatherForecast(result, hash);
                }
                else
                {
                    hash["data"] = JsonConvert.DeserializeObject(result);
                }
                hash["success"] = true;
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
            }

            return Content(JsonConvert.SerializeObject(hash));
        }

        private DataTable GetWeatherForecast(string json, Hashtable hash)
        {
            JObject weather = JsonConvert.DeserializeObject<JObject>(json);
            DataTable dt = new DataTable();
            dt.Columns.Add("Day");
            dt.Columns.Add("Week");
            dt.Columns.Add("ForeTimeText");
            dt.Columns.Add("ForeTime");
            dt.Columns.Add("Weather");
            dt.Columns.Add("Temp");
            dt.Columns.Add("MinTemp");
            dt.Columns.Add("MaxTemp");
            dt.Columns.Add("Wind");
            dt.Columns.Add("WindDirection");
            dt.Columns.Add("WindLevel");
            dt.Columns.Add("TextWeather");
            dt.Columns.Add("Weather1");
            dt.Columns.Add("Weather2");
            dt.Columns.Add("WeatherPY1");
            dt.Columns.Add("WeatherPY2");
            //dt.Columns.Add("DataTime");
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("zh-CN");

            for (int i = 1; i < 6; i++)
            {
                DataRow drs = dt.NewRow();
                drs["Day"] = i;
                drs["ForeTime"] = DataConverter.ToDate(weather["reportdate"]).AddDays(i);
                drs["Week"] = cultureInfo.DateTimeFormat.GetAbbreviatedDayName(DataConverter.ToDate(weather["reportdate"]).AddDays(i).DayOfWeek);
                drs["ForeTimeText"] = DataConverter.ToDate(weather["reportdate"]).AddDays(i).ToString("MM/dd");
                drs["Weather"] = weather["weather" + 24 * i + ""];

                string[] arrWeather =
                    drs["Weather"].ToString()
                        .Replace("转", "|")
                        .Replace("到", "|")
                        .Replace("有时有", "|")
                        .Replace("有", "|")
                        .Replace("有时有", "|")
                        .Replace("或", "|")
                        .Replace("局部", "|").Split('|');
                if (arrWeather.Length > 1)
                {
                    drs["Weather1"] = arrWeather[0];
                    drs["Weather2"] = arrWeather[1];
                }
                else
                {
                    drs["Weather1"] = arrWeather[0];
                    drs["Weather2"] = arrWeather[0];
                }
                drs["WeatherPY1"] = PinyinHelper.GetPinyin(drs["Weather1"].ToString());
                drs["WeatherPY2"] = PinyinHelper.GetPinyin(drs["Weather1"].ToString());
                string str = Convert.ToString(weather["temp" + 24 * i + ""]).Replace("℃-", "℃~");
                string[] strs = str.Split('~');
                string temp1 = strs[0].Replace("℃", "");
                string temp2 = strs[1].Replace("℃", "");
                if (temp1.StartsWith("0") && temp1 != "0")
                {
                    temp1 = temp1.Substring(1);
                }
                if (temp2.StartsWith("0") && temp2 != "0")
                {
                    temp2 = temp2.Substring(1);
                }
                if (DataConverter.ToFloat(temp1) > DataConverter.ToFloat(temp2))
                {
                    drs["MinTemp"] = temp2;
                    drs["MaxTemp"] = temp1;
                    drs["Temp"] = temp2 + "℃～" + temp1 + "℃";
                }
                else
                {
                    drs["MinTemp"] = temp1;
                    drs["MaxTemp"] = temp2;
                    drs["Temp"] = temp1 + "℃～" + temp2 + "℃";
                }

                //drs["Temp"] = weather["Temp" + 24 * i + ""];
                drs["Wind"] = weather["wind" + 24 * i + ""].ToString().Replace(" 级", "级");
                string[] arrWind = drs["wind"].ToString().Split(' ');
                if (arrWind.Length == 2)
                {
                    drs["WindDirection"] = arrWind[0];
                    drs["WindLevel"] = arrWind[1];
                }
                if (Convert.ToString(weather["textweather" + 24 * i + ""]) != "")
                {
                    drs["TextWeather"] = weather["textweather" + 24 * i + ""];
                }
                else
                {
                    drs["TextWeather"] = weather["weather" + 24 * i + ""];
                }

                // drs["DataTime"] = weather["reportdate"];
                dt.Rows.Add(drs);
            }
            hash["DataTime"] = DataConverter.ToDate(weather["reportdate"]).AddHours(17);
            return dt;
        }

        /// <summary>
        /// 整点天气预报
        /// </summary>
        /// <returns></returns>
        [NoCheckLogin]
        public ActionResult GetHourWeatherForecast()
        {
            HttpHelper httpHelper = new HttpHelper();
            httpHelper.SetEncoding(Encoding.Default);
            string url = "http://www.soweather.com/data/shdljxhtqyb.txt";
            string content = httpHelper.Get(url);
            content = content.Replace("|", ",");
            content = "HourRange,Weather,Cloud,CloudRate,CloudHeight,Temp,RelativeHumidity,WindDirection,WindSpeed,Rain,BodyTemp,UV,Heatstroke,Visible\r\n" + content;
            DataTable table = DataTableHelper.CSVToDataTable(content, true);
            table.Columns.Add("Hour");
            table.Columns.Add("Weather1");
            table.Columns.Add("Weather2");
            table.Columns.Add("WeatherPY1");
            table.Columns.Add("WeatherPY2");
            table.Columns.Add("WindLevel");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string[] arrWeather =
                    table.Rows[i]["Weather"].ToString()
                        .Replace("转", "|")
                        .Replace("到", "|")
                        .Replace("有时有", "|")
                        .Replace("有", "|")
                        .Replace("有时有", "|")
                        .Replace("或", "|")
                        .Replace("局部", "|").Split('|');
                if (arrWeather.Length > 1)
                {
                    table.Rows[i]["Weather1"] = arrWeather[0];
                    table.Rows[i]["Weather2"] = arrWeather[1];
                }
                else
                {
                    table.Rows[i]["Weather1"] = arrWeather[0];
                    table.Rows[i]["Weather2"] = arrWeather[0];
                }
                table.Rows[i]["WeatherPY1"] = PinyinHelper.GetPinyin(table.Rows[i]["Weather1"].ToString());
                table.Rows[i]["WeatherPY2"] = PinyinHelper.GetPinyin(table.Rows[i]["Weather1"].ToString());
                table.Rows[i]["Hour"] = table.Rows[i]["HourRange"].ToString().Split('-')[0];
                table.Rows[i]["WindLevel"] = GetWindLevelString(table.Rows[i]["WindSpeed"].ToString());
            }
            hash["data"] = table;
            hash["success"] = true;
            return Content(JsonConvert.SerializeObject(hash));
        }
        [NoCheckLogin]
        public ActionResult GetSHAQI()
        {
            SHAQI.MySoapHeader header = new MySoapHeader();
            header.UserName = "8564879f-3d1a-4c4f-9219-47f1fa5a6790";
            header.PassWord = "a1ea259d-068c-4aab-a795-0191f3b5e6f3";

            SHAQI.WebServiceSoapClient client = new WebServiceSoapClient();
            string content = client.GetSiteAQIData(header, "0");
            string[] arrContent = content.Split('#');
            Hashtable nv = new Hashtable();
            for (int i = 0; i < arrContent.Length; i++)
            {
                string[] arrLine = arrContent[i].Split('$');
                if (arrLine.Length == 2)
                {
                    nv[arrLine[0].Replace("O3-1小时", "O3").Replace("PM2.5", "PM25")] = arrLine[1];
                }
                else if (arrLine.Length == 6)
                {
                    nv["DataTime"] = arrLine[5];
                    nv["Grade"] = arrLine[3];
                    nv["GradeText"] = arrLine[4];
                    nv["SiteID"] = arrLine[0];
                    string[] arrAQI = arrLine[2].Split('*');
                    if (arrAQI.Length == 3)
                    {
                        nv["AQI"] = arrAQI[0];
                        nv["PM25"] = arrAQI[1];
                    }
                }
            }
            hash["data"] = nv;
            // hash["content"] = content;
            hash["success"] = true;
            return Content(JsonConvert.SerializeObject(hash));
        }
        /// <summary>
        /// 自动站风速
        /// </summary>
        /// <param name="direction">风级别</param>
        /// <returns></returns>
        public string GetWindLevelString(string Level)
        {
            
            double wind = 0;
            if (!double.TryParse(Level, out wind))
            {
                return "-";
            }

            if (wind == 0.0) { return "无风"; }
            if (wind == 0) { return "无风"; }
            if (0.0 < wind && wind <= 0.2) { return "0级"; }
            if (0.3 <= wind && wind <= 1.5) { return "1级"; }
            if (1.6 <= wind && wind <= 3.3) { return "2级"; }
            if (3.4 <= wind && wind <= 5.4) { return "3级"; }
            if (5.5 <= wind && wind <= 7.9) { return "4级"; }
            if (8.0 <= wind && wind <= 10.7) { return "5级"; }
            if (10.8 <= wind && wind <= 13.8) { return "6级"; }
            if (13.9 <= wind && wind <= 17.1) { return "7级"; }
            if (17.2 <= wind && wind <= 20.7) { return "8级"; }
            if (20.8 <= wind && wind <= 24.4) { return "9级"; }
            if (24.5 <= wind && wind <= 28.4) { return "10级"; }
            if (28.5 <= wind && wind <= 32.6) { return "11级"; }
            if (32.7 <= wind && wind <= 36.9) { return "12级"; }
            if (37.0 <= wind && wind <= 41.4) { return "13级"; }
            if (41.5 <= wind && wind <= 46.1) { return "14级"; }
            if (46.2 <= wind && wind <= 50.9) { return "15级"; }
            if (51.0 <= wind && wind <= 56.0) { return "16级"; }
            if (56.1 <= wind && wind <= 61.2) { return "17级"; }
            return "暂无数据";
        }
    }
}
