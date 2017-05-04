using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Yamon.Framework.Common;
using System.Data;
using Yamon.Framework.Common.IO;

namespace Yamon.FileMonitor.Component
{
    public class MonitorFile
    {
        private FileSystemWatcher fileSystemWatcher1;
        private System.Timers.Timer timer1;
        private FileScan fileScan;
        public MonitorFile()
        {
            fileScan = new FileScan();
            this.fileSystemWatcher1 = new FileSystemWatcher();
            this.fileSystemWatcher1.Path = ConfigHelper.GetConfigString("SourceFileDirectory");
            this.fileSystemWatcher1.BeginInit();
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.IncludeSubdirectories = true;
            fileSystemWatcher1.Filter = "*.*";
            this.fileSystemWatcher1.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Changed += new FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.EndInit();
            timer1 = new System.Timers.Timer();
            timer1.Enabled = true;
            timer1.Interval = 60 * 1000;
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            fileScan.ScanFile();
        }

        void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            fileScan.ScanFile();
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                DataTable fileInfo = IOHelper.GetDirectoryAllInfos(ConfigHelper.GetConfigString("SourceFileDirectory"), FsoMethod.File);
                foreach (DataRow file in fileInfo.Rows) {
                    try
                    {

                        new FileStream(file["rname"].ToString(), FileMode.Open, FileAccess.Write).Close();
                        string sTempPath = Path.Combine(Common.TempSourceFileDirectory, file["name"].ToString());
                        if (DataConverter.ToInt(file["size"]) > 0)
                        {
                            File.Copy(file["rname"].ToString(), sTempPath, true);
                        }
                        File.Delete(file["rname"].ToString());
                    }
                    catch (Exception ex)
                    {
                        //FileServiceException.HandleFileServiceException(ex);
                    }
                }

                //无子目录的情况
                //FileInfo[] fiNeedExcuteFiles = Common.GetFileInfos(ConfigHelper.GetConfigString("SourceFileDirectory"));
                //foreach (FileInfo fiNeedExcuteFile in fiNeedExcuteFiles)
                //{
                //    try
                //    {
                //        FileServiceException.AddLog(fiNeedExcuteFile.FullName);
                //        new FileStream(fiNeedExcuteFile.FullName, FileMode.Open, FileAccess.Write).Close();
                //        string sTempPath = Path.Combine(Common.TempSourceFileDirectory, fiNeedExcuteFile.Name);
                //        if (fiNeedExcuteFile.Length > 0)
                //        {
                //            File.Copy(fiNeedExcuteFile.FullName, sTempPath, true);
                //        }
                //        File.Delete(fiNeedExcuteFile.FullName);
                //    }
                //    catch (Exception ex) {
                //        //FileServiceException.HandleFileServiceException(ex);
                //    }
                //}
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                //FileServiceException.HandleFileServiceException(ex);
                timer1.Enabled = true;
            }
        }
    }
}
