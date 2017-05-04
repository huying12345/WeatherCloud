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

    public class RunPlugIn
    {

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
                    if (type.GetInterface(typeof(IPlugIn).FullName) != null)
                    {
                        ExcuteFile(type, assemblyExternalDll);
                    }
                }
            }
        }

        public void ExcuteFile(Type typeIFileExec, Assembly assemblyExternalDll)
        {
            IPlugIn ifeInstance = assemblyExternalDll.CreateInstance(typeIFileExec.FullName) as IPlugIn;
            try
            {
                ifeInstance.Run();
            }
            catch (Exception ex)
            {
                FileServiceException.HandleFileServiceException(ex);
            }
        }

        public void ScanFile()
        {
            FileInfo[] fiExternalDlls = Common.GetFileInfos(AppDomain.CurrentDomain.BaseDirectory, "Yamon.FileMonitor.PlugIn_*.dll");
            if (fiExternalDlls != null)
            {
                foreach (FileInfo fiExternalDll in fiExternalDlls)
                {
                    ExcuteDll(fiExternalDll);
                }
            }
        }

    }
}
