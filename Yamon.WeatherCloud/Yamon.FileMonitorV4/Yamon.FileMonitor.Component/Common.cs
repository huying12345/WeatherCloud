using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Data;
using Yamon.Framework.DBUtility;
using Yamon.Framework.Common;
using System.Globalization;
using System.Text.RegularExpressions;
using Yamon.Framework.Log4Net;
using Yamon.Module.Weather.Entity;

namespace Yamon.FileMonitor.Component
{
    public class Common
    {
        public static string TempSourceFileDirectory = ConfigHelper.GetConfigString("TempSourceFileDirectory");
        public static bool BackFile = true;

        // Methods
        public static void ErrorBackupFile(FileInfo fiNeedBackupFile, string backupPath)
        {
            try
            {
                //string newFileName = string.Empty;

                //string[] fileNames = fiNeedBackupFile.Name.Split(new char[] { '.' });
                //string ext = fileNames[fileNames.Length - 1];
                //newFileName = string.Format("Error_{0}_{1}.{2}", fiNeedBackupFile.Name.Substring(0, fiNeedBackupFile.Name.Length - 4), DateTime.Now.ToString("yyyyMMdd_HHmmss"), ext);

                //newFileName = Path.Combine(backupPath, newFileName);

                //if (!ValidatePath(backupPath))
                //{
                //    throw new Exception("备份文件夹不存在!");
                //}
                //if (fiNeedBackupFile.CopyTo(newFileName, true).Exists)
                //{
                //    fiNeedBackupFile.Delete();
                //}
            }
            catch (Exception ex)
            {
                FileServiceException.HandleFileServiceException(ex);
            }
        }
        // Methods
        public static void BackupFile(FileInfo fiNeedBackupFile, string backupPath, string backFileName)
        {
            try
            {
                string newFileName = string.Empty;
                if (string.IsNullOrEmpty(backFileName))
                {
                    string[] fileNames = fiNeedBackupFile.Name.Split(new char[] { '.' });
                    string ext = fileNames[fileNames.Length - 1];
                    newFileName = string.Format("{0}_{1}.{2}", fiNeedBackupFile.Name.Substring(0, fiNeedBackupFile.Name.Length - 4), DateTime.Now.ToString("yyyyMMdd_HHmmss"), ext);
                }
                else
                {
                    newFileName = backFileName;
                }
                // EventLog.WriteEntry("SMB Common", newFileName);
                newFileName = Path.Combine(backupPath, newFileName);

                if (!ValidatePath(backupPath))
                {
                    throw new Exception("备份文件夹不存在!");
                }
                if (fiNeedBackupFile.CopyTo(newFileName, true).Exists)
                {
                    fiNeedBackupFile.Delete();
                }
            }
            catch (Exception ex)
            {
                FileServiceException.HandleFileServiceException(ex);
            }
        }

        public static FileInfo[] GetFileInfos(string directoryPath)
        {
            return GetFileInfos(directoryPath, string.Empty);
        }

        public static FileInfo[] GetFileInfos(string directoryPath, string searchPattern)
        {
            if (directoryPath == string.Empty)
            {
                FileServiceException.HandleFileServiceException(new Exception("源文件夹不存在!"));
                return null;
            }
            FileInfo[] fiFiles = null;
            try
            {
                DirectoryInfo diSource = new DirectoryInfo(directoryPath);
                if (diSource == null)
                {
                    throw new Exception("源文件夹不存在!");
                }
                if (searchPattern != string.Empty)
                {
                    fiFiles = diSource.GetFiles(searchPattern);
                }
                else
                {
                    fiFiles = diSource.GetFiles();
                }
            }
            catch (Exception ex)
            {
                FileServiceException.HandleFileServiceException(ex);
            }
            return fiFiles;
        }

        public static bool ValidatePath(string Path)
        {
            if ((Path == null) || (Path.Length <= 0))
            {
                return false;
            }
            string ParentDirectory = Directory.GetParent(Path).FullName;
            if (!Directory.Exists(ParentDirectory) && !ValidatePath(ParentDirectory))
            {
                return false;
            }
            if (!Directory.Exists(Path))
            {
                try
                {
                    Directory.CreateDirectory(Path);
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        public static ArrayList GetAllNodeDataTime(DataRow row, DateTime startdate, DateTime enddate)
        {
            ArrayList timelist = new ArrayList();

            //DataTable dt = DbHelper.GetConn("WeatherData").ExecuteDataTableSql(string.Format("select * from Weather_Log where DataTime between '{0}' AND '{1}' AND NodeID={2} AND IsSuccess=1 AND LogType=1", startdate, enddate, row["NodeID"].ToString()));
            //SubPlanDAL planDal = new SubPlanDAL();
            //List<DateTime> myTimeList = planDal.GetDateTimeList(DataConverter.ToInt(row["SubPlanID"]), startdate, enddate);
            //foreach (DateTime dataTime in myTimeList)
            //{
            //    if (dt.Select("DataTime='" + dataTime + "'").Length == 0)
            //    {
            //        Log.AddLostLog(row["NodeID"].ToString(), "", "漏传产品，时次为" + dataTime, dataTime);
            //        timelist.Add(dataTime);
            //    }
            //}
            return timelist;
        }

        public static void MonitorLost()
        {
            try
            {
                DataTable dt = DbHelper.GetConn("WeatherData").ExecuteDataTableSql("SELECT * FROM Weather_ShareNodes Where IsImportToDB=1 AND IsTiming=1 AND IsMonitor=1 AND SubPlanID>0");
                foreach (DataRow row in dt.Rows)
                {
                    string startStr = DbHelper.GetConn("WeatherData").GetSingleString("select top 1 DataTime from Weather_Log where NodeID=" + row["NodeID"].ToString() + " Order by DataTime desc");
                    DateTime startDt = DateTime.Now.Date;
                    if (!string.IsNullOrEmpty(startStr))
                    {
                        DateTime.TryParse(startStr, out startDt);
                    }
                    //GetAllNodeDataTime(row, startDt, DateTime.Now.AddMinutes(DataConverter.ToInt(row["Deley"]) * -1));
                }
            }
            catch (Exception ex)
            {
                FileServiceException.AddLog(ex.Message);
            }
        }

        public static DateTime ToDateTime(string reg, string str)
        {
            return ToDateTime(reg, str, DateTime.Now);
        }

        public static DateTime ToDateTime(string reg, string str, DateTime fileLastModifyTime)
        {

            str = Regex.Replace(str, @"[^0-9]", "");
            try
            {
                if (!reg.Contains('M'))
                {
                    str = fileLastModifyTime.ToString("MM") + str;
                    reg = "MM" + reg;
                }
                if (!reg.Contains('y'))
                {
                    str = fileLastModifyTime.ToString("yyyy") + str;
                    reg = "yyyy" + reg;
                }
                bool isUTC = false;
                if (reg.Contains("8"))
                {
                    isUTC = true;
                    reg = reg.Replace("8", "");
                }
                DateTime dataTime = DateTime.ParseExact(str, reg, new System.Globalization.CultureInfo("zh-CN"),
                    System.Globalization.DateTimeStyles.AllowWhiteSpaces);
                if (isUTC)
                {
                    dataTime = dataTime.AddHours(8);
                }
                return dataTime;
            }
            catch
            {
            }
            return fileLastModifyTime;
        }

        // 截取字符串
        public static string CutOutText(string conStr, string startStr, string overStr, int incluL, int incluR)
        {
            try
            {
                string str = "";
                startStr = startStr.Replace("\n", "\r\n").Replace("\r\r\n", "\r\n");
                overStr = overStr.Replace("\n", "\r\n").Replace("\r\r\n", "\r\n");
                if (!string.IsNullOrEmpty(conStr))
                {
                    conStr = conStr.Replace("\n", "\r\n").Replace("\r\r\n", "\r\n");
                    int startIndex = 0;
                    if (!string.IsNullOrEmpty(startStr))
                    {
                        startIndex = conStr.IndexOf(startStr, 0, StringComparison.OrdinalIgnoreCase);
                        if (startIndex == -1)
                        {
                            return str;
                        }
                    }
                    if (incluL == 0)
                    {
                        startIndex += startStr.Length;
                    }
                    if (string.IsNullOrEmpty(overStr))
                    {
                        return conStr.Substring(startIndex);
                    }
                    int num2 = startIndex + conStr.Substring(startIndex).IndexOf(overStr, 0, StringComparison.OrdinalIgnoreCase);
                    if (num2 <= 0)
                    {
                        return str;
                    }
                    if (incluR == 1)
                    {
                        num2 += overStr.Length;
                    }
                    if ((startIndex >= 0) && ((num2 - startIndex) >= 0))
                    {
                        str = conStr.Substring(startIndex, num2 - startIndex);
                    }

                }
                return str;
            }
            catch (Exception)
            {
                return conStr;
            }
        }


        //判断字符在字符串中出现的次数
        public static int GetCharCount(string str, char c)
        {
            int j = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                {
                    j++;
                }
            }
            return j;
        }


        /// <summary>
        /// 根据配置和文件最后修改时间获取文件的时次
        /// </summary>
        /// <param name="row"></param>
        /// <param name="fileLastModifyTime"></param>
        /// <returns></returns>
        public static DateTime GetDataTime(WeatherNodes wNodes, string fileName, DateTime fileLastModifyTime)
        {
            if (!string.IsNullOrEmpty(wNodes.DateTimeFormat))
            {
                string reg = wNodes.NameRule;
                if (GetCharCount(reg, '{') == 1)
                {
                    //smc_river48_\d{12,}.jpg
                    string start = CutOutText(reg, "", "{", 0, 0).Replace("\\d", "");
                    string end = CutOutText(reg, "}", "", 0, 0);
                    if (!string.IsNullOrEmpty(start))
                    {
                        fileName = fileName.Replace(start, "");
                    }
                    if (!string.IsNullOrEmpty(end))
                    {
                        fileName = fileName.Replace(end, "");
                    }
                }
                return Common.ToDateTime(wNodes.DateTimeFormat, fileName, fileLastModifyTime);
            }
            else
            {

                //if (DataConverter.ToInt(row["IsTiming"]) == 1 && DataConverter.ToInt(row["SubPlanID"]) > 0)
                //{
                //    SubPlanDAL planDal = new SubPlanDAL();
                //    List<DateTime> timeList = planDal.GetDateTimeList(DataConverter.ToInt(row["SubPlanID"]), fileLastModifyTime.Date.AddDays(-1), fileLastModifyTime.Date.AddDays(1).AddMilliseconds(-1));
                //    int mint = 100000000;
                //    if (timeList.Count > 0)
                //    {
                //        DateTime minDataTime = timeList[0];
                //        foreach (DateTime item in timeList)
                //        {
                //            TimeSpan t = item - fileLastModifyTime;
                //            if (Math.Abs((int)t.TotalMinutes) < mint)
                //            {
                //                mint = Math.Abs((int)t.TotalMinutes);
                //                minDataTime = item;
                //            }
                //        }
                //        return minDataTime;
                //    }
                //}
            }
            return fileLastModifyTime;
        }

        public static DateTime UCGetDataTime(DataRow row, string fileName, DateTime fileLastModifyTime)
        {
            if (!string.IsNullOrEmpty(row["DateTimeFormat"].ToString()))
            {
                return Common.ToDateTime(row["DateTimeFormat"].ToString(), fileName);
            }
            return fileLastModifyTime;
        }

        /// <summary>
        /// 执行Http任务
        /// </summary>
        /// <param name="urllist"></param>
        public static void RunHttpTask(string urllist)
        {
            if (!string.IsNullOrEmpty(urllist))
            {
                urllist = urllist.Replace("\n", "\r\n").Replace("\r\r\n", "\r\n");
                string[] arrUrl = urllist.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                HttpHelper httpHelper = new HttpHelper();
                for (int kk = 0; kk < arrUrl.Length; kk++)
                {
                    try
                    {
                        httpHelper.Get(arrUrl[kk]);
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(ex.Message, ex);
                    }
                }
            }
        }
        public static bool IsExecute = false;

        public static void SendFile(int nodeId, string filePath, string fileName, bool isTextSharp = true)
        {
            
        }
    }
}
