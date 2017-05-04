using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yamon.Framework.Log4Net;


namespace Yamon.FileMonitor.Component
{
    public class FileServiceException
    {
       
        // Methods
        public static void HandleFileServiceException(Exception ex)
        {
            LogHelper.Error(ex.Message, ex);
        }

        public static void AddLog(string msg)
        {
            LogHelper.Info(msg);
        }
    }
}
