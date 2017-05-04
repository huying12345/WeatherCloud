using System.Web.Mvc;

namespace Yamon.Module.Typhoon.WebApi
{
    public class TyphoonAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Typhoon_WebApi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Typhoon_WebApi_default",
                "api/Typhoon/{controller}/{action}/{id}",
                new { action = "Index", Controller = "TyphoonInfo", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.Typhoon.WebApi" }
            );
        }
    }
}