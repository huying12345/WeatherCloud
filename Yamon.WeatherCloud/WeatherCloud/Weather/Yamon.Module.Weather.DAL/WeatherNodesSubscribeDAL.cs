
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Yamon.Framework.DBUtility;
using System.Collections;
using Yamon.Framework.Common.DataBase;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using System.IO;
using System.Linq.Expressions;
using Yamon.Framework.DAL;
using Yamon.Module.Weather.Entity;
using System;

namespace Yamon.Module.Weather.DAL
{
    /// <summary>
    /// 用户资源订阅实体类
    ///</summary>
    public partial class WeatherNodesSubscribeDAL : _WeatherNodesSubscribeDAL
    {

        //单个资源订阅
        public int SetDataSubscribe(int UserID, int NodeID)
        {
            int result = 0;
            try
            {
                if (!isSubscribe(UserID, NodeID))
                {
                    WeatherNodesSubscribe wNodesSubscribe = new WeatherNodesSubscribe();
                    wNodesSubscribe.UserID = UserID;
                    wNodesSubscribe.NodeID = NodeID;
                    result = InsertByModel(wNodesSubscribe);
                }
            }
            catch (Exception)
            {

            }
            return result;
        }

        //取消订阅 单个
        public int CancelDataSubscribeOne(int UserID, int NodeID)
        {
            int result = 0;
            try
            {

                WeatherNodesSubscribe wNodesSubscribe = new WeatherNodesSubscribe();
                wNodesSubscribe.UserID = UserID;
                wNodesSubscribe.NodeID = NodeID;

                result = Db.ExecuteNonQuerySqlEx(" delete Weather_NodesSubscribe where UserID=? and NodeID=? ", new object[] { UserID, NodeID });
            }
            catch (Exception)
            {

            }
            return result;
        }


        //多个资源订阅
        public int SetDataSubscribe(int UserID, string NodeID)
        {
            int result = 0;
            try
            {

                string[] NodeIDList = NodeID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                List<SqlParametersKeyValue> list = new List<SqlParametersKeyValue>();
                list.Add(new SqlParametersKeyValue("Delete  Weather_NodesSubscribe  where UserID=? ", UserID));
                for (int i = 0; i < NodeIDList.Length; i++)
                {
                    WeatherNodesSubscribe wNodesSubscribe = new WeatherNodesSubscribe();
                    wNodesSubscribe.UserID = UserID;
                    wNodesSubscribe.NodeID = DataConverter.ToInt(NodeIDList[i]) ;
                    list.Add(GetInsertByModelSql(wNodesSubscribe));
                }
                result = Db.ExecuteNonQueryTran(list);
            }
            catch (Exception)
            {

            }
            return result;
        }

        //是否订阅
        public bool isSubscribe(int UserID, int NodeID)
        {
            bool reslult = false;
            try
            {
                string sql = "SELECT COUNT(1) FROM Weather_NodesSubscribe  where UserID=? and NodeID=?";
                int count = DataConverter.ToInt(Db.ExecuteStringSqlEx(sql, UserID, NodeID), 0);
                if (count != 0)
                {
                    reslult = true;
                }
            }
            catch (Exception)
            {

            }
            return reslult;
        }
    }
}
