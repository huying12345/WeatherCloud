
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.zdz.Entity
{
    /// <summary>
    /// 一小时雨量实体类
    /// </summary>
    [Serializable]
    [Table("zdz_rain_hour")]
    public partial class zdzrainhour
    {
        public zdzrainhour()
        { }

        #region Model

        
        /// <summary>
        /// id
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("id")]
       public int? id
        {
            set;
            get;
        }

        /// <summary>
        /// 数据时次
        /// </summary>
       [DisplayName("数据时次")]
       public DateTime? date
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("数据时次")]
       public string date_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 站点
        /// </summary>
       [DisplayName("站点")]
       public string station
        {
            set;
            get;
        }

        /// <summary>
        /// 一小时降雨量
        /// </summary>
       [DisplayName("一小时降雨量")]
       public double? one_rain
        {
            set;
            get;
        }

        /// <summary>
        /// 数据时间
        /// </summary>
       [DisplayName("数据时间")]
       public DateTime? datatime
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("数据时间")]
       public string datatime_ShowValue
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
