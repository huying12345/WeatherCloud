using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using Yamon.Framework.MVC;
using Yamon.Module.Weather.DAL;

namespace Yamon.Module.Weather.WebApi
{
    public class WeatherDataController : BaseController
    {
        WeatherDataDAL dal = new WeatherDataDAL();

        //十天天气预报
        [NoCheckLogin]
        public ActionResult TenDayForecastList()
        {
            int isCreate = RequestHelper.GetRequestInt("isCreate", 0);
            try
            {
                string content = "";
                if (isCreate == 0)
                {
                    content = CacheReadFile.ReadFile("TenDayForecastList");
                    if (!string.IsNullOrEmpty(content))
                    {
                        return Content(content);
                    }
                }

                DataTable dtDs = new DataTable();
                dtDs = dal.TenDayForecastList();
                hash["data"] = dtDs;
                hash["success"] = true;

                //写入文件
                if (isCreate == 1)
                {
                    string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/show_TenDayForecastList.txt");
                    IOHelper.WriteFile(filePath, JsonConvert.SerializeObject(hash));
                }
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }

        //获取AQI数据
        [NoCheckLogin]
        public ActionResult GetAQI()
        {
            int isCreate = RequestHelper.GetRequestInt("isCreate", 0);
            try
            {
                string content = "";
                if (isCreate == 0)
                {
                    content = CacheReadFile.ReadFile("GetAQI");
                    if (!string.IsNullOrEmpty(content))
                    {
                        return Content(content);
                    }
                }

                DataRow dtRow = dal.GetAQI("");
                hash["data"] = dtRow.ToExpandoObject();
                hash["success"] = true;
                //写入文件
                if (isCreate == 1)
                {
                    string filePath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/show_GetAQI.txt");
                    IOHelper.WriteFile(filePath, JsonConvert.SerializeObject(hash));
                }
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }

    }
}
