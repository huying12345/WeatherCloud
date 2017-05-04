
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Typhoon.Entity
{
    /// <summary>
    /// 台风名称实体类
    /// </summary>
    [Serializable]
    [Table("Typhoon_Name")]
    public partial class TyphoonName
    {
        public TyphoonName()
        { }

        #region Model

        
        /// <summary>
        /// ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: true)]
       [DisplayName("ID")]
       public int? id
        {
            set;
            get;
        }

        /// <summary>
        /// 台风英文名称
        /// </summary>
       [DisplayName("台风英文名称")]
       public string name_en
        {
            set;
            get;
        }

        /// <summary>
        /// 台风中文名称
        /// </summary>
       [DisplayName("台风中文名称")]
       public string name_cn
        {
            set;
            get;
        }

        /// <summary>
        /// 国家
        /// </summary>
       [DisplayName("国家")]
       public string country
        {
            set;
            get;
        }


        #endregion Model

        //(Table)
    }
}
