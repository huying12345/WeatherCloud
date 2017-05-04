
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.zdz.Entity
{
    /// <summary>
    /// 自动站数据实体类
    /// </summary>
    [Serializable]
    [Table("zdz_instant")]
    public partial class zdzinstant
    {
        public zdzinstant()
        { }

        #region Model

        
        /// <summary>
        /// 编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("编号")]
       public int? ID
        {
            set;
            get;
        }

        /// <summary>
        /// 站名
        /// </summary>
       [DisplayName("站名")]
       public double? station
        {
            set;
            get;
        }

        /// <summary>
        /// 太阳辐射
        /// </summary>
       [DisplayName("太阳辐射")]
       public double? sun_rad
        {
            set;
            get;
        }

        /// <summary>
        /// 平均太阳辐射
        /// </summary>
       [DisplayName("平均太阳辐射")]
       public double? aver_rad
        {
            set;
            get;
        }

        /// <summary>
        /// 最高太阳辐射
        /// </summary>
       [DisplayName("最高太阳辐射")]
       public double? max_rad
        {
            set;
            get;
        }

        /// <summary>
        /// 最高太阳辐射时间
        /// </summary>
       [DisplayName("最高太阳辐射时间")]
       public string max_rad_time
        {
            set;
            get;
        }

        /// <summary>
        /// uv
        /// </summary>
       [DisplayName("uv")]
       public double? uv
        {
            set;
            get;
        }

        /// <summary>
        /// aver_uv
        /// </summary>
       [DisplayName("aver_uv")]
       public double? aver_uv
        {
            set;
            get;
        }

        /// <summary>
        /// max_uv
        /// </summary>
       [DisplayName("max_uv")]
       public double? max_uv
        {
            set;
            get;
        }

        /// <summary>
        /// max_uv_time
        /// </summary>
       [DisplayName("max_uv_time")]
       public string max_uv_time
        {
            set;
            get;
        }

        /// <summary>
        /// 能见度
        /// </summary>
       [DisplayName("能见度")]
       public string instant_vis
        {
            set;
            get;
        }

        /// <summary>
        /// 十分钟平均能见度
        /// </summary>
       [DisplayName("十分钟平均能见度")]
       public string ten_aver_vis
        {
            set;
            get;
        }

        /// <summary>
        /// 两分钟平均风向
        /// </summary>
       [DisplayName("两分钟平均风向")]
       public double? two_aver_wd
        {
            set;
            get;
        }

        /// <summary>
        /// 两分钟平均风力
        /// </summary>
       [DisplayName("两分钟平均风力")]
       public string two_aver_ws
        {
            set;
            get;
        }

        /// <summary>
        /// 十分钟平均风向
        /// </summary>
       [DisplayName("十分钟平均风向")]
       public double? ten_aver_wd
        {
            set;
            get;
        }

        /// <summary>
        /// 十分钟平均风力
        /// </summary>
       [DisplayName("十分钟平均风力")]
       public double? ten_aver_ws
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

        /// <summary>
        /// 十分钟最大风向
        /// </summary>
       [DisplayName("十分钟最大风向")]
       public double? ten_max_wd
        {
            set;
            get;
        }

        /// <summary>
        /// 十分钟最大风力
        /// </summary>
       [DisplayName("十分钟最大风力")]
       public double? ten_max_ws
        {
            set;
            get;
        }

        /// <summary>
        /// 十分钟最大风力时间
        /// </summary>
       [DisplayName("十分钟最大风力时间")]
       public string ten_maxws_time
        {
            set;
            get;
        }

        /// <summary>
        /// 瞬时风向
        /// </summary>
       [DisplayName("瞬时风向")]
       public double? instant_wd
        {
            set;
            get;
        }

        /// <summary>
        /// 瞬时风力
        /// </summary>
       [DisplayName("瞬时风力")]
       public double? instant_ws
        {
            set;
            get;
        }

        /// <summary>
        /// max_flu_wd
        /// </summary>
       [DisplayName("max_flu_wd")]
       public short? max_flu_wd
        {
            set;
            get;
        }

        /// <summary>
        /// max_flu_ws
        /// </summary>
       [DisplayName("max_flu_ws")]
       public double? max_flu_ws
        {
            set;
            get;
        }

        /// <summary>
        /// max_flu_time
        /// </summary>
       [DisplayName("max_flu_time")]
       public string max_flu_time
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
        /// 温度
        /// </summary>
       [DisplayName("温度")]
       public double? temper
        {
            set;
            get;
        }

        /// <summary>
        /// 最高温度
        /// </summary>
       [DisplayName("最高温度")]
       public double? max_temper
        {
            set;
            get;
        }

        /// <summary>
        /// 最高温度时间
        /// </summary>
       [DisplayName("最高温度时间")]
       public string max_temp_time
        {
            set;
            get;
        }

        /// <summary>
        /// 最低温度
        /// </summary>
       [DisplayName("最低温度")]
       public double? min_temper
        {
            set;
            get;
        }

        /// <summary>
        /// 最低温度时间
        /// </summary>
       [DisplayName("最低温度时间")]
       public string min_temp_time
        {
            set;
            get;
        }

        /// <summary>
        /// 湿度
        /// </summary>
       [DisplayName("湿度")]
       public short? rel_humi
        {
            set;
            get;
        }

        /// <summary>
        /// 最小湿度
        /// </summary>
       [DisplayName("最小湿度")]
       public short? min_relhumi
        {
            set;
            get;
        }

        /// <summary>
        /// 最小湿度时间
        /// </summary>
       [DisplayName("最小湿度时间")]
       public string min_relhumi_time
        {
            set;
            get;
        }

        /// <summary>
        /// 
        /// </summary>
       [DisplayName("")]
       public double? vap_press
        {
            set;
            get;
        }

        /// <summary>
        /// 露点
        /// </summary>
       [DisplayName("露点")]
       public double? dew_point
        {
            set;
            get;
        }

        /// <summary>
        /// 气压
        /// </summary>
       [DisplayName("气压")]
       public double? air_press
        {
            set;
            get;
        }

        /// <summary>
        /// 最大气压
        /// </summary>
       [DisplayName("最大气压")]
       public double? max_press
        {
            set;
            get;
        }

        /// <summary>
        /// 最大气压时间
        /// </summary>
       [DisplayName("最大气压时间")]
       public string max_press_time
        {
            set;
            get;
        }

        /// <summary>
        /// 最小气压
        /// </summary>
       [DisplayName("最小气压")]
       public double? min_press
        {
            set;
            get;
        }

        /// <summary>
        /// 最小气压时间
        /// </summary>
       [DisplayName("最小气压时间")]
       public string min_press_time
        {
            set;
            get;
        }

        /// <summary>
        /// surf_temp
        /// </summary>
       [DisplayName("surf_temp")]
       public double? surf_temp
        {
            set;
            get;
        }

        /// <summary>
        /// max_surf_temp
        /// </summary>
       [DisplayName("max_surf_temp")]
       public double? max_surf_temp
        {
            set;
            get;
        }

        /// <summary>
        /// max_sutemp_time
        /// </summary>
       [DisplayName("max_sutemp_time")]
       public string max_sutemp_time
        {
            set;
            get;
        }

        /// <summary>
        /// min_surf_temp
        /// </summary>
       [DisplayName("min_surf_temp")]
       public double? min_surf_temp
        {
            set;
            get;
        }

        /// <summary>
        /// min_sutemp_time
        /// </summary>
       [DisplayName("min_sutemp_time")]
       public string min_sutemp_time
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
