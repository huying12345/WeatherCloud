
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
using Yamon.Framework.MVC;
using Yamon.Module.SiteManage.DAL;



namespace Yamon.Module.Weather.WebApi
{
    /// <summary>
    /// 文档
    /// </summary>
    public partial class WeatherDocController : _WeatherDocController
    {
        [CheckPurview(0)]
        public ActionResult GetDocList(int id = 0)
        {
            WeatherDocDAL weather = new WeatherDocDAL();
            List<WeatherDoc> dt = weather.GetDocList(id);
            return Content(JsonConvert.SerializeObject(dt));
        }
    }
}
