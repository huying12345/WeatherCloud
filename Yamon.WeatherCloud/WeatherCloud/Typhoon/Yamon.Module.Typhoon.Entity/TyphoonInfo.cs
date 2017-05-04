
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Typhoon.Entity
{
    /// <summary>
    /// 台风信息实体类
    /// </summary>
    [Serializable]
    [Table("Typhoon_Info")]
    public partial class TyphoonInfo
    {
        public TyphoonInfo()
        { }

        #region Model

        
        /// <summary>
        /// 台风编号
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("台风编号")]
       public string TyphoonID
        {
            set;
            get;
        }

        /// <summary>
        /// 台风英文名称
        /// </summary>
       [DisplayName("台风英文名称")]
       public string EnName
        {
            set;
            get;
        }

        /// <summary>
        /// 台风中文名称
        /// </summary>
       [DisplayName("台风中文名称")]
       public string CnName
        {
            set;
            get;
        }

        /// <summary>
        /// 台风数据说明
        /// </summary>
       [DisplayName("台风数据说明")]
       public string DataInfo
        {
            set;
            get;
        }

        /// <summary>
        /// 发报中心
        /// </summary>
       [DisplayName("发报中心")]
       public string ReportCenter
        {
            set;
            get;
        }

        /// <summary>
        /// 台风发生年
        /// </summary>
       [DisplayName("台风发生年")]
       public int? TYear
        {
            set;
            get;
        }

        /// <summary>
        /// 最新预报时间
        /// </summary>
       [DisplayName("最新预报时间")]
       public DateTime? LastReportTime
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
