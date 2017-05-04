
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



namespace Yamon.Module.Weather.Web.Controllers
{
    /// <summary>
    /// 共享资源分类
    /// </summary>
    public partial class WeatherNodesController : _WeatherNodesController
    {
        public ActionResult SetDataPurview()
        {
            return View();
        }


       
    }
}
