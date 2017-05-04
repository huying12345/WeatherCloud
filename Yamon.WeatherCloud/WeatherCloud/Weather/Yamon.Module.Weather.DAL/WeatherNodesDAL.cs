
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
    /// 共享资源分类实体类
    ///</summary>
    public partial class WeatherNodesDAL : _WeatherNodesDAL
    {

        public int SetDataPurview(int UserID, int DepartmentID, string NodeIDs)
        {
            int result = 0;
            try
            {
                List<SqlParametersKeyValue> sqllist = new List<SqlParametersKeyValue>();

                string[] arrNodeID = NodeIDs.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (UserID != 0)//通过用户设置
                {
                    Db.ExecuteNonQuerySqlEx("DELETE Weather_NodesPurview where UserID=?", UserID);
                }
                if (DepartmentID != 0)//通过部门设置
                {
                    Db.ExecuteNonQuerySqlEx("DELETE Weather_NodesPurview where DepartmentID=?", DepartmentID);
                }

                string insertSql = "INSERT INTO Weather_NodesPurview(NodeID,DepartmentID,UserID) VALUES(@NodeID,@DepartmentID,@UserID)";
                for (int i = 0; i < arrNodeID.Length; i++)
                {
                    Parameters db = new Parameters();
                    db.AddInParameter("NodeID", DbType.Int32, arrNodeID[i]);
                    db.AddInParameter("DepartmentID", DbType.Int32, DepartmentID);
                    db.AddInParameter("UserID", DbType.Int32, UserID);

                    sqllist.Add(new SqlParametersKeyValue(insertSql, db));
                }
               result= Db.ExecuteNonQueryTran(sqllist);
            }
            catch (Exception ex)
            {
            }
            return result;

        }

        //获取资源权限
        public string GetDataPurview(int UserID, int DepartmentID)
        {
            string result = "";
            try
            {
                if (UserID != 0)//通过用户设置
                {
                    result = Db.ExecuteStringSqlEx("select NodeID FROM Weather_NodesPurview where UserID=?", UserID);
                }
                if (DepartmentID != 0)//通过部门设置
                {
                    result = Db.ExecuteStringSqlEx("select NodeID FROM Weather_NodesPurview where DepartmentID=?", DepartmentID);
                }

            }
            catch (Exception ex)
            {
            }
            return result;
        }

        string fields = "NodeID,ParentID,NodeName,NodeType,SourceDepartment,OrderID,NodePicUrl,TemplateName,Tips,Description,isDataAccess";

        //根据UserID查询 资源权限
        public List<WeatherNodes> GetMyNodesListByUserID(int UserID)
        {

            string where = " NodeID in ( select distinct NodeID from Weather_NodesPurview where (UserID=?) or DepartmentID=(select  DepartmentID from UC_User where UserID=?) ) ";
            return GetEntityList(where, new object[] { UserID, UserID }, "", 0, fields);
        }

        //根据NodeID查询 同级资源
        public List<WeatherNodes> GetBrotherListByNodeID(int nodeId,int userId)
        {
            string where = " ParentID = (SELECT ParentID from Weather_Nodes where NodeID=?) AND NodeID in ( select distinct NodeID from Weather_NodesPurview where (UserID=?) or DepartmentID=(select  DepartmentID from UC_User where UserID=?) )  ";
            return GetEntityList(where, new object[] { nodeId, userId, userId }, "", 0, fields);
        }

        public WeatherNodes GetFirstChildListByNodeID(int nodeId, int userId)
        {
            string where = " ParentID = ? AND NodeID in ( select distinct NodeID from Weather_NodesPurview where (UserID=?) or DepartmentID=(select  DepartmentID from UC_User where UserID=?) )  ";
            return this.GetEntityModel(where, new object[] { nodeId, userId, userId }, "OrderID,NodeID", fields);
        }

        //根据NodeID查询 同级资源
        public List<WeatherNodes> GetParentListByNodeID(int nodeId, int userId)
        {
            string where = " ParentID =(select ParentID   from Weather_Nodes where nodeId=(SELECT ParentID from Weather_Nodes where NodeID=?))  AND NodeID in ( select distinct NodeID from Weather_NodesPurview where (UserID=?) or DepartmentID=(select  DepartmentID from UC_User where UserID=?))";
            return GetEntityList(where, new object[] { nodeId, userId, userId }, "", 0, fields);
        }

        //更加UserID查询 订阅权限
        public List<WeatherNodes> GetMySubscribeNodesListByUserID(int UserID)
        {

            string where = " NodeID in ( select distinct NodeID from Weather_NodesSubscribe where UserID=?) ";

            return GetEntityList(where, new object[] { UserID }, "", 0, fields);
        }


        #region 根据NodeID查询所有下级资源

        /// <summary>
        /// 更新为树级实体列表
        /// </summary>
        /// <param name="list">实体列表</param>
        /// <returns>树级实体列表</returns>
        public List<WeatherNodes> ModelListToTreeByParentID(List<WeatherNodes> list,int partentId)
        {
            //查找父节点
            List<WeatherNodes> rootType = list.Where(o => o.ParentID == partentId).OrderBy(o => o.OrderID).ToList();
            //递归主函数
            Action<WeatherNodes> addChild = null;
            addChild = (info =>
            {
                info.Children = new List<WeatherNodes>();
                var childInfo = list.Where(o => o.ParentID == info.NodeID).OrderBy(o => o.OrderID);

                if (childInfo.Count() == 0)
                    return;
                childInfo.All(o =>
                {
                    //if (info.Children == null)
                    //{
                    //    info.Children = new List<WeatherNodes>();
                    //}
                    info.Children.Add(o);
                    addChild(o);
                    return true;
                });
            });
            //递归调用
            rootType.ForEach(o => { addChild(o); });
            return rootType;
        }


        #endregion


       
    }
}
