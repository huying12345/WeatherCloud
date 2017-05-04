using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yamon.Framework.DBUtility;
using System.Collections;
using Yamon.Framework.Common;
using System.Data.SqlClient;
using System.Data;
using Yamon.Framework.Common.DataBase;

namespace Yamon.FileMonitor.Component
{
    public static class Log
    {
        //操作成功/失败 日志
        public static void AddLog(string NodeID, string fileName, string LogContent, int IsSuccess)
        {
            AddLog(NodeID, fileName, LogContent, IsSuccess, DateTime.Now,0, 10);
        }
        //操作成功/失败 日志
        public static void AddLog(string NodeID, string fileName, string LogContent, int IsSuccess, DateTime dataTime,int isMonitor, int delay)
        {
            try
            {
                ArrayList sqllist = new ArrayList();

                List<SqlParametersKeyValue> list = new List<SqlParametersKeyValue>();
                string sqlstr = string.Format("INSERT INTO  Weather_Log (NodeID,LogTime,FileName,LogContent,IsSuccess,LogType,DataTime) " +
                 "VALUES({0},getdate(),'{1}','{2}',{3},{4},'{5}')", NodeID, fileName, LogContent, IsSuccess, "1", dataTime.ToString());
                sqllist.Add(sqlstr);
                if (isMonitor > 0)
                {
                    TimeSpan t = DateTime.Now - dataTime;
                    if (t.TotalMilliseconds > delay * 3600 * 1000)
                    {
                        sqlstr = string.Format("INSERT INTO  Weather_Log (NodeID,LogTime,FileName,LogContent,IsSuccess,LogType,DataTime) " +
                         "VALUES({0},getdate(),'{1}','{2}',{3},{4},'{5}')", NodeID, fileName, "迟到产品，共迟到" + (int)t.TotalHours + "小时" + t.Minutes + "分", 1, "3", dataTime.ToString());
                        sqllist.Add(sqlstr);
                        sqlstr = string.Format("Update Weather_Log set IsSuccess=0 where NodeID={0} AND DataTime='{1}' AND LogType=2", NodeID, dataTime);
                        sqllist.Add(sqlstr);
                    }
                }
                DbHelper.GetConn("WeatherData").ExecuteNonQueryTran(sqllist);
            }
            catch
            {
                //throw;
            }
        }

        //漏传日志
        public static void AddLostLog(string NodeID, string fileName, string LogContent, DateTime dataTime)
        {
            try
            {
                int count = DbHelper.GetConn("WeatherData").GetSingleInt(string.Format("select count(1) from Weather_Log where NodeID={0} AND DataTime='{1}' AND LogType=2", NodeID, dataTime));
                if (count == 0)
                {
                    string sqlstr = string.Format("INSERT INTO Weather_Log (NodeID,LogTime,FileName,LogContent,IsSuccess,LogType,DataTime) " +
                     "VALUES({0},getdate(),'{1}','{2}',{3},{4},'{5}')", NodeID, fileName, LogContent, 1, "2", dataTime.ToString());
                    DbHelper.GetConn("WeatherData").ExecuteNonQuerySql(sqlstr);
                }
            }
            catch
            {
                //throw;
            }
        }


        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="logKey">日志关键字</param>
        /// <param name="logType">日志类型</param>
        /// <param name="logContent">日志内容</param>
        /// <param name="appId">应用编号</param>
        /// <param name="logTime">日志时间</param>
        /// <param name="userId">用户编号</param>
        /// <param name="userIP">用户IP</param>
        /// <returns></returns>
        public static int UCAddLog(string modelId, string logKey, string logType, string logContent, int isSuccess, int userId, string userIP)
        {
            try
            {

                string sql = string.Format("Insert Into UC_Log(LogKey,LogType,LogContent,UserId,UserIP,LogTime,ModelID,IsSuccess,CityID) values(@LogKey,@LogType,@LogContent,@UserId,@UserIP,@LogTime,@ModelID,@IsSuccess,@CityID)");
                Parameters db = new Parameters();
                db.AddInParameter("LogKey", DbType.String, logKey);
                db.AddInParameter("LogType", DbType.String, logType);
                db.AddInParameter("LogContent", DbType.String, logContent);
                db.AddInParameter("UserId", DbType.Int32, userId);
                db.AddInParameter("UserIP", DbType.String, userIP);
                db.AddInParameter("LogTime", DbType.DateTime, DateTime.Now);
                db.AddInParameter("ModelID", DbType.String, modelId);
                db.AddInParameter("IsSuccess", DbType.String, isSuccess);
                db.AddInParameter("CityID", DbType.String, "js");

                return DbHelper.GetConn("WeatherData").ExecuteNonQuerySql(sql, db);
            }
            catch { }
            return 0;
        }

        public static int UCAddLog(string logContent, int isSuccess)
        {
            return UCAddLog("Information", "0", "Import", logContent, isSuccess, 0, RequestHelper.GetIP());
        }

        public static int UCAddLog(string logContent)
        {
            return UCAddLog("Information", "0", "Import", logContent, 1, 0, RequestHelper.GetIP());
        }


    }
}
