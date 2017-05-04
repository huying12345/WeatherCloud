
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
using Yamon.Module.zdz.Entity;
using Yamon.Module.zdz.DAL;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Module.SiteManage.DAL;
using Yamon.Framework.MVC;



namespace Yamon.Module.zdz.WebApi
{
    /// <summary>
    /// 自动站站点
    /// </summary>
    public partial class zdzStationController : _zdzStationController
    {

        [CheckPurview(0)]
        public ActionResult GetStationList()
        {
            zdzStationDAL list = new zdzStationDAL();
            string dt = list.GetStationList();
            return Content(dt);
        }

        [CheckPurview(0)]
        public ActionResult GetStationHours(string id)
        {
            zdzStationDAL list = new zdzStationDAL();
            string dt = list.GetStationHour(id);
            return Content(dt);
        }
        [CheckPurview(0)]
        public ActionResult GetStationRainHours(string id)
        {
            zdzStationDAL list = new zdzStationDAL();
            string dt = list.GetStationRainHour(id);
            return Content(dt);
        }
        [CheckPurview(0)]
        public ActionResult GetStaionsIMG(string id)
        {
            zdzStationDAL list = new zdzStationDAL();
            string dt = list.GetStaionIMG(id);
            return Content(dt);
        }
        [CheckPurview(0)]
        public ActionResult GetStaionsPM()
        {
            zdzStationDAL list = new zdzStationDAL();
            string dt = list.GetStaionPM();
            return Content(dt);
        }
    }
}
