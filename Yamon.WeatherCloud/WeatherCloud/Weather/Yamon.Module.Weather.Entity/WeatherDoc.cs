﻿
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Weather.Entity
{
    /// <summary>
    /// 文档实体类
    /// </summary>
    [Serializable]
    [Table("Weather_Doc")]
    public partial class WeatherDoc
    {
        public WeatherDoc()
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
        /// 类型名称
        /// </summary>
       [DisplayName("类型名称")]
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
        /// 路径
        /// </summary>
       [DisplayName("路径")]
       public string InfoPath
        {
            set;
            get;
        }

        /// <summary>
        /// Html内容
        /// </summary>
       [DisplayName("Html内容")]
       public string HtmlContent
        {
            set;
            get;
        }

        /// <summary>
        /// Txt内容
        /// </summary>
       [DisplayName("Txt内容")]
       public string TextContent
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
       [Column(notMap:true)]
       [DisplayName("入库时间")]
       public string CreateTime_ShowValue
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
       [Column(notMap:true)]
       [DisplayName("修改时间")]
       public string UpdateTime_ShowValue
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
