﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using Yamon.Framework.MVC;
using Yamon.Module.SiteManage;
using Yamon.Module.OnePublish.DAL;
using Yamon.Monitor.WeixinMP.CommonService;


namespace Yamon.WeatherCloud.WebSite
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private bool _isSendSms = false;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.DefaultBinder = new MyModelBinder();

            //清空运行时目录
            IOHelper.Delete(AppDomain.CurrentDomain.BaseDirectory + "Runtime", FsoMethod.Folder);


            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
            JsonConvert.DefaultSettings = new Func<JsonSerializerSettings>(() =>
            {
                //日期类型默认格式化处理
                setting.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
                setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";

                //空值处理
                setting.NullValueHandling = NullValueHandling.Ignore;

                //高级用法九中的Bool类型转换 设置
                //setting.Converters.Add(new BoolConvert("是,否"));

                return setting;
            });

            //发送邮件及其它
            System.Timers.Timer timerInfo = new System.Timers.Timer(1000 * 60);
            timerInfo.AutoReset = true;
            timerInfo.Enabled = true;
            timerInfo.Elapsed += timerInfo_Elapsed;

        }



        void timerInfo_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            SendListDAL sendDal = new SendListDAL();
            sendDal.UpdateSendStatus();
            if (ConfigHelper.GetConfigInt("IsSend_EMAIL", 1) == 1)
            {
                sendDal.MailSend();
            }
            if (ConfigHelper.GetConfigInt("IsSend_WEIXIN", 1) == 1)
            {
                SendMessage.SendWeiXinMsg();
            }
            if (ConfigHelper.GetConfigInt("IsSend_FTP", 1) == 1)
            {
                sendDal.FTPSend();
            }
            sendDal.UpdateSendStatus();
        }
    }
}