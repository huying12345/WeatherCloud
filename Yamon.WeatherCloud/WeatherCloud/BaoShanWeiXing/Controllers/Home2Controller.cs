using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BaoShanWeiXing.App_Start;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Module.Typhoon.DAL;
using Yamon.Module.Weather.DAL;
using Yamon.Module.Weather.Entity;

namespace BaoShanWeiXing.Controllers
{
    [WeiXinAuthorizeFilter]
    public class Home2Controller : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult weatherInfo()
        {
            return View();
        }

        public ActionResult Show(int id)
        {
            WeatherNodesDAL dal = new WeatherNodesDAL();

            int nodeId = id;
            int userId = CookieHelper.GetCookieInt("UserID");
            if (nodeId != 0 && userId != 0)
            {

                WeatherNodes node = dal.GetModelByID(nodeId);
                WeatherNodes firstChildNode = dal.GetFirstChildListByNodeID(nodeId, userId);
                if (firstChildNode != null)
                {
                    node = firstChildNode;
                    nodeId = DataConverter.ToInt(node.NodeID);
                }
                WeatherNodes firstChildNodes = dal.GetFirstChildListByNodeID(nodeId, userId);
                if (firstChildNodes != null)
                {
                    node = firstChildNodes;
                    nodeId = DataConverter.ToInt(node.NodeID);
                }
                WeatherNodesSubscribeDAL wNs = new WeatherNodesSubscribeDAL();
                WeatherNodes nodeInfo = dal.GetModelShowValue(node);
                ViewBag.NodeType = nodeInfo.NodeType;
                if (!string.IsNullOrEmpty(nodeInfo.TemplateName))
                {
                    return View(nodeInfo.TemplateName);
                }

                if (nodeInfo.NodeType == 2)
                {
                    return View("Doc");
                }
                if (nodeInfo.NodeType == 8)
                {
                    return View("Text");
                }
            }
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult TyphoonLine()
        {
            return View();
        }
        public ActionResult ImgPlay()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Text()
        {
            return View();
        }
        public ActionResult Station()
        {
            return View();
        }

        public ActionResult StationImgPlay()
        {
            return View();
        }
        public ActionResult StationPM()
        {
            return View();
        }

    }
}
