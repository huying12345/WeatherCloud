using System.Web.Mvc;

namespace Yamon.Module.Typhoon.Web.Controllers
{
    public class TyphoonAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Typhoon";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Typhoon_default",
                "Typhoon/{controller}/{action}/{id}",
                new { action = "Index", Controller = "TyphoonInfo", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.Typhoon.Web.Controllers" }
            );
        }
    }
}