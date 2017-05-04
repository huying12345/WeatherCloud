using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.ServiceProcess;
using System.Text;
using Yamon.FileMonitor.Component;
using System.Threading;
using Yamon.Framework.Common;
using System.Windows.Forms;

namespace Yamon.FileMonitor.WindowsService
{
    public partial class MainService : ServiceBase
    {
        private readonly System.Timers.Timer timer1;
        MonitorFile _monitorFile;
        Thread _thread;
        readonly int _isMonitorLost = 1;
        readonly int _isMonitorFile = 1;
        public MainService()
        {
            InitializeComponent();
            _isMonitorLost = ConfigHelper.GetConfigInt("IsMonitorLost", 1);
            _isMonitorFile = ConfigHelper.GetConfigInt("IsMonitorFile", 1);
            timer1 = new System.Timers.Timer();
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            if (_isMonitorLost == 1)
            {
                Common.MonitorLost();
            }
            var runPlugIn = new RunPlugIn();
            runPlugIn.ScanFile();
        }

        void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _thread = new System.Threading.Thread(new System.Threading.ThreadStart(StartDownloadThreading));
            _thread.Start();
        }

        protected override void OnStart(string[] args)
        {
            if (_isMonitorFile == 1)
            {
                _monitorFile = new MonitorFile();
            }
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000 * 60 * 5;
            this.timer1.Start();
            timer1_Elapsed(null, null);
        }

        protected override void OnStop()
        {
           Application.Exit();
        }

        public void StartDownloadThreading()
        {
            if (_isMonitorLost == 1)
            {
                Common.MonitorLost();
            }
            Contant.FileList.Clear();
        }
    }
}
