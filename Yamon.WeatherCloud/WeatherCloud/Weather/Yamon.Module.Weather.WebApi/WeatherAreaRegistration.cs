using System.Web.Mvc;
using Yamon.Module.SiteManage.DAL;

namespace Yamon.Module.Weather.WebApi
{
    public class WeatherAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Weather_WebApi";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Weather_WebApi_default",
                "api/Weather/{controller}/{action}/{id}",
                new { action = "Index", Controller = "WeatherDoc", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.Weather.WebApi" }
            );
            SiteCommon.AddPurview("Weather_WeatherNodes_SaveEditTree", "Weather_WeatherNodes_EditTree");
        }
    }
}