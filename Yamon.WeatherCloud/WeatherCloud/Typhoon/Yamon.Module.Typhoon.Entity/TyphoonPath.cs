
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Typhoon.Entity
{
    /// <summary>
    /// 台风路径实体类
    /// </summary>
    [Serializable]
    [Table("Typhoon_Path")]
    public partial class TyphoonPath
    {
        public TyphoonPath()
        { }

        #region Model

        
        /// <summary>
        /// 路径编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("路径编号")]
       public long? ID
        {
            set;
            get;
        }

        /// <summary>
        /// 台风编号
        /// </summary>
       [DisplayName("台风编号")]
       public string TyphoonID
        {
            set;
            get;
        }

        /// <summary>
        /// 台风时间
        /// </summary>
       [DisplayName("台风时间")]
       public DateTime? PathTime
        {
            set;
            get;
        }

        /// <summary>
        /// 台风中心经度
        /// </summary>
       [DisplayName("台风中心经度")]
       public double? Longitude
        {
            set;
            get;
        }

        /// <summary>
        /// 台风中心纬度
        /// </summary>
       [DisplayName("台风中心纬度")]
       public double? Latitude
        {
            set;
            get;
        }

        /// <summary>
        /// 时效
        /// </summary>
       [DisplayName("时效")]
       public int? Hours
        {
            set;
            get;
        }

        /// <summary>
        /// 中心气压
        /// </summary>
       [DisplayName("中心气压")]
       public double? CenterAirPressure
        {
            set;
            get;
        }

        /// <summary>
        /// 最大风速
        /// </summary>
       [DisplayName("最大风速")]
       public double? MaxWindSpeed
        {
            set;
            get;
        }

        /// <summary>
        /// 移动方向
        /// </summary>
       [DisplayName("移动方向")]
       public int? MoveHeading
        {
            set;
            get;
        }

        /// <summary>
        /// 移动速度
        /// </summary>
       [DisplayName("移动速度")]
       public double? MoveSpeeding
        {
            set;
            get;
        }

        /// <summary>
        /// 台风中心七级半径
        /// </summary>
       [DisplayName("台风中心七级半径")]
       public double? CenterSevenRadius
        {
            set;
            get;
        }

        /// <summary>
        /// 台风中心十级半径
        /// </summary>
       [DisplayName("台风中心十级半径")]
       public double? CenterTenRadius
        {
            set;
            get;
        }

        /// <summary>
        /// ReportCenter
        /// </summary>
       [DisplayName("ReportCenter")]
       public string ReportCenter
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
