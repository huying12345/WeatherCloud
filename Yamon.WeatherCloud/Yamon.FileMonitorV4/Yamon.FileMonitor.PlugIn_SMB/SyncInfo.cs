using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Timers;
using Yamon.FileMonitor.Component;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using Yamon.Framework.DBUtility;

namespace Yamon.FileMonitor.PlugIn_SMB
{
    public class SyncInfo : IPlugIn
    {
        Timer _timer;
        public void Run()
        {
            SyncBK();
            SyncVideo();
            _timer = new Timer();
            _timer.Interval = 1000 * 60 * 60;
            _timer.Enabled = true;
            _timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SyncBK();
            SyncVideo();
        }

        public void SyncBK()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "SyncBK.txt";
            DateTime lastCreateTime = DataConverter.ToDate(IOHelper.ReadFile(filePath));
            DataTable infoList =
                  DbHelper.GetConn("SoWeather_PortalIPS").ExecuteDataTableSql("select * from vwInfoCategory where Status='AUDITED' AND CategoryID='D4982A3D-5805-46A3-9214-4740DB0A6039' AND CreateTime>'" + lastCreateTime.ToString("yyyy-MM-dd HH:mm:ss") + "' order by CreateTime");
            HttpHelper http = new HttpHelper();
            string url = "http://192.168.160.122:82/PortalIPS/Info/QuickInsert";
            foreach (DataRow info in infoList.Rows)
            {
                MyNameValueCollection nv = new MyNameValueCollection();
                nv.Set("AppID", "sh");
                nv.Set("CategoryID", "5981e5c9-db69-46ec-86f8-def117d096b4");
                // nv.Add("InfoGuid", info["InfoGuid"].ToString());
                nv.Add("InfoGuid", Guid.NewGuid().ToString());
                nv.Add("Title", info["Title"].ToString());
                nv.Add("InfoType", "CommonInfo");
                nv.Add("Status", "AUDITED");
                nv.Add("Source", info["Source"].ToString());
                if (!string.IsNullOrEmpty(info["MediaFileName"].ToString()))
                {
                    nv.Set("MediaFileName", "http://www.soweather.com/" + info["MediaFileName"].ToString());
                }
                nv.Set("ShowTime", info["ShowTime"].ToString());
                nv.Set("Content", StringHelper.UrlEncode(info["Content"].ToString().Replace(" src=\"/upload/", " src=\"http://www.soweather.com/upload/")));

                StringBuilder sb = new StringBuilder();
                foreach (string s in nv.AllKeys)
                {
                    sb.Append(s);
                    sb.Append("=");
                    sb.Append(nv[s]);
                    sb.Append("&");
                }
                string content = http.Post(url, sb.ToString());
                content = content;
                IOHelper.WriteFile(filePath, info["CreateTime"].ToString());
            }
        }

        public void SyncVideo()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "SyncVideo.txt";
            int lastVideoId = DataConverter.ToInt(IOHelper.ReadFile(filePath), 10000000);
            DataTable infoList =
                  DbHelper.GetConn("SoWeather_ExpoWeather").ExecuteDataTableSql("select * from sw_Video where vID>" + lastVideoId);
            HttpHelper http = new HttpHelper();
            string url = "http://192.168.160.122:82/PortalIPS/Info/QuickInsert";
            foreach (DataRow info in infoList.Rows)
            {
                MyNameValueCollection nv = new MyNameValueCollection();
                nv.Add("AppID", "sh");
                nv.Add("CategoryID", "d562c456-c1cc-4c3e-bba5-c0aacad07453");
                nv.Add("Title", info["vTitle"].ToString());
                nv.Add("Content", info["vDes"].ToString());
                nv.Add("InfoType", "VideoInfo");
                nv.Add("Status", "AUDITED");
                nv.Add("InfoGuid", Guid.NewGuid().ToString());
                nv.Add("MediaFileName", "http://www.soweather.com/" + info["vPic"].ToString());
                nv.Add("ShowTime", info["vCreateTime"].ToString());
                nv.Add("VideoUrl", "http://www.soweather.com" + info["vSource"].ToString());

                StringBuilder sb = new StringBuilder();
                foreach (string s in nv.AllKeys)
                {
                    sb.Append(s);
                    sb.Append("=");
                    sb.Append(nv[s]);
                    sb.Append("&");
                }
                http.Post(url, sb.ToString());
                IOHelper.WriteFile(filePath, info["vID"].ToString());
            }
        }
    }
}
