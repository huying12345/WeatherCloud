using System.Web.Mvc;

namespace Yamon.Module.zdz.Web.Controllers
{
    public class zdzAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "zdz";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "zdz_default",
                "zdz/{controller}/{action}/{id}",
                new { action = "Index", Controller = "zdzinstant", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.zdz.Web.Controllers" }
            );
        }
    }
}