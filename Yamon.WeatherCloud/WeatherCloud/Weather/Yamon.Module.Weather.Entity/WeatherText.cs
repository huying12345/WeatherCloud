
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Weather.Entity
{
    /// <summary>
    /// 文本实体类
    /// </summary>
    [Serializable]
    [Table("Weather_Text")]
    public partial class WeatherText
    {
        public WeatherText()
        { }

        #region Model

        
        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("ID")]
       public int? ID
        {
            set;
            get;
        }

        /// <summary>
        /// 标题
        /// </summary>
       [DisplayName("标题")]
       public string InfoTitle
        {
            set;
            get;
        }

        /// <summary>
        /// 类型编号
        /// </summary>
       [DisplayName("类型编号")]
       public int? InfoTypeID
        {
            set;
            get;
        }

        /// <summary>
        /// 内容
        /// </summary>
       [DisplayName("内容")]
       public string InfoDetail
        {
            set;
            get;
        }

        /// <summary>
        /// 数据时次
        /// </summary>
       [DisplayName("数据时次")]
       public DateTime? DataTime
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("数据时次")]
       public string DataTime_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 入库时间
        /// </summary>
       [DisplayName("入库时间")]
       public DateTime? CreateTime
        {
            set;
            get;
        }

        /// <summary>
        /// 修改时间
        /// </summary>
       [DisplayName("修改时间")]
       public DateTime? UpdateTime
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
