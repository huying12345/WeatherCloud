
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel;
using Yamon.Framework.Common.DataBase;

namespace Yamon.Module.Weather.Entity
{
    /// <summary>
    /// 共享资源分类实体类
    /// </summary>
    [Serializable]
    [Table("Weather_Nodes")]
    public partial class WeatherNodes
    {
        public WeatherNodes()
        { }

        #region Model

        
        /// <summary>
        /// 节点标识符
        /// </summary>
       [DisplayName("节点标识符")]
       public string NodeIdentifier
        {
            set;
            get;
        }

        /// <summary>
        /// 节点ID
        /// </summary>
       [Column(isPrimaryKey: true, isIdentity: false)]
       [DisplayName("节点ID")]
       public int? NodeID
        {
            set;
            get;
        }

        /// <summary>
        /// 频道
        /// </summary>
       [DisplayName("频道")]
       public string channel
        {
            set;
            get;
        }

        /// <summary>
        /// 所属栏目
        /// </summary>
       [DisplayName("所属栏目")]
       public int? ParentID
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("所属栏目")]
       public string ParentID_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 栏目名称
        /// </summary>
       [DisplayName("栏目名称")]
       public string NodeName
        {
            set;
            get;
        }

        /// <summary>
        /// SiteID
        /// </summary>
       [DisplayName("SiteID")]
       public string SiteID
        {
            set;
            get;
        }

        /// <summary>
        /// 栏目类型
        /// </summary>
       [DisplayName("栏目类型")]
       public int? NodeType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("栏目类型")]
       public string NodeType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 图标
        /// </summary>
       [DisplayName("图标")]
       public string NodePicUrl
        {
            set;
            get;
        }

        /// <summary>
        /// 模板路径
        /// </summary>
       [DisplayName("模板路径")]
       public string TemplateName
        {
            set;
            get;
        }

        /// <summary>
        /// 节点提示
        /// </summary>
       [DisplayName("节点提示")]
       public string Tips
        {
            set;
            get;
        }

        /// <summary>
        /// 节点说明
        /// </summary>
       [DisplayName("节点说明")]
       public string Description
        {
            set;
            get;
        }

        /// <summary>
        /// 来源部门
        /// </summary>
       [DisplayName("来源部门")]
       public string SourceDepartment
        {
            set;
            get;
        }

        /// <summary>
        /// 联系人
        /// </summary>
       [DisplayName("联系人")]
       public string ConcactName
        {
            set;
            get;
        }

        /// <summary>
        /// 数据来源
        /// </summary>
       [DisplayName("数据来源")]
       public string DataSourceType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("数据来源")]
       public string DataSourceType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 数据接口地址
        /// </summary>
       [DisplayName("数据接口地址")]
       public string DataApiUrl
        {
            set;
            get;
        }

        /// <summary>
        /// 是否接入
        /// </summary>
       [DisplayName("是否接入")]
       public int? isDataAccess
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("是否接入")]
       public string isDataAccess_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 城市编号
        /// </summary>
       [DisplayName("城市编号")]
       public string CityID
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
        /// 录入方式
        /// </summary>
       [DisplayName("录入方式")]
       public int? IsImportToDB
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("录入方式")]
       public string IsImportToDB_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 是否定时
        /// </summary>
       [DisplayName("是否定时")]
       public int? IsTiming
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("是否定时")]
       public string IsTiming_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 计划编号
        /// </summary>
       [DisplayName("计划编号")]
       public int? SubPlanID
        {
            set;
            get;
        }

        /// <summary>
        /// 周期描述
        /// </summary>
       [DisplayName("周期描述")]
       public string SubPlanDesc
        {
            set;
            get;
        }

        /// <summary>
        /// 定时类型
        /// </summary>
       [DisplayName("定时类型")]
       public int? TimingType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("定时类型")]
       public string TimingType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 制作周期类型
        /// </summary>
       [DisplayName("制作周期类型")]
       public string CreateUnit
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("制作周期类型")]
       public string CreateUnit_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 开始时次
        /// </summary>
       [DisplayName("开始时次")]
       public string StartPeriod
        {
            set;
            get;
        }

        /// <summary>
        /// 周期集合
        /// </summary>
       [DisplayName("周期集合")]
       public string PeriodStr
        {
            set;
            get;
        }

        /// <summary>
        /// 制作周期
        /// </summary>
       [DisplayName("制作周期")]
       public int? CreatePeriod
        {
            set;
            get;
        }

        /// <summary>
        /// 路径规则
        /// </summary>
       [DisplayName("路径规则")]
       public string NodePath
        {
            set;
            get;
        }

        /// <summary>
        /// 延时分钟
        /// </summary>
       [DisplayName("延时分钟")]
       public int? Deley
        {
            set;
            get;
        }

        /// <summary>
        /// 文件名日期格式
        /// </summary>
       [DisplayName("文件名日期格式")]
       public string DateTimeFormat
        {
            set;
            get;
        }

        /// <summary>
        /// 入库命名规则
        /// </summary>
       [DisplayName("入库命名规则")]
       public string NameRule
        {
            set;
            get;
        }

        /// <summary>
        /// 命名规则前辍
        /// </summary>
       [DisplayName("命名规则前辍")]
       public string NamePrefix
        {
            set;
            get;
        }

        /// <summary>
        /// 是否加入监控
        /// </summary>
       [DisplayName("是否加入监控")]
       public int? IsMonitor
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("是否加入监控")]
       public string IsMonitor_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 是否重命名
        /// </summary>
       [DisplayName("是否重命名")]
       public int? IsRename
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("是否重命名")]
       public string IsRename_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 打开方式
        /// </summary>
       [DisplayName("打开方式")]
       public int? OpenType
        {
            set;
            get;
        }
       [Column(notMap:true)]
       [DisplayName("打开方式")]
       public string OpenType_ShowValue
        {
            set;
            get;
        }

        /// <summary>
        /// 外部链接地址
        /// </summary>
       [DisplayName("外部链接地址")]
       public string LinkUrl
        {
            set;
            get;
        }

        /// <summary>
        /// 执行网页任务
        /// </summary>
       [DisplayName("执行网页任务")]
       public string RunHttpTask
        {
            set;
            get;
        }


        #endregion Model

        //(TableTree)
            [Column(notMap:true)]
            [JsonProperty("children")]
            public List<WeatherNodes> Children
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
