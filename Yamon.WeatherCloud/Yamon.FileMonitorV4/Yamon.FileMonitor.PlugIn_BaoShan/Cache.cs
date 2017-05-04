using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Timers;
using Yamon.FileMonitor.Component;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;

namespace Yamon.FileMonitor.PlugIn_BaoShan
{
    public class Cache : IPlugIn
    {
        Timer timer;
        Timer timer2;
        Timer timer1min;

        bool isrun = true;
        bool isrun2 = true;
        bool isrun1min = true;
        int thStepCount = 5; 
        

        public void Run()
        {
            timer = new Timer();
            timer.Interval = 1000 * 60 * 5;
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);

            timer2 = new Timer();
            timer2.Interval = 1000 * 60 * 10;
            timer2.Enabled = true;
            timer2.Elapsed += new ElapsedEventHandler(timer2_Elapsed);

            timer1min = new Timer();
            timer1min.Interval = 1000 * 60 * 1;
            timer1min.Enabled = true;
            timer1min.Elapsed += new ElapsedEventHandler(timer1min_Elapsed);

        }
        string filePath = "";

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isrun)
            {
                isrun = false;
                try
                {
                    string webApiUrl = ConfigHelper.GetConfigString("WebApiUrl").TrimEnd('/');
                    DateTime stratTime = DateTime.Now;
                    filePath = AppDomain.CurrentDomain.BaseDirectory + "Cache\\CacheLog" + DateTime.Now.ToString("yyyyMMdd") + ".txt";//详细日志
                    //记录日志
                    IOHelper.WriteAppend(filePath, stratTime.ToString("yyyy-MM-dd HH:mm:ss") + " Cache运行中(5分钟每次)...\r\n");

                    //api/Weather/WeatherNodes/TreeGrid?
                    //获取所有成功接入的数据
                    string urlTemp="/api/Weather/WeatherNodes/GetDataAccessList";
                    string result = WebApiHelper.Post(urlTemp, null, "");

                    JObject job = JsonConvert.DeserializeObject<JObject>(result);

                    if (!DataConverter.ToBoolean(job["success"].ToString()))
                    {
                        IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Cache运行失败！" + job["message"] + "\r\n");
                        return;
                    }
                    DataTable data = JsonConvert.DeserializeObject<DataTable>(job["data"].ToString());

                    ArrayList listYD = new ArrayList();
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        urlTemp = "";
                        result = "";
                        int nodeId = DataConverter.ToInt(data.Rows[i]["NodeID"], 0);
                        int nodeType = DataConverter.ToInt(data.Rows[i]["NodeType"]);
                        string nodeName = data.Rows[i]["NodeName"].ToString();
                        try
                        {
                            if (nodeType == 2 || nodeType == 1 || nodeType == 8)//图片、文档、文本
                            {
                                urlTemp = string.Format("/api/Weather/WeatherImg/GetDataList/{0}", nodeId);
                                listYD.Add(urlTemp + "$" + nodeName);
                            }
                        }
                        catch (Exception ex)
                        {
                            IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + nodeName + "：" + ex.Message + "\r\n");
                        }
                    }

                    //
                    if (listYD.Count >= thStepCount)
                    {
                        int len = listYD.Count / thStepCount;
                        int lens = len;
                        for (int i = 0; i < thStepCount; i++)
                        {
                            lens = len;
                            if (i == 4)
                            {
                                lens = listYD.Count - (len * 4);
                            }
                            ThreadTest ttyd1 = new ThreadTest(listYD.GetRange(i * len, lens));
                            new System.Threading.Thread(ttyd1.ThreadProc).Start();
                        }
                    }
                    else
                    {
                        ThreadTest ttyd1 = new ThreadTest(listYD.GetRange(0, listYD.Count));
                        new System.Threading.Thread(ttyd1.ThreadProc).Start();
                    }

                }
                catch (Exception ex)
                {
                    IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Cache运行失败！" + ex.Message + "\r\n");
                }
                isrun = true;
            }
        }


        void timer2_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isrun2)
            {
                isrun2 = false;
                try
                {
                    string webApiUrl = ConfigHelper.GetConfigString("WebApiUrl").TrimEnd('/');
                    string webApiUrlList = ConfigHelper.GetConfigString("WebApiUrlListMin_10");
                    string[] apiUrlList = webApiUrlList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    DateTime stratTime = DateTime.Now;
                    filePath = AppDomain.CurrentDomain.BaseDirectory + "Cache\\apiUrlList" + DateTime.Now.ToString("yyyyMMdd") + ".txt";//详细日志
                    //记录日志
                    IOHelper.WriteAppend(filePath, stratTime.ToString("yyyy-MM-dd HH:mm:ss") + " apiUrlList运行中(10分钟每次)...\r\n");

                    string urlTemp = "";
                    string result = "";

                    for (int i = 0; i < apiUrlList.Length; i++)
                    {
                        try
                        {
                            urlTemp = apiUrlList[i];
                            result = WebApiHelper.Post(urlTemp, null, "&isCreate=1");
                            //记录日志
                            IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + urlTemp + "：执行完成！\r\n");
                        }
                        catch (Exception ex)
                        {
                            IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + urlTemp + "：执行失败！" + ex.Message + "\r\n");
                        }
                    }

                    //时间处理
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts1 = new TimeSpan(stratTime.Ticks);
                    TimeSpan ts2 = new TimeSpan(endTime.Ticks);
                    TimeSpan ts = ts1.Subtract(ts2).Duration();
                    string caCheLog =
                     "apiUrlList运行完成！运行时间：（" + ts.TotalSeconds.ToString() + "秒）";
                    //记录日志
                    IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + caCheLog + "\r\n");
                }
                catch (Exception ex)
                {
                    IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " apiUrlList(10分钟每次)运行失败！" + ex.Message + "\r\n");
                }
                isrun2 = true;
            }
        }

        void timer1min_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isrun1min)
            {
                isrun1min = false;
                try
                {
                    string webApiUrl = ConfigHelper.GetConfigString("WebApiUrl1").TrimEnd('/');
                    string webApiUrlList = ConfigHelper.GetConfigString("WebApiUrlListMin_1");
                    string[] apiUrlList = webApiUrlList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    DateTime stratTime = DateTime.Now;
                    filePath = AppDomain.CurrentDomain.BaseDirectory + "Cache\\apiUrlList" + DateTime.Now.ToString("yyyyMMdd") + ".txt";//详细日志
                    //记录日志
                    IOHelper.WriteAppend(filePath, stratTime.ToString("yyyy-MM-dd HH:mm:ss") + " apiUrlList运行中(1分钟每次)...\r\n");

                    string urlTemp = "";
                    string result = "";

                    for (int i = 0; i < apiUrlList.Length; i++)
                    {
                        try
                        {
                            urlTemp = apiUrlList[i];
                            result = WebApiHelper.Post(urlTemp, null, "&isCreate=1");
                            //记录日志
                            IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + urlTemp + "：执行完成！\r\n");
                        }
                        catch (Exception ex)
                        {
                            IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + urlTemp + "：执行失败！" + ex.Message + "\r\n");
                        }
                    }

                    //时间处理
                    DateTime endTime = DateTime.Now;
                    TimeSpan ts1 = new TimeSpan(stratTime.Ticks);
                    TimeSpan ts2 = new TimeSpan(endTime.Ticks);
                    TimeSpan ts = ts1.Subtract(ts2).Duration();
                    string caCheLog =
                     "apiUrlList运行完成！运行时间：（" + ts.TotalSeconds.ToString() + "秒）";
                    //记录日志
                    IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + caCheLog + "\r\n");
                }
                catch (Exception ex)
                {
                    IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " apiUrlList(1分钟每次)运行失败！" + ex.Message + "\r\n");
                }
                isrun1min = true;
            }
        }

       
    }


    public class ThreadTest
    {
        private readonly ArrayList _list;

        public ThreadTest(ArrayList listt)
        {
            _list = listt;
        }

        public void ThreadProc()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Cache\\CacheLog" + DateTime.Now.ToString("yyyyMMdd") + ".txt";//详细日志

            foreach (var item in _list)
            {
                string[] list = item.ToString().Split('$');
                try
                {
                    DateTime startTime = DateTime.Now;
                    
                    string result = WebApiHelper.Post(list[0], null, "&isCreate=1");
                    //记录日志
                    IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + list[1] + "：执行完成！\r\n");

                    DateTime endTime = DateTime.Now;
                    TimeSpan timeSpan = new TimeSpan(endTime.Ticks - startTime.Ticks);
                    if (timeSpan.TotalMilliseconds < 1000)
                    {
                        System.Threading.Thread.Sleep((int)(1000 - timeSpan.TotalMilliseconds));
                    }
                }
                catch (Exception ex)   
                {
                    IOHelper.WriteAppend(filePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + list[1] + "：执行失败！" + ex.Message + "\r\n");
                }
            }
        }
    }
}
