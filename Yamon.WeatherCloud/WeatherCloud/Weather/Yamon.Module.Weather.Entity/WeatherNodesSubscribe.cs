
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Weather.Entity
{
    /// <summary>
    /// 用户资源订阅实体类
    /// </summary>
    [Serializable]
    [Table("Weather_NodesSubscribe")]
    public partial class WeatherNodesSubscribe
    {
        public WeatherNodesSubscribe()
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
        /// 用户ID
        /// </summary>
       [DisplayName("用户ID")]
       public int? UserID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("用户ID")]
       public string UserID_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 订阅ID
        /// </summary>
       [DisplayName("订阅ID")]
       public int? NodeID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("订阅ID")]
       public string NodeID_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 订阅时间
        /// </summary>
       [DisplayName("订阅时间")]
       public DateTime? CreateTime
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("订阅时间")]
       public string CreateTime_ShowValue
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
