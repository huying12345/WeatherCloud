
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.zdz.Entity
{
    /// <summary>
    /// 自动站站点实体类
    /// </summary>
    [Serializable]
    [Table("zdz_Station")]
    public partial class zdzStation
    {
        public zdzStation()
        { }

        #region Model

        
        /// <summary>
        /// 站点编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("站点编号")]
       public string StationID
        {
            set;
            get;
        }

        /// <summary>
        /// 站点名称
        /// </summary>
       [DisplayName("站点名称")]
       public string StationName
        {
            set;
            get;
        }

        /// <summary>
        /// 上级站点
        /// </summary>
       [DisplayName("上级站点")]
       public string ParentID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("上级站点")]
       public string ParentID_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 站点级别
        /// </summary>
       [DisplayName("站点级别")]
       public int? StationLevel
        {
            set;
            get;
        }

        /// <summary>
        /// 站点类型
        /// </summary>
       [DisplayName("站点类型")]
       public int? StationType
        {
            set;
            get;
        }

        /// <summary>
        /// 经度
        /// </summary>
       [DisplayName("经度")]
       public double? Latitude
        {
            set;
            get;
        }

        /// <summary>
        /// 纬度
        /// </summary>
       [DisplayName("纬度")]
       public double? Longitude
        {
            set;
            get;
        }

        /// <summary>
        /// 状态
        /// </summary>
       [DisplayName("状态")]
       public int? Status
        {
            set;
            get;
        }

        /// <summary>
        /// 海拔
        /// </summary>
       [DisplayName("海拔")]
       public string AltitudeHeight
        {
            set;
            get;
        }

        /// <summary>
        /// 排序号
        /// </summary>
       [DisplayName("排序号")]
       public int? OrderID
        {
            set;
            get;
        }

        /// <summary>
        /// 经度
        /// </summary>
       [DisplayName("经度")]
       public double? Lon
        {
            set;
            get;
        }

        /// <summary>
        /// 纬度
        /// </summary>
       [DisplayName("纬度")]
       public double? Lat
        {
            set;
            get;
        }


        #endregion Model

        //(TableTree)
            [Column(notMap:true)]
            [JsonProperty("children")]
            public List<zdzStation> Children
            {
             get;
             set;
            }
            [Column(notMap: true)]
            public int ChildCount
            {
                get;
                set;
            }
            
            
            [Column(notMap: true)]
            [JsonProperty("state")]
            public string State
            {
                get
                {
                    return ChildCount > 0 ? "closed" : "open";
                }
            }
    }
}
