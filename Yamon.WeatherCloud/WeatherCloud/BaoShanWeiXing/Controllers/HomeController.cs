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
using Newtonsoft.Json.Linq;
using System.Data;

namespace BaoShanWeiXing.Controllers
{
    [WeiXinAuthorizeFilter]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult homepage()
        {
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

        public ActionResult GetTyphoonLineAction(string method, string year, string sno, string _)
        {
            TyphoonInfoDAL typhoonInfoDAL = new TyphoonInfoDAL();
            HttpHelper httpHelper = new HttpHelper();

            string content = httpHelper.Post("http://typhoon.shmmc.cn/TyphoonLine/method.aspx/" + method, "year=" + year + "&sno=" + sno, "http://typhoon.shmmc.cn/TyphoonLine/");

            return Content(content);
        }


        string cimissUrl = ConfigHelper.GetConfigString("CIMISS");//网址
        //
        public ActionResult getLiveweather()
        {

            /* 1. 调用方法的参数定义，并赋值 */
            string param = "&interfaceId=getSurfEleInRegionByTimeRange" /* 1.2 接口ID */
                + "&dataCode=SURF_CHN_MAIN_MIN" /* 1.3 必选参数（按需加可选参数） */ //资料：中国地面逐小时
                + "&elements=Station_Name,Datetime,PRS,RHU,TEM,WIN_S_Avg_1mi,WIN_D_Avg_1mi"
                //检索要素：站号、站名、小时降水、气压、相对湿度、能见度、1分钟平均风速、1分钟风向
                + "&timeRange=[" + DateTime.Now.ToUniversalTime().AddMinutes(-5).ToString("yyyyMMddHHmmss") + "," + DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss") + "]"
                //检索时间段
                + "&adminCodes=310113" //排序：按照站号从小到大
                + "&orderby=Datetime:desc" //排序：按照站号从小到大
                + "&dataFormat=json"; /* 1.4 序列化格式 */
            string url = cimissUrl + param;
            HttpHelper http = GetHttpHelper();
            string result = http.Post(url, param);

            JObject job = JsonConvert.DeserializeObject<JObject>(result);
            DataTable dtDs = JsonConvert.DeserializeObject<DataTable>(job["DS"].ToString());

            return Content(JsonConvert.SerializeObject(dtDs));
        }

        private HttpHelper GetHttpHelper()
        {
            HttpHelper httpHelper = new HttpHelper();
            if (ConfigHelper.GetConfigBool("Shcma_Proxy"))
            {
                httpHelper.SetProxy("cm.yamon.cn", 5222, "yamon", "!QAZxsw2");
            }
            return httpHelper;
        }
    }
}
