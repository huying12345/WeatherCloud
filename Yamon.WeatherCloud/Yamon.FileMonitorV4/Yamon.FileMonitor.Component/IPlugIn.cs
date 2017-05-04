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
    public interface IPlugIn
    {
        /// <summary>
        /// 开始运行
        /// </summary>
        /// <param name="file"></param>
        void Run();
        /// <summary>
    }
}
