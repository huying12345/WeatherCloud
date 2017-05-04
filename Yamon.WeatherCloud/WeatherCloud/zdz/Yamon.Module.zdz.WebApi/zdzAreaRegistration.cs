using System.Web.Mvc;

namespace Yamon.Module.zdz.WebApi
{
    public class zdzAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "zdz_WebApi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "zdz_WebApi_default",
                "api/zdz/{controller}/{action}/{id}",
                new { action = "Index", Controller = "zdzinstant", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.zdz.WebApi" }
            );
        }
    }
}