
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
    /// 用户资源订阅
    /// </summary>
    public partial class WeatherNodesSubscribeController : _WeatherNodesSubscribeController
    {

        //设置订阅 单个
        [NoCheckLogin]
        public ActionResult SetDataSubscribeOne()
        {
            int UserID = RequestHelper.GetRequestInt("UserID", 0);
            int NodeID = RequestHelper.GetRequestInt("NodeID", 0);

            WeatherNodesSubscribeDAL nodesSubscribeDAL = new WeatherNodesSubscribeDAL();

            hash["success"] = nodesSubscribeDAL.SetDataSubscribe(UserID, NodeID)>0;

            return Content(JsonConvert.SerializeObject(hash));
        }

        //取消订阅 单个
        [NoCheckLogin]
        public ActionResult CancelDataSubscribeOne()
        {
            int UserID = RequestHelper.GetRequestInt("UserID", 0);
            int NodeID = RequestHelper.GetRequestInt("NodeID", 0);

            WeatherNodesSubscribeDAL nodesSubscribeDAL = new WeatherNodesSubscribeDAL();

            hash["success"] = nodesSubscribeDAL.CancelDataSubscribeOne(UserID, NodeID) > 0;

            return Content(JsonConvert.SerializeObject(hash));
        }

        //设置订阅 多个
        [NoCheckLogin]
        public ActionResult SetDataSubscribe()
        {
            int UserID = RequestHelper.GetRequestInt("UserID", 0);
            string NodeID = RequestHelper.GetRequestString("NodeID", "");

            WeatherNodesSubscribeDAL nodesSubscribeDAL = new WeatherNodesSubscribeDAL();

            hash["success"] = nodesSubscribeDAL.SetDataSubscribe(UserID, NodeID)>0;

            return Content(JsonConvert.SerializeObject(hash));
        }

        //返回订阅数据
        [NoCheckLogin]
        public ActionResult GetDataSubscribe()
        {
            int UserID = RequestHelper.GetRequestInt("UserID", 0);
            WeatherNodesDAL weatherNodesDal = new WeatherNodesDAL();
            List<WeatherNodes> weatherNodes = weatherNodesDal.GetMySubscribeNodesListByUserID(UserID);
            hash["data"] = weatherNodes;
            hash["success"] = true;
            return Content(JsonConvert.SerializeObject(hash));
        }
    }
}
