﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由亚萌智能表单代码生成工具生成。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。除非此项目不再使用代码生成器生成。
//     如果想修改此文件的方法，请在此文件的上级目录中的WeatherLogDAL重写(override)该方法。
//     如有问题联系zongeasy@qq.com
//
//</auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Yamon.Framework.DBUtility;
using System.Collections;
using Yamon.Framework.Common.DataBase;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using System.IO;
using System.Linq.Expressions;
using Yamon.Framework.DAL;
using Yamon.Module.Weather.Entity;

namespace Yamon.Module.Weather.DAL
{
    /// <summary>
    /// 日志实体类
    ///</summary>
    public partial class _WeatherLogDAL : BaseModelDAL<WeatherLog>
    {
        public _WeatherLogDAL():base("UCenter")
        {
        }

		/// <summary>
        /// 是否成功 1 成功 0失败（IsSuccess）字段的数据集合（键值对）
        /// </summary>
		public MyNameValueCollection NameValue_IsSuccess
		{
			get
			{
			    MyNameValueCollection nv=new MyNameValueCollection();
                nv.Add("1", "成功");
                nv.Add("0", "失败");
                return nv;

			}
		}
		/// <summary>
        /// 日志类型（1 操作日志，2未读入提醒日志）（LogType）字段的数据集合（键值对）
        /// </summary>
		public MyNameValueCollection NameValue_LogType
		{
			get
			{
			    MyNameValueCollection nv=new MyNameValueCollection();
                nv.Add("1", "操作日志");
                nv.Add("2", "未读入提醒日志");
                return nv;

			}
		}




		/// <summary>
		/// 获取分页的数据实体列表
		///</summary>
		/// <param name="totalRows">记录总条数（out）</param>
		/// <param name="nv">页面传递参数集合</param>
		/// <param name="topN">数据条数</param>
		/// <param name="page">页码</param>
		/// <param name="rows">每页记录数</param>
		/// <param name="orderBy">排序</param>
		/// <returns>实体列表</returns>
		public virtual List<WeatherLog> GetEntityListByPage(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
		{
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
				order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			string fields="LogID,NodeID,LogTime,FileName,LogContent,IsSuccess,LogType,DataTime";
			return GetEntityListByPage("1=1 "+ where, searchParams,order,fields, rows,page,topN,out totalRows);
		}

		/// <summary>
		/// 获取分页的数据列表DataTable
		///</summary>
		/// <param name="totalRows">记录总条数（out）</param>
		/// <param name="nv">页面传递参数集合</param>
		/// <param name="topN">数据条数</param>
		/// <param name="page">页码</param>
		/// <param name="rows">每页记录数</param>
		/// <param name="orderBy">排序</param>
		/// <returns>DataTable</returns>
		public virtual DataTable GetEntityTableByPage(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
		{
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
				order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			string fields="LogID,NodeID,LogTime,FileName,LogContent,IsSuccess,LogType,DataTime";
			return GetEntityTableByPage("1=1 "+ where, searchParams,order,fields,rows,page,topN,out totalRows);
		}

		/// <summary>
        /// 拼接查询Sql语句及参数
        /// </summary>
        /// <param name="nv">页面传递的参数集合</param>
        /// <param name="notIn">排除字段</param>
        /// <param name="arrParam">out查询参数</param>
        /// <returns>查询Sql语句</returns>
		public virtual string GetSearchSql(string notIn,out object[] arrParam)
		{
			StringBuilder sb=new StringBuilder();
			string value="";
			string value1 = "";
			string value2 = "";
			ArrayList param=new ArrayList();
			arrParam=param.ToArray();
			return sb.ToString();

		}

		
	    public virtual WeatherLog GetModelValue(WeatherLog model)
        {
            return model;
        }
		/// <summary>
        /// 设置日志实体(WeatherLog)的显示值
        /// </summary>
        /// <param name="model">日志实体(WeatherLog)</param>
        /// <returns>日志实体(WeatherLog)</returns>
		public virtual WeatherLog GetModelShowValue(WeatherLog model,bool clearValue=false)
        {
            model=GetModelValue(model);
			if (model.IsSuccess!=null)
			{
				model.IsSuccess_ShowValue=NameValue_IsSuccess.Get(model.IsSuccess.ToString());
			}
			if (model.LogType!=null)
			{
				model.LogType_ShowValue=NameValue_LogType.Get(model.LogType.ToString());
			}
		if (model.DataTime!=null)
		{
			model.DataTime_ShowValue=((DateTime)model.DataTime).ToString("yyyy-MM-dd HH:mm");
		}
			if(clearValue)
			{
				model.IsSuccess = null;
				model.LogType = null;
				model.DataTime = null;
			}
			return model;
		}
		
		/// <summary>
        /// 设置日志实体(WeatherLog)的列表显示值
        /// </summary>
        /// <param name="model">日志实体(WeatherLog)</param>
        /// <returns>日志实体(WeatherLog)</returns>
		public virtual WeatherLog GetModelGridShowValue(WeatherLog model){
			model=GetModelShowValue(model);
			return model;
        }

        public virtual WeatherLog GetInfoByID(object id){
            WeatherLog model = GetModelByID(id);
            model = GetModelShowValue(model);
            return model;
        } 


      #region 新建相关方法
		/// <summary>
        /// 设置新增入库时日志实体(WeatherLog)默认值
        /// </summary>
        /// <param name="model">日志实体(WeatherLog)</param>
        /// <returns>日志实体(WeatherLog)</returns>
		public virtual WeatherLog GetInsertModelValue(WeatherLog model)
		{
			model.LogID =null;
			return model;
		}		/// <summary>
        /// 设置新建页面的日志实体(WeatherLog)默认值
        /// </summary>
        /// <param name="model">日志实体(WeatherLog)</param>
        /// <returns>日志实体(WeatherLog)</returns>
		public virtual WeatherLog GetCreateFormDefaultValue()
		{
            WeatherLog model = new WeatherLog();
            return model;
		}

		/// <summary>
        /// 新建数据格式验证
        /// </summary>
        /// <param name="model">日志实体(WeatherLog)</param>
        public virtual void CreateFormValidator(WeatherLog model)
        {
			string value="";
}
      #endregion

      #region 修改相关方法
		/// <summary>
        /// 设置更新入库时日志实体(WeatherLog)默认值
        /// </summary>
        /// <param name="model">日志实体(WeatherLog)</param>
        /// <returns>日志实体(WeatherLog)</returns>
		public virtual WeatherLog GetUpdateModelValue(WeatherLog model)
		{
			return model;
		}		/// <summary>
        /// 设置编辑页面的日志实体(WeatherLog)默认值
        /// </summary>
        /// <param name="model">日志实体(WeatherLog)</param>
        /// <returns>日志实体(WeatherLog)</returns>
		public virtual WeatherLog GetEditFormDefaultValue(WeatherLog model)
		{
			return model;
		}

		/// <summary>
        /// 编辑数据格式验证
        /// </summary>
        /// <param name="model">日志实体(WeatherLog)</param>
        public virtual void EditFormValidator(WeatherLog model)
        {
			string value="";
}
      #endregion

    }
}
