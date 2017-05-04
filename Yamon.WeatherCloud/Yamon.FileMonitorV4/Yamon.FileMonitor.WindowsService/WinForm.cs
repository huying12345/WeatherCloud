using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Yamon.FileMonitor.Component;
using Yamon.Framework.Common;
using Yamon.Framework.Log4Net;

namespace Yamon.FileMonitor.WindowsService
{
    public partial class WinForm : Form
    {
        private System.Timers.Timer timer1;
        MonitorFile monitorFile;
        Thread thread;
        RunPlugIn runPlugIn;
        public WinForm()
        {
            InitializeComponent();
            try
            {
                //  Common.MonitorLost();
                //timer1 = new System.Timers.Timer();
                //this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
                runPlugIn = new RunPlugIn();//插件
                runPlugIn.ScanFile();

               monitorFile = new MonitorFile();//入库
                //this.timer1.Enabled = true;
                //this.timer1.Interval = 1000 * 60 * 5;
                //this.timer1.Start();
                //timer1_Elapsed(null, null);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                MessageBox.Show(ex.Message);
            }


            /*HttpHelper httpHlper = new HttpHelper();
           httpHlper.SetEncoding(Encoding.Default);
           string content =httpHlper.Post("http://61.152.218.209:8080/sjqxj/loginAction.do?method=login", "userName=hwp_qxjxxwh&password=hwp123456");
           content = content;*/
        }

        void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            thread = new System.Threading.Thread(new System.Threading.ThreadStart(StartDownloadThreading));
            thread.Start();
        }


        public void StartDownloadThreading()
        {
            FileServiceException.AddLog("开始查询漏传产品");
            Common.MonitorLost();
            Contant.FileList.Clear();
        }
    }
}
