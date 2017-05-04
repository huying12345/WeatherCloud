using System.Web.Mvc;
using Yamon.Module.SiteManage.DAL;

namespace Yamon.Module.WeiXin.Web
{
    public class WeiXinAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "WeiXin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "WeiXin_default",
                "WeiXin/{controller}/{action}/{id}",
                new { action = "Index", Controller = "WeiXinGroup", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.WeiXin.Web.Controllers" }
            );
        }
    }
}