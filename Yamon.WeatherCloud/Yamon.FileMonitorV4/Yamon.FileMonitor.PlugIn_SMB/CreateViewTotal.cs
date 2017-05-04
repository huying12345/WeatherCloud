using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Yamon.FileMonitor.Component;
using Yamon.Framework.Common;
using Yamon.Framework.Log4Net;

namespace Yamon.FileMonitor.PlugIn_SMB
{
    public class CreateViewTotal : IPlugIn
    {
        Timer _timer;

        public void Run()
        {

            _timer = new Timer();
            _timer.Interval = 1000 * 60;
            _timer.Enabled = true;
            _timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour == 0 && DateTime.Now.Minute == 10)
            {
                CreateExecuteViewTotalAction();
            }
        }

        public void CreateExecuteViewTotalAction()
        {
            HttpHelper http = new HttpHelper();
            http.SetTimeOut(999999999);
            string url = "http://192.168.160.122:82/SiteStatShow/Stat/ExecuteViewTotalAction";
            http.Get(url);
            LogHelper.Info("正在生成" + url);
        }


    }
}
