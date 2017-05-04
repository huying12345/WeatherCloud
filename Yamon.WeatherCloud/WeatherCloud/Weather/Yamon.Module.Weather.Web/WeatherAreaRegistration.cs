using System.Web.Mvc;
using Yamon.Module.SiteManage.DAL;

namespace Yamon.Module.Weather
{
    public class WeatherAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Weather";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Weather_default",
                "Weather/{controller}/{action}/{id}",
                new { action = "Index", Controller = "WeatherDoc", id = UrlParameter.Optional },
                new string[] { "Yamon.Module.Weather.Web.Controllers" }
            );

            //计划任务
            SiteCommon.AddPurview("SiteManage_SubPlan_Create", new[]
            {
                "Weather_WeatherNodes_Create", 
                "Weather_WeatherNodes_Edit" 
            
            });
            SiteCommon.AddPurview("SiteManage_SubPlan_Edit", new[]
            {
                "Weather_WeatherNodes_Create",
                "Weather_WeatherNodes_Edit"
            });
            SiteCommon.AddPurview("SiteManage_SubPlan_Show", new[]
            {
                "Weather_WeatherNodes_Create",
                "Weather_WeatherNodes_Edit"
            });

        }

     
    }
}