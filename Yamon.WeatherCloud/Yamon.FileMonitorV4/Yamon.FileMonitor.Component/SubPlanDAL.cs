using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using Yamon.Framework.Common;
using Yamon.Framework.DBUtility;

namespace Yamon.FileMonitor.Component
{
    public class SubPlanDAL
    {
        public SubPlanDAL()
        {

        }

        public DataRow GetEntityByID(string id)
        {
            string sql = "select * from SiteManage_SubPlan where SubPlanID=" + id;
            return DbHelper.GetConn("WeatherService").ExecuteDataRowSql(sql);
        }

        public List<DateTime> GetDateList(int subPlanId, DateTime beginTime, DateTime endTime)
        {
            endTime = endTime.Date;
            List<DateTime> datetimeList = new List<DateTime>();
            DataRow planInfo = GetEntityByID(subPlanId.ToString());
            DateTime planStartDate = DataConverter.ToDate(planInfo["BeginDate"].ToString());
            DateTime planEndDate = DataConverter.ToDate(planInfo["EndDate"].ToString());
            int NoEndDate = DataConverter.ToInt(planInfo["NoEndDate"]);

            if (DateTime.Compare(planStartDate, endTime) > 0)
            {
                return datetimeList;
            }
            if (DateTime.Compare(planStartDate, endTime) < 0 && DateTime.Compare(planStartDate, beginTime) > 0)
            {
                beginTime = planStartDate;
            }
            if (NoEndDate == 0 && DateTime.Compare(planEndDate, endTime) < 0)
            {
                endTime = planEndDate;
            }
            string timeType = planInfo["ExecuteTimeType"].ToString();

            if (timeType == "Day")
            {
                DateTime dataTime = beginTime.Date;
                int interval = DataConverter.ToInt(planInfo["Day_Interval"]);
                datetimeList.Add(dataTime);
                while (DateTime.Compare(dataTime, endTime) < 0)
                {
                    dataTime = dataTime.AddDays(interval);
                    datetimeList.Add(dataTime);
                }
            }
            else if (timeType == "Week")
            {
                DateTime dataTime = beginTime.Date;
                int interval = DataConverter.ToInt(planInfo["Week_LoopNum"]);
                string[] arrWeek_Loop = planInfo["Week_Loop"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                while (DateTime.Compare(dataTime, endTime) < 0)
                {
                    if (interval > 1)
                    {
                        int weeks = DiffWeek(DataConverter.ToDate(planInfo["BeginDate"].ToString()), dataTime);
                        if ((int)dataTime.DayOfWeek == 1 && weeks % interval != 0)
                        {
                            dataTime = dataTime.AddDays(6);
                        }
                    }
                    for (int i = 0; i < arrWeek_Loop.Length; i++)
                    {
                        if (DataConverter.ToInt(arrWeek_Loop[i]) == (int)dataTime.DayOfWeek)
                        {
                            datetimeList.Add(dataTime);
                        }
                    }
                    dataTime = dataTime.AddDays(1);
                }
            }
            else if (timeType == "Month")
            {
                DateTime dataTime = beginTime.Date;
                int Month_Interval = DataConverter.ToInt(planInfo["Month_Interval"]);
                if (planInfo["MonthLoopType"].ToString() == "Week")
                {
                    int interval = DataConverter.ToInt(planInfo["Month_Day_Num"]);


                    while (DateTime.Compare(dataTime, endTime) < 0)
                    {
                        if (Month_Interval > 1)
                        {
                            int months = DiffMonth(DataConverter.ToDate(planInfo["BeginDate"].ToString()), dataTime);
                            if ((int)dataTime.Day == 1 && months % Month_Interval != 0)
                            {
                                dataTime = dataTime.AddMonths(1).AddDays(-1);
                            }
                        }
                        int month_week_num = DataConverter.ToInt(planInfo["Month_Week_Num"]);

                        if ((month_week_num > 0 && month_week_num == WeekOfMonth(dataTime)) || month_week_num == 0 && 5 == WeekOfMonth(dataTime))
                        {
                            int month_week_loop = DataConverter.ToInt(planInfo["Month_Week_Loop"].ToString());

                            if ((month_week_loop >= 0 && month_week_loop == (int)dataTime.DayOfWeek) || (month_week_loop == -1 && (int)dataTime.DayOfWeek > 0 && (int)dataTime.DayOfWeek < 6) || (month_week_loop == -2 && ((int)dataTime.DayOfWeek == 0 || (int)dataTime.DayOfWeek == 6)))
                            {
                                datetimeList.Add(dataTime);
                            }
                        }
                        dataTime = dataTime.AddDays(1);
                    }
                }
                else if (planInfo["MonthLoopType"].ToString() == "Tenday")
                {

                    int interval = DataConverter.ToInt(planInfo["TenDay_Interval"]);

                    while (DateTime.Compare(dataTime, endTime) < 0)
                    {
                        if (Month_Interval > 1)
                        {
                            int months = DiffMonth(DataConverter.ToDate(planInfo["BeginDate"].ToString()), dataTime);
                            if ((int)dataTime.Day == 1 && months % Month_Interval != 0)
                            {
                                dataTime = dataTime.AddMonths(1).AddDays(-1);
                            }
                        }

                        dataTime = dataTime.AddDays(1);
                        string[] arrTendayList = planInfo["TendayList"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (interval > 9)
                        {

                            if (dataTime.ToString("dd").EndsWith("0"))
                            {
                                for (int i = 0; i < arrTendayList.Length; i++)
                                {
                                    int arrTenday = DataConverter.ToInt(arrTendayList[i]) + 1;
                                    if (dataTime.ToString("dd").StartsWith(arrTenday.ToString()))
                                    {
                                        datetimeList.Add(dataTime);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (dataTime.ToString("dd").EndsWith(interval.ToString()))
                            {
                                for (int i = 0; i < arrTendayList.Length; i++)
                                {

                                    if (dataTime.ToString("dd").StartsWith(arrTendayList[i]))
                                    {
                                        datetimeList.Add(dataTime);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    int interval = DataConverter.ToInt(planInfo["Month_Day_Interval"]);

                    while (DateTime.Compare(dataTime, endTime) < 0)
                    {
                        if (Month_Interval > 1)
                        {
                            int months = DiffMonth(DataConverter.ToDate(planInfo["BeginDate"].ToString()), dataTime);
                            if ((int)dataTime.Day == 1 && months % Month_Interval != 0)
                            {
                                dataTime = dataTime.AddMonths(1).AddDays(-1);
                            }
                        }

                        if (dataTime.Day.ToString() == interval.ToString())
                        {
                            datetimeList.Add(dataTime);
                        }
                        dataTime = dataTime.AddDays(1);
                    }
                }
            }
            return datetimeList;
        }

        public List<DateTime> GetDateTimeList(int subPlanId, DateTime beginTime, DateTime endTime)
        {
            List<DateTime> datelist = GetDateList(subPlanId, beginTime, endTime);
            List<DateTime> timelist = new List<DateTime>();
            foreach (DateTime item in datelist)
            {
                timelist.AddRange(GetDay_DateTimeList(subPlanId, item));
            }
            return timelist;
        }

        public List<DateTime> GetDay_DateTimeList(int subPlanId, DateTime dataTime)
        {
            DataRow planInfo = GetEntityByID(subPlanId.ToString());
            return GetDay_DateTimeList(planInfo, dataTime);
        }

        public List<DateTime> GetDay_DateTimeList(DataRow planInfo, DateTime dataTime)
        {
            List<DateTime> dataTimeList = new List<DateTime>();

            string timeType = planInfo["DayExecuteTimeType"].ToString();
            dataTime = dataTime.Date;
            if (timeType == "Once")
            {
                dataTimeList.Add(DataConverter.ToDate(dataTime.Date.ToString("yyyy-MM-dd") + " " + planInfo["Day_Time"]));
            }
            else if (timeType == "Repeatedly")
            {
                string[] arrDay_TimeList = planInfo["Day_TimeList"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arrDay_TimeList.Length; i++)
                {
                    dataTimeList.Add(DataConverter.ToDate(dataTime.Date.ToString("yyyy-MM-dd") + " " + arrDay_TimeList[i]));
                }
            }
            else if (timeType == "Loop")
            {
                dataTime = DataConverter.ToDate(dataTime.Date.ToString("yyyy-MM-dd") + " " + planInfo["Day_BeginTime"]);
                DateTime endTime = DataConverter.ToDate(dataTime.Date.ToString("yyyy-MM-dd") + " " + planInfo["Day_EndTime"]);
                if (planInfo["Day_EndTime"] == "00:00")
                {
                    endTime.AddDays(1).AddMinutes(-1);
                }
                string day_LoopType = planInfo["Day_LoopType"].ToString();
                int day_LoopNum = DataConverter.ToInt(planInfo["Day_LoopNum"]);
                dataTimeList.Add(dataTime);
                while (DateTime.Compare(dataTime, endTime) < 0)
                {
                    if (day_LoopType == "Hour")
                    {
                        dataTime = dataTime.AddHours(day_LoopNum);
                    }
                    else if (day_LoopType == "Minute")
                    {
                        dataTime = dataTime.AddMinutes(day_LoopNum);
                    }
                    else if (day_LoopType == "Second")
                    {
                        dataTime = dataTime.AddSeconds(day_LoopNum);
                    }
                    if (DateTime.Compare(dataTime, endTime) < 0)
                    {
                        dataTimeList.Add(dataTime);
                    }
                }
            }
            return dataTimeList;
        }

        /// <summary>
        /// 每月中的第几周
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public int WeekOfMonth(DateTime dateime)
        {
            return WeekOfMonth(dateime, false);
        }

        /// <summary>
        /// 直接得到当天是当月的第几周 dtSel:要判断的日期,sundayStart：一周的第一天是否为周日
        /// </summary>
        /// <param name="dtSel">要判断的日期</param>
        /// <param name="sundayStart">一周的第一天是否为周日</param>
        /// <returns></returns>
        public int WeekOfMonth(DateTime dtSel, bool sundayStart)
        {
            //如果要判断的日期为1号，则肯定是第一周了
            if (dtSel.Day == 1)
                return 1;
            else
            {
                //得到本月第一天
                DateTime dtStart = new DateTime(dtSel.Year, dtSel.Month, 1);
                //得到本月第一天是周几
                int dayofweek = (int)dtStart.DayOfWeek;
                //如果不是以周日开始，需要重新计算一下dayofweek，详细风DayOfWeek枚举的定义
                if (!sundayStart)
                {
                    dayofweek = dayofweek - 1;
                    if (dayofweek < 0)
                        dayofweek = 7;
                }
                //得到本月的第一周一共有几天
                int startWeekDays = 7 - dayofweek;
                //如果要判断的日期在第一周范围内，返回1
                if (dtSel.Day <= startWeekDays)
                    return 1;
                else
                {
                    int aday = dtSel.Day + 7 - startWeekDays;
                    return aday / 7 + (aday % 7 > 0 ? 1 : 0);
                }
            }
        }
        /// <summary>
        ///  周数之差
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int DiffWeek(DateTime startTime, DateTime endTime)
        {
            TimeSpan ts = new TimeSpan(startTime.Ticks - endTime.Ticks);
            int tsDays = ts.Days + ((int)startTime.DayOfWeek - 1);
            if (endTime.DayOfWeek == 0)
            {
                return tsDays / 7;
            }
            else
            {
                return tsDays / 7 + 1;
            }
        }

        /// <summary>
        /// 月数之差
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public int DiffMonth(DateTime startTime, DateTime endTime)
        {
            int year = endTime.Year - startTime.Year;
            if (startTime.Month >= endTime.Month)
            {
                return (year - 1) * 12 + (12 - startTime.Month + endTime.Month);
            }
            else
            {
                return year * 12 + (endTime.Month - startTime.Month);
            }
        }

        public string GetDateOption(int subPlanId, DateTime beginTime, DateTime endTime)
        {

            StringBuilder sb = new StringBuilder();
            DataRow planInfo = GetEntityByID(subPlanId.ToString());

            string timeType = planInfo["ExecuteTimeType"].ToString();
            List<DateTime> timelist = GetDateList(subPlanId, beginTime, endTime);

            foreach (DateTime dataTime in timelist)
            {
                if (timeType == "Day")
                {
                    sb.AppendLine(string.Format("<option value=\"{0}\">{0}</option>", dataTime.ToString("yyyy-MM-dd")));
                }
                else if (timeType == "Week")
                {
                    sb.AppendLine(string.Format("<option value=\"{0}\">{1}</option>", dataTime.ToString("yyyy-MM-dd"), dataTime.ToString("yyyy-MM-dd") + " " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dataTime.DayOfWeek)));
                }
                else if (timeType == "Month")
                {
                    int Month_Interval = DataConverter.ToInt(planInfo["Month_Interval"]);
                    if (planInfo["MonthLoopType"].ToString() == "Week")
                    {
                        sb.AppendLine(string.Format("<option value=\"{0}\">{1}</option>", dataTime.ToString("yyyy-MM-dd"), dataTime.ToString("yyyy-MM-dd") + " " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dataTime.DayOfWeek)));
                    }
                    else
                    {
                        sb.AppendLine(string.Format("<option value=\"{0}\">{0}</option>", dataTime.ToString("yyyy-MM-dd")));
                    }
                }
            }
            return sb.ToString();
        }
        public string GetDay_DateTimeOption(int subPlanId, DateTime dataTime)
        {
            DataRow planInfo = GetEntityByID(subPlanId.ToString());
            return GetDay_DateTimeOption(planInfo, dataTime);
        }
        public string GetDay_DateTimeOption(DataRow planInfo, DateTime dataTime)
        {
            List<DateTime> timelist = GetDay_DateTimeList(planInfo, dataTime);
            StringBuilder sb = new StringBuilder();
            string timeType = planInfo["DayExecuteTimeType"].ToString();
            foreach (DateTime time in timelist)
            {
                if (timeType == "Once")
                {
                    return "";
                }
                else if (timeType == "Repeatedly")
                {

                    sb.AppendLine(string.Format("<option value=\"{0}\">{0}</option>", time.ToString("HH:mm")));


                }
                else if (timeType == "Loop")
                {
                    string day_LoopType = planInfo["Day_LoopType"].ToString();
                    if (day_LoopType == "Hour")
                    {
                        sb.AppendLine(string.Format("<option value=\"{0}\">{0}时</option>", time.ToString("HH"))); ;
                    }
                    else if (day_LoopType == "Minute")
                    {
                        sb.AppendLine(string.Format("<option value=\"{0}\">{0}</option>", time.ToString("HH:mm")));
                    }
                    else if (day_LoopType == "Second")
                    {
                        sb.AppendLine(string.Format("<option value=\"{0}\">{0}</option>", time.ToString("HH:mm:ss")));
                    }
                }
            }
            return sb.ToString();
        }

    }
}
