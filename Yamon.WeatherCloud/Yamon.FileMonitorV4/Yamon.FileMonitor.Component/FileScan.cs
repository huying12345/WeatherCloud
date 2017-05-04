using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Yamon.Framework.Common;
using System.Diagnostics;
using System.Collections;
using Yamon.Framework.Log4Net;

namespace Yamon.FileMonitor.Component
{
    //委托
    public delegate void dDownloadProgress(long total, long current);
    public delegate void dDownloadInfo(string infoMsg);
    public delegate void MyErrorHandler(string errMsg);
    public class FileScan
    {
        //事件
        public event dDownloadProgress onDownLoadProgress;
        public event dDownloadInfo onDownLoadInfo;
        public event MyErrorHandler myErrorEvent;
        // Methods
        public void ExcuteDll(FileInfo fiExternalDll)
        {
            Assembly assemblyExternalDll = Assembly.LoadFile(fiExternalDll.FullName);
            Type[] types = null;
            try
            {
                types = assemblyExternalDll.GetTypes();
            }
            catch
            {
            }
            if (types != null)
            {
                foreach (Type type in types)
                {
                    if (type.GetInterface(typeof(IFileExec).FullName) != null)
                    {
                        ExcuteFile(type, assemblyExternalDll);
                    }
                }
            }
        }

        public void ExcuteFile(Type typeIFileExec, Assembly assemblyExternalDll)
        {
            IFileExec ifeInstance = assemblyExternalDll.CreateInstance(typeIFileExec.FullName) as IFileExec;
            try
            {
                foreach (string regString in ifeInstance.GetFileNameRegxp())
                {
                    Regex regFileName = new Regex(regString.ToLower());
                    FileInfo[] fiNeedExcuteFiles = Common.GetFileInfos(Common.TempSourceFileDirectory);
                    if (fiNeedExcuteFiles == null)
                    {
                        return;
                    }
                    int i = 0;
                    foreach (FileInfo fiNeedExcuteFile in fiNeedExcuteFiles)
                    {
                        i++;
                        if (onDownLoadProgress != null)
                        {
                            onDownLoadProgress(fiNeedExcuteFiles.Length, i);
                        }
                        if (regFileName.Match(fiNeedExcuteFile.Name.ToLower()).Success)
                        {
                            if (Contant.FileList.Contains(fiNeedExcuteFile.Name))
                            {
                                continue;
                            }
                            Contant.FileList.Add(fiNeedExcuteFile.Name);
                            int nodeId = 0;
                            string backFileName = ifeInstance.ExecFile(fiNeedExcuteFile, out nodeId);
                            Contant.FileList.Remove(fiNeedExcuteFile.Name);
                            if (Common.BackFile)
                            {
                                if (!string.IsNullOrEmpty(backFileName))
                                {
                                    Common.BackupFile(fiNeedExcuteFile, ifeInstance.GetBackupPath(), backFileName);
                                    if (nodeId > 0)
                                    {
                                        Common.SendFile(nodeId, ifeInstance.GetBackupPath(), backFileName);
                                    }
                                }
                                else
                                {
                                    Common.ErrorBackupFile(fiNeedExcuteFile, ifeInstance.GetBackupPath());
                                }
                            }
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                FileServiceException.HandleFileServiceException(ex);
            }
        }

        public void ScanFile()
        {

            if (!Common.IsExecute)
            {
                LogHelper.Error("开始文件处理");
                Common.IsExecute = true;
                //EventLog.WriteEntry("SMB Service", "Scan");
                //Yamon.FileMonitor.SM\\w{1,10}.(.dll)$
                FileInfo[] fiExternalDlls = Common.GetFileInfos(AppDomain.CurrentDomain.BaseDirectory, "Yamon.FileMonitor.SMB*.dll");
                if (fiExternalDlls != null)
                {
                    foreach (FileInfo fiExternalDll in fiExternalDlls)
                    {
                        ExcuteDll(fiExternalDll);
                    }
                }
                Common.IsExecute = false;
            }
            else
            {
                LogHelper.Error("尚有文件未处理完，本次跳过！");
            }
        }

    }
}
