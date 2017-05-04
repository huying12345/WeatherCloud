using System;
using System.Windows.Forms;
using Yamon.FileMonitor.Component;
using System.Collections;
using System.Threading;
using System.Text.RegularExpressions;

namespace Yamon.FileMonitor.WindowsService
{
    public partial class TestForm : Form
    {
        private System.Timers.Timer timer1;
        MonitorFile monitorFile;
        Thread thread;
        RunPlugIn runPlugIn;
        public TestForm()
        {
            InitializeComponent();
            timer1 = new System.Timers.Timer();
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            monitorFile = new MonitorFile();
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000 * 60 * 5;
            this.timer1.Start();
            timer1_Elapsed(null, null);
            runPlugIn = new RunPlugIn();
            runPlugIn.ScanFile();
            //AQIMonitor aqi = new AQIMonitor();
           // aqi.GetAllSiteData();
           // CopyZDZ copy = new CopyZDZ();
            //DateTime date = DateTime.ParseExact("Z58361_SEVP_C_BCSH_20130513210000_P_RFFC-SPCC-201305140000-07212.TXT", "Z58361_SEVP_C_BCSH_yyyyMMddHHmmss_P_RFFC-SPCC-201305140000-07212.TXT", new System.Globalization.CultureInfo("zh-CN"), System.Globalization.DateTimeStyles.AllowWhiteSpaces);
            //MessageBox.Show(date.ToString());
 
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
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //ArrayList arraylist = Common.GetAllNodeDataTime(int.Parse(this.textBox2.Text), DateTime.Now.Date, DateTime.Now);
            //this.textBox1.Text = "";
            //foreach (DateTime date in arraylist)
            //{
            //    this.textBox1.Text += date.ToString() + "\r\n";
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox5.Text = Common.ToDateTime(this.textBox3.Text, this.textBox4.Text).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Regex regFileName = new Regex(this.namerule.Text.ToLower());
            MessageBox.Show(regFileName.Match(this.fileName.Text.ToLower()).Success.ToString());
        }
    }
}
