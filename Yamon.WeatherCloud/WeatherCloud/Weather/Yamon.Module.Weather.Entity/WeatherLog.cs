
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Weather.Entity
{
    /// <summary>
    /// 日志实体类
    /// </summary>
    [Serializable]
    [Table("Weather_Log")]
    public partial class WeatherLog
    {
        public WeatherLog()
        { }

        #region Model

        
        /// <summary>
        /// LogID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("LogID")]
       public int? LogID
        {
            set;
            get;
        }

        /// <summary>
        /// 类型编号
        /// </summary>
       [DisplayName("类型编号")]
       public int? NodeID
        {
            set;
            get;
        }

        /// <summary>
        /// 时间
        /// </summary>
       [DisplayName("时间")]
       public DateTime? LogTime
        {
            set;
            get;
        }

        /// <summary>
        /// 文件名称
        /// </summary>
       [DisplayName("文件名称")]
       public string FileName
        {
            set;
            get;
        }

        /// <summary>
        /// 说明
        /// </summary>
       [DisplayName("说明")]
       public string LogContent
        {
            set;
            get;
        }

        /// <summary>
        /// 是否成功 1 成功 0失败
        /// </summary>
       [DisplayName("是否成功 1 成功 0失败")]
       public int? IsSuccess
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("是否成功 1 成功 0失败")]
       public string IsSuccess_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 日志类型（1 操作日志，2未读入提醒日志）
        /// </summary>
       [DisplayName("日志类型（1 操作日志，2未读入提醒日志）")]
       public int? LogType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("日志类型（1 操作日志，2未读入提醒日志）")]
       public string LogType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 数据时间
        /// </summary>
       [DisplayName("数据时间")]
       public DateTime? DataTime
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("数据时间")]
       public string DataTime_ShowValue
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
