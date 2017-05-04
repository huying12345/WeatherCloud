using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Yamon.Framework.Common;
using Yamon.Framework.MVC;

namespace Yamon.Module.Weather.WebApi
{
    [NoCheckLogin]
    public class TyphoonController : Controller
    {
        public ActionResult GetByYear()
        {
            ArrayList list = new ArrayList();
            for (int i = DateTime.Now.Year; i >= 1945; i--)
            {
                list.Add(new { year = i });
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTyphoonByYear(string id)
        {
            string content = GetTyphoonStringByYear(id);
            return Content(content);
        }

        public ActionResult GetTyphoonByID(string id)
        {
            string content = GetTyphoonStringByID(id);
            return Content(content);
        }

        public ActionResult GetCurrentTyphoon()
        {
            string content = GetTyphoonStringByYear(DateTime.Now.Year.ToString());
            JArray tyhoonList = JArray.Parse(content);


            JArray dataTable = new JArray();
            int i = 0;
            foreach (var row in tyhoonList)
            {
                if (((JObject)row)["is_current"].ToString() == "1")
                {
                    content = GetTyphoonStringByID(row["tfbh"].ToString());
                    JArray pathArray = JArray.Parse(content);
                    dataTable.Add(pathArray.First());
                    i++;
                }
            }
            return Content(JsonConvert.SerializeObject(dataTable));
        }


        private string GetTyphoonStringByYear(string id)
        {
            string url =
                "http://112.124.12.97/publictyphoon/PatrolHandler.ashx?provider=Readearth.PublicSrviceGIS.BLL.TyphoonBLL&assembly=Readearth.PublicSrviceGIS.BLL&method=GetTyhoonByYear";
            HttpHelper httpHelper = new HttpHelper();
            string content = httpHelper.Post(url, "&year=" + id);
            return content;
        }

        private string GetTyphoonStringByID(string id)
        {
            string url =
                   "http://112.124.12.97/publictyphoon/PatrolHandler.ashx?provider=Readearth.PublicSrviceGIS.BLL.TyphoonBLL&assembly=Readearth.PublicSrviceGIS.BLL&method=GetTyphoonDetail";
            HttpHelper httpHelper = new HttpHelper();
            return httpHelper.Post(url, "&sno=" + id);
        }
    }
}
