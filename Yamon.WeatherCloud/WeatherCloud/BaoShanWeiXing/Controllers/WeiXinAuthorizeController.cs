using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.Helpers;
using Senparc.Weixin.QY.AdvancedAPIs;
using Senparc.Weixin.QY.AdvancedAPIs.OAuth2;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using Yamon.Module.UCenter.DAL;
using Yamon.Module.UCenter.Entity;

namespace BaoShanWeiXing.Controllers
{
    public class WeiXinAuthorizeController : Controller
    {
        public static readonly string CorpId = ConfigHelper.GetConfigString("QY_CorpId");//与微信企业账号后台的CorpId设置保持一致，区分大小写。
        public static readonly string CorpSecrets = ConfigHelper.GetConfigString("QY_CorpSecrets");
        public ActionResult Authorize(string code = "")
        {

            var accessToken = Senparc.Weixin.QY.Containers.AccessTokenContainer.TryGetToken(CorpId, CorpSecrets);
            GetUserInfoResult result = OAuth2Api.GetUserId(accessToken, code);
            CookieHelper.WriteCookie("DeviceId", result.DeviceId);
            CookieHelper.WriteCookie("UserName", result.UserId);
            CookieHelper.WriteCookie("OpenId", result.OpenId);

            UserDAL userDal = new UserDAL();
            User user = userDal.GetEntityModel("UserName=?", new[] { result.UserId });
            if (user != null)
            {
                CookieHelper.WriteCookie("UserID", user.UserID.ToString());
            }
            IOHelper.WriteAppend(Server.MapPath("~/log.txt"), DateTime.Now + "|" + result.ConvertEntityToXmlString() + "\r\n");

            return new RedirectResult("/");
        }
    }
}