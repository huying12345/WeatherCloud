
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Linq.Expressions;
using System.Web.Mvc;
using Yamon.Framework.DAL;
using Yamon.Module.Weather.Entity;
using Yamon.Module.Weather.DAL;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Module.SiteManage.DAL;
using Yamon.Framework.MVC;



namespace Yamon.Module.Weather.WebApi
{
    /// <summary>
    /// 共享资源分类
    /// </summary>
    public partial class WeatherNodesController : _WeatherNodesController
    {

        //设置资源权限
        public ActionResult SetDataPurview()
        {
            int UserID = RequestHelper.GetRequestInt("UserID", 0);
            int DepartmentID = RequestHelper.GetRequestInt("DepartmentID", 0);
            string NodeIDList = RequestHelper.GetRequestString("NodeID");
            hash["success"] = dal.SetDataPurview(UserID, DepartmentID, NodeIDList) > 0;
            return Content(JsonConvert.SerializeObject(hash));
        }

        //获取资源权限
        [CheckPurview("Weather_WeatherNodes_SetDataPurview")]
        public ActionResult GetDataPurview()
        {
            int UserID = RequestHelper.GetRequestInt("UserID", 0);
            int DepartmentID = RequestHelper.GetRequestInt("DepartmentID", 0);
            hash["data"] = dal.GetDataPurview(UserID, DepartmentID);
            hash["success"] = true;
            return Content(JsonConvert.SerializeObject(hash));
        }

        //根据用户id获取资源数据
        [NoCheckLogin]
        public ActionResult GetMyTreeGrid(int userId=0,int parentId=0)
        {
            try
            {
                int _totalRows = 0;
                List<WeatherNodes> modelList = new List<WeatherNodes>();
                if (userId != 0)
                {
                    modelList = dal.GetMyNodesListByUserID(userId);
                }

                List<WeatherNodes> newModelList = modelList.Select(model => dal.GetModelGridShowValue(model)).ToList();
                _totalRows = modelList.Count;
                newModelList = dal.ModelListToTreeByParentID(newModelList, parentId);
                hash["rows"] = newModelList;
                hash["total"] = _totalRows;
                hash["success"] = true;
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
            }
            return Content(JsonConvert.SerializeObject(hash));

        }

        //根据用户ID ,资源编号获取同级、父级列表
        [NoCheckLogin]
        public ActionResult GetMyNodesBrotherParentListByNodeID(int nodeId = 0, int userId = 0)
        {
            try
            {
                if (nodeId != 0 && userId != 0)
                {

                   WeatherNodes node= dal.GetModelByID(nodeId);
                   WeatherNodes firstChildNode=dal.GetFirstChildListByNodeID(nodeId, userId);
                    if(firstChildNode!=null){
                        node = firstChildNode;
                        nodeId = DataConverter.ToInt(node.NodeID);
                    }
                    WeatherNodes firstChildNodes = dal.GetFirstChildListByNodeID(nodeId, userId);
                    if (firstChildNodes != null)
                    {
                        node = firstChildNodes;
                        nodeId = DataConverter.ToInt(node.NodeID);
                    }
                    List<WeatherNodes> brotherList = dal.GetBrotherListByNodeID(nodeId, userId);
                    List<WeatherNodes> newBrotherList = brotherList.Select(model => dal.GetModelGridShowValue(model)).ToList();

                    List<WeatherNodes> parentList = dal.GetParentListByNodeID(nodeId, userId);
                    List<WeatherNodes> newParentList = parentList.Select(model => dal.GetModelGridShowValue(model)).ToList();
                    hash["parent"] = newParentList;
                    hash["brother"] = newBrotherList;
                    WeatherNodesSubscribeDAL wNs=new WeatherNodesSubscribeDAL();
                    hash["node"] = dal.GetModelShowValue(node);
                    hash["issubscribe"] = wNs.isSubscribe( userId,nodeId);
                }
                hash["success"] = true;
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }

        //
        [NoCheckLogin]
        public ActionResult GetDataAccessList()
        {
            string fields = "NodeID,ParentID,NodeName,NodeType,SourceDepartment,OrderID,NodePicUrl,TemplateName,Tips,Description,isDataAccess";
            hash["data"] = dal.GetEntityList("isDataAccess=1", null, "", 0, fields);
            hash["success"] = true;
            return Content(JsonConvert.SerializeObject(hash));
        }

       
    }
}
