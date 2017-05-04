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
    public class CreateHtml : IPlugIn
    {
        Timer _timer;
        readonly string[] allCity = { "www", "sj", "pd", "js", "cm", "mh", "jd", "fx", "bs", "qp" };
        public void Run()
        {
            //CreateTopMenu();
            //CreateInfoTopN();
            _timer = new Timer();
            _timer.Interval = 1000 * 60 * 2;
            _timer.Enabled = true;
            _timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CreateWeatherEn();
            CreateTopMenu();
            CreateInfoTopN();
            CreateWeather();
        }
        public void CreateWeatherEn()
        {

                HttpHelper http = new HttpHelper();
                http.SetTimeOut(999999999);
                string url = "http://www.smb.gov.cn/CreateEnDistrict";
                http.Get(url);
                LogHelper.Info("正在生成" + url);
            
        }
        public void CreateTopMenu()
        {
            for (int i = 0; i < allCity.Length; i++)
            {
                HttpHelper http = new HttpHelper();
                http.SetTimeOut(999999999);
                string url = string.Format("http://{0}.smb.gov.cn/CreateTopMenu?top=10", allCity[i]);
                http.Get(url);
                LogHelper.Info("正在生成" + url);
            }
        }

        public void CreateInfoTopN()
        {
            for (int i = 0; i < allCity.Length; i++)
            {
                HttpHelper http = new HttpHelper();
                http.SetTimeOut(999999999);
                string url = string.Format("http://{0}.smb.gov.cn/CreateInfoTopN?top=50", allCity[i]);
                http.Get(url);
                LogHelper.Info("正在生成" + url);
            }
        }
        public void CreateWeather()
        {
            for (int i = 0; i < allCity.Length; i++)
            {
                HttpHelper http = new HttpHelper();
                http.SetTimeOut(999999999);
                string url = string.Format("http://{0}.smb.gov.cn/CreateWeather", allCity[i]);
                http.Get(url);
                LogHelper.Info("正在生成" + url);
            }
        }

    }
}
