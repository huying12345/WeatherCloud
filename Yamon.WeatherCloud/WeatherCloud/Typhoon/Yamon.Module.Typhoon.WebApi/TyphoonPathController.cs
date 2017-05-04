
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
    /// 台风路径
    /// </summary>
    public partial class TyphoonPathController : _TyphoonPathController
    {
        TyphoonPathDAL typhoonPathDAL = new TyphoonPathDAL();

        /// <summary>
        /// 转换成CSV
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rCenter"></param>
        /// <returns></returns>
         [CheckPurview(0)]        
        public ActionResult GetTyphoonPathDetailByID(int typhoonID,string rCenter=null)
        {
            DataTable dt = typhoonPathDAL.GetTyphoonPathDetailByID(typhoonID, rCenter);
            return Content(TyphoonPathDAL.DatatableToCSV(dt,false));
        }

        /// <summary>
        /// 转换Json
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rCenter"></param>
        /// <returns></returns>
        [CheckPurview(0)]
         public ActionResult GetTyphoonPathDetailByIDToJson(int typhoonID, string rCenter = null)
        {
            DataTable dt = typhoonPathDAL.GetTyphoonPathDetailByID(typhoonID, rCenter);
            return Content(dt.ToJson());
        }

    }
}
