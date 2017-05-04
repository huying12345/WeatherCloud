
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
using Yamon.Module.Typhoon.Entity;
using Yamon.Module.Typhoon.DAL;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Module.SiteManage.DAL;
using Yamon.Framework.MVC;



namespace Yamon.Module.Typhoon.WebApi
{
    /// <summary>
    /// 台风信息
    /// </summary>
    public partial class TyphoonInfoController : _TyphoonInfoController
    {

        TyphoonInfoDAL typhoonInfoDAL = new TyphoonInfoDAL();

         [CheckPurview(0)]
        public ActionResult GetTyphoonInfoListByTYear(int year = 0)
        {
            DataTable dt = typhoonInfoDAL.GetTyphoonInfoListByTYear(year);
            return Content(dt.ToJson());
        }

         [CheckPurview(0)]         
         public ActionResult GetNewTyphoonInfoList(int topR = 0)
         {
             DataTable dt = typhoonInfoDAL.GetNewTyphoonInfoList(topR);
             return Content(dt.ToJson());
         }
         //     [CheckPurview(0)]     
         //public ActionResult GetTyphoonLineAction(string provider, string assembly, string method, string year, string sno, string _)
         //{
            
         //    return Content(typhoonInfoDAL.GetTyphoon(provider, assembly, method, year, _, sno).ToString());
         //}

    }
}
