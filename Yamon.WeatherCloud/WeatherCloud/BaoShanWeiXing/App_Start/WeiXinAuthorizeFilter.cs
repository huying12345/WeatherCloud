using Senparc.Weixin.Open.OAuthAPIs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.QY.AdvancedAPIs;
using Yamon.Framework.Common;

namespace BaoShanWeiXing.App_Start
{
    public class WeiXinAuthorizeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (ConfigHelper.GetConfigBool("IsDebug") || !HttpContext.Current.Request.UserAgent.Contains("MicroMessenger"))
            {
                CookieHelper.WriteCookie("UserID", "1001");
                return;
            }
            if (string.IsNullOrEmpty(CookieHelper.GetCookie("UserName")))
            {
                string url = OAuth2Api.GetCode(ConfigHelper.GetConfigString("QY_CorpId"),
                    ConfigHelper.GetConfigString("SiteUrl").TrimEnd(',') + "/WeiXinAuthorize/Authorize", "wx");

                filterContext.Result = new RedirectResult(url);
            }
        }
    }
}