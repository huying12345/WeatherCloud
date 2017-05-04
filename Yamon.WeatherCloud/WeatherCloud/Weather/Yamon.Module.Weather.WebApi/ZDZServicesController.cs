using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Yamon.Framework.MVC;

namespace Yamon.Module.Weather.WebApi
{
    public class ZDZServicesController : BaseController
    {
        //获得单个站点的最新实况观测要素
        [NoCheckLogin]
        public ActionResult GetLastestZdzInfoByID(string stationID = "95012")
        {

            try
            {
                ZDZServices.ServiceSoapClient zdzService = new ZDZServices.ServiceSoapClient();
                DataTable data = zdzService.GetLastestZdzInfoByID(stationID).Tables[0];
                hash["data"] = data;
                hash["success"] = true;
            }
            catch (Exception ex)
            {
                hash["message"] = ex.Message;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }


    }
}
