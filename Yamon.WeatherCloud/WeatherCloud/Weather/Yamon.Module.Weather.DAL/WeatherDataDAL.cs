using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yamon.Framework.Common;
using Yamon.Framework.DBUtility;

namespace Yamon.Module.Weather.DAL
{
    public class WeatherDataDAL
    {

        /// <summary>
        /// App空气质量预报
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        public DataRow GetAQI(string siteId)
        {
            string sql = "select top 1  SiteID,AQI,Grade,Quality,[First],DataTime from Tbl_AQI where SiteID='0' order by DataTime desc";
            DataRow row = DbHelper.GetConn("WeatherData").ExecuteDataRowSql(sql);
            return row;
        }

        //读取十天预报数据
        public DataTable TenDayForecastList()
        {
            string strDataTime = DbHelper.GetConn("WeatherData").GetSingleString("select top 1 CreateDate from t_ZQBaseData order by CreateDate desc");
            DateTime dataTime = DataConverter.ToDate(strDataTime);
            string sql = "";
            if (dataTime.Date == DateTime.Now.Date && DateTime.Now.Hour >= dataTime.Hour)
            {

                sql = "select top 10 * from t_ZQBaseData where CreateDate=(select top 1 CreateDate from t_ZQBaseData order by CreateDate desc)  order by CreateDate asc";
            }
            else if (dataTime.Date < DateTime.Now.Date)
            {
                int data = Math.Abs(((TimeSpan)(DateTime.Now - dataTime.Date)).Days);
                int number = 10 - data;
                if (number < 0)
                {
                    number = 0;
                }
                sql = "select top " + number + " * from t_ZQBaseData where CreateDate=(select top 1 CreateDate from t_ZQBaseData order by CreateDate desc) and PublishDate>='" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "'  order by CreateDate desc";
            }
            if (dataTime.Date >= DateTime.Now.Date && DateTime.Now.Hour < dataTime.Hour)
            {
                //sql = "select top 10 * from t_ZQBaseData where CreateDate<'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+ "'  order by CreateDate desc";
                sql = "select top 10 * from t_ZQBaseData where CreateDate in(select top 1 createdate from t_ZQBaseData where CreateDate<'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' order by CreateDate desc) and PublishDate>='" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "'   order by CreateDate desc";
            }

            DataTable dt = DbHelper.GetConn("WeatherData").ExecuteDataTableSqlEx(sql);
            dt.Columns.Add("weak", typeof(string));
            dt.Columns.Add("WeatherA", typeof(string));
            dt.Columns.Add("WeatherB", typeof(string));

            dt.Columns.Add("WeatherA_PY", typeof(string));
            dt.Columns.Add("WeatherB_PY", typeof(string));

            for (int k = 0; k < 10; k++)
            {
                if (dt.Rows.Count > 0)
                {
                    if (k < dt.Rows.Count)
                    {
                        DateTime time = Convert.ToDateTime(DataConverter.ToDate(dt.Rows[k]["PublishDate"]).ToString("yyyy-MM-dd"));
                        System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("zh-CN");
                        string format = cultureInfo.DateTimeFormat.GetAbbreviatedDayName(time.DayOfWeek).ToString();
                        dt.Rows[k]["weak"] = format.Replace("周", "星期");
                        dt.Rows[k]["DayWeather"] = FromatWeatherPicture3(dt.Rows[k]["DayWeather"].ToString());
                        dt.Rows[k]["NightWeather"] = FromatWeatherPicture3(dt.Rows[k]["NightWeather"].ToString());

                        string[] DayArray = dt.Rows[k]["DayWeather"].ToString().Replace("||", "|").Split('|');
                        for (int l = 0; l < DayArray.Length; l++)
                        {
                            if (DayArray.Length > 1)
                            {
                                dt.Rows[k]["WeatherA"] = DayArray[0];
                                dt.Rows[k]["WeatherB"] = DayArray[DayArray.Length - 2];
                                dt.Rows[k]["WeatherA_PY"] = getPinyinHelper(DayArray[0]) ;
                                dt.Rows[k]["WeatherB_PY"] = getPinyinHelper(DayArray[DayArray.Length - 2]) ;
                            }
                            else if (DayArray.Length > 0)
                            {
                                dt.Rows[k]["WeatherA"] = DayArray[0];
                                dt.Rows[k]["WeatherB"] = DayArray[0];
                                dt.Rows[k]["WeatherA_PY"] = getPinyinHelper(DayArray[0]);
                                dt.Rows[k]["WeatherB_PY"] = getPinyinHelper(DayArray[0]);
                            }
                            else
                            {
                                dt.Rows[k]["WeatherA"] = "";
                                dt.Rows[k]["WeatherB"] = "";
                                dt.Rows[k]["WeatherA_PY"] = "";
                                dt.Rows[k]["WeatherB_PY"] = "";
                            }
                        }
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        DateTime time = Convert.ToDateTime(DataConverter.ToDate(dt.Rows[k - 1]["PublishDate"]).AddDays(1).ToString("yyyy-MM-dd"));
                        System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("zh-CN");
                        string format = cultureInfo.DateTimeFormat.GetAbbreviatedDayName(time.DayOfWeek).ToString();

                        dr["Id"] = 0;
                        dr["NightWeather"] = "-";
                        dr["CreateDate"] = DateTime.Now;
                        dr["PublishDate"] = DataConverter.ToDate(dt.Rows[k - 1]["PublishDate"]).AddDays(1).ToString("yyyy-MM-dd 00:00:00");
                        dr["weak"] = format.Replace("周", "星期");
                        dr["DayWeather"] = "-";
                        dr["WeatherA"] = "-";
                        dr["WeatherB"] = "-";
                        dr["WeatherA_PY"] = "";
                        dr["WeatherB_PY"] = "";
                        dr["TMin"] = -99999;
                        dr["TMax"] = -99999;
                        dr["WindDir"] = "-";
                        dr["WindForce"] = "-";
                        dt.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    DateTime time = new DateTime();
                    if (k == 0)
                    {
                        time = DataConverter.ToDate(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        time = Convert.ToDateTime(DataConverter.ToDate(dt.Rows[k]["PublishDate"]).AddDays(1).ToString("yyyy-MM-dd"));
                    }

                    System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("zh-CN");
                    string format = cultureInfo.DateTimeFormat.GetAbbreviatedDayName(time.DayOfWeek).ToString();

                    dr["Id"] = 0;
                    dr["NightWeather"] = "-";
                    dr["CreateDate"] = DateTime.Now;
                    dr["PublishDate"] = DataConverter.ToDate(time.ToString("yyyy-MM-dd 00:00:00"));
                    dr["weak"] = format.Replace("周", "星期");
                    dr["DayWeather"] = "-";
                    dr["WeatherA"] = "-";
                    dr["WeatherB"] = "-";
                    dr["WeatherA_PY"] = "";
                    dr["WeatherB_PY"] = "";
                    dr["TMin"] = -99999;
                    dr["TMax"] = -99999;
                    dr["WindDir"] = "-";
                    dr["WindForce"] = "-";
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        //天气处理
        public string FromatWeatherPicture3(string weather)
        {

            if (!string.IsNullOrEmpty(weather))
            {
                if (weather.Trim().Contains("局部有霾"))
                {
                    weather = weather.Replace("局部有霾", "");
                }
                if (weather.Trim().Contains("局部霾"))
                {
                    weather = weather.Replace("局部霾", "");
                }
                if (weather.Trim().Contains("局部有有霾"))
                {
                    weather = weather.Replace("局部有有霾", "");
                }

                if (weather.Trim().Contains("转有霾"))
                {
                    weather = weather.Replace("转有霾", "");
                }
                if (weather.Trim().Contains("转霾"))
                {
                    weather = weather.Replace("转霾", "");
                }

                if (weather.Trim().Contains("有时有有霾"))
                {
                    weather = weather.Replace("有时有有霾", "");
                }
                if (weather.Trim().Contains("有时有霾"))
                {
                    weather = weather.Replace("有时有霾", "");
                }

                if (weather.Trim().Contains("有时有阵雨"))
                {
                    weather = weather.Replace("有时有阵雨", "");
                }
                if (weather.Trim().Contains(",有轻微"))
                {
                    weather = weather.Replace(",有轻微", "");
                }
                if (weather.Trim().Contains("到有霾"))
                {
                    weather = weather.Replace("到有霾", "");
                }
                if (weather.Trim().Contains("到霾"))
                {
                    weather = weather.Replace("到霾", "");
                }

                if (weather.Trim().Contains("有有霾"))
                {
                    weather = weather.Replace("有有霾", "");
                }
                if (weather.Trim().Contains("有霾"))
                {
                    weather = weather.Replace("有霾", "");
                }

                if (weather.Trim().Contains("或有霾"))
                {
                    weather = weather.Replace("或有霾", "");
                }
                if (weather.Trim().Contains("或霾"))
                {
                    weather = weather.Replace("或霾", "");
                }
                if (weather.Trim().Contains("阴转阴有小雨"))
                {
                    weather = weather.Replace("阴转阴有", "");
                }
                if (weather.Replace("，", ",").Trim().Contains(","))
                {
                    weather = weather.Replace("，", ",").Replace(",", "");
                }
                if (weather.Replace("，", ",").Trim().Contains("夜里"))
                {
                    weather = weather.Replace("，", ",").Replace("夜里", "");
                }
                if (weather.Replace("，", ",").Trim().Contains("半夜转"))
                {
                    weather = weather.Replace("，", ",").Replace("半夜转", "");
                }
                if (weather.Replace("，", ",").Trim().Contains("半夜"))
                {
                    weather = weather.Replace("，", ",").Replace("半夜", "");
                }
                if (weather.Replace("，", ",").Trim().Contains("前"))
                {
                    weather = weather.Replace("，", ",").Replace("前", "");
                }
                if (weather.Replace("，", ",").Trim().Contains("后"))
                {
                    weather = weather.Replace("，", ",").Replace("后", "");
                }

                if (weather.Replace("，", ",").Trim().Contains("中午"))
                {
                    weather = weather.Replace("，", ",").Replace("中午", "");
                }
                if (weather.Replace("，", ",").Trim().Contains("下午"))
                {
                    weather = weather.Replace("，", ",").Replace("下午", "");
                }
                if (weather.Replace("，", ",").Trim().Contains("上午"))
                {
                    weather = weather.Replace("，", ",").Replace("上午", "");
                }
                if (weather.Replace("，", ",").Trim().Contains("午"))
                {
                    weather = weather.Replace("，", ",").Replace("午", "");
                }
                if (weather.Replace("，", ",").Trim().Contains("傍晚到"))
                {
                    weather = weather.Replace("，", ",").Replace("傍晚到", "");
                }

                if (weather.Replace("，", ",").Trim().Contains("上半夜"))
                {
                    weather = weather.Replace("，", ",").Replace("上半夜", "");
                }
                if (weather.Replace("，", ",").Trim().Contains("下半夜"))
                {
                    weather = weather.Replace("，", ",").Replace("下半夜", "");
                }
                if (weather.Replace("，", ",").Trim().Contains("下半夜"))
                {
                    weather = weather.Replace("，", ",").Replace("下半夜", "");
                }
                if (weather.Replace("，", ",").Trim().Contains("傍晚"))
                {
                    weather = weather.Replace("，", ",").Replace("傍晚", "");
                }
                if (weather.Replace("，", ",").Trim().Contains("半夜"))
                {
                    weather = weather.Replace("，", ",").Replace("半夜", "");
                }

                if (weather.Trim() == "夜间晴到多云" || weather.Trim() == "夜间晴")
                {
                    return weather;
                }
                if (weather.IndexOf("转") != -1 || weather.IndexOf("轻微") != -1 || weather.IndexOf("有时有") != -1 || weather.IndexOf("到") != -1 || weather.IndexOf("有") != -1 || weather.IndexOf("或") != -1 || weather.IndexOf("局部") != -1 || weather.IndexOf("局部有") != -1)
                {
                    string strSplit = weather.Replace("转", "|").Replace("轻微", "|").Replace("局部有", "|").Replace("局部", "|").Replace("到", "|").Replace("有", "|").Replace("有时有", "|").Replace("或", "|");


                    string strPic = "";
                    string[] weatherPic = strSplit.Split(new char[] { '|' });
                    string[] str ={"晴","阴", "多云", "小雨", "中雨", "雷雨", "大雨", "暴雨",
                    "雷阵雨", "阵雨", "雾", "小雪", "中雪", "大雪", "暴雪" , "冰雹",
                "雨夹雪", "冻雨", "沙尘", "沙尘暴", "阴天", "浮尘","霾", "扬沙","雪","雷","雨"};
                    string num = "";
                    for (int j = 0; j < weatherPic.Length; j++)
                    {
                        for (int l = 0; l < str.Length; l++)
                        {
                            if (str[l].Trim().Contains(weatherPic[j]))
                            {

                                num = weatherPic[j];
                                break;
                            }
                            else
                            {
                                num = FromatWeatherPicture2(weatherPic[j]);
                            }
                        }
                        strPic += num + "|";
                    }
                    return strPic;
                }
                return weather;
            }
            return "";
        }

        public string FromatWeatherPicture2(string weather)
        {
            try
            {
                string[] str ={"晴","阴", "多云", "小雨", "中雨", "雷雨", "大雨", "暴雨",
                    "雷阵雨", "阵雨", "雾", "小雪", "中雪", "大雪", "暴雪" , "冰雹",
                "雨夹雪", "冻雨", "沙尘", "沙尘暴", "阴天", "浮尘","霾", "扬沙","雪","雷","雨"};
                if (!string.IsNullOrEmpty(weather))
                {

                    ArrayList list1 = new ArrayList(); //储存去重后剩余的元素
                    ArrayList list2 = new ArrayList(); //储存重复的元素
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (!weather.Trim().Contains(str[i]))
                            list1.Add(str[i]);
                        else
                            if (weather.Length > 2)
                            {
                                list2.Add(str[i]);
                            }
                            else
                            {
                                list2.Add(str[i]);
                                break;
                            }
                    }
                    string strPic1 = "";
                    string strPic = "";
                    for (int i = 0; i < list2.Count; i++)
                    {
                        strPic1 = Convert.ToString(list2[0]);
                    }
                    strPic = strPic1;
                    return strPic;
                }
            }
            catch (Exception)
            {

            }
            return "";
        }

        public string getPinyinHelper(string s)
        {
            if (s == "霾")
            {
                return "mai";
            }
            else
            {
                return PinyinHelper.GetPinyin(s);
            }
        }
    }
}
