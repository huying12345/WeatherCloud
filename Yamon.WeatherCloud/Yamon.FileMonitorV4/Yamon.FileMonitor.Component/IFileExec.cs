using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Yamon.FileMonitor.Component
{
    /// <summary>
    /// 文件处理规则
    /// </summary>
    public interface IFileExec
    {
        /// <summary>
        /// 处理文件,返回备份的文件名
        /// </summary>
        /// <param name="file"></param>
        string ExecFile(FileInfo file, out int nodeId);
        /// <summary>
        /// 获取备份路径
        /// </summary>
        /// <returns></returns>
        string GetBackupPath();

        /// <summary>
        /// 获取文件名规则
        /// </summary>
        /// <returns></returns>
        string[] GetFileNameRegxp();
    }
}
