﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由亚萌智能表单代码生成工具生成。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。除非此项目不再使用代码生成器生成。
//     如果想修改此文件的方法，请在此文件的上级目录中的WeatherTextDAL重写(override)该方法。
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
    /// 文本实体类
    ///</summary>
    public partial class _WeatherTextDAL : BaseModelDAL<WeatherText>
    {
        public _WeatherTextDAL():base("UCenter")
        {
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
		public virtual List<WeatherText> GetEntityListByPage(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
		{
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
				order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			string fields="ID,InfoTitle,InfoDetail,DataTime,CreateTime";
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
			string fields="ID,InfoTitle,InfoDetail,DataTime,CreateTime";
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

		
	    public virtual WeatherText GetModelValue(WeatherText model)
        {
            return model;
        }
		/// <summary>
        /// 设置文本实体(WeatherText)的显示值
        /// </summary>
        /// <param name="model">文本实体(WeatherText)</param>
        /// <returns>文本实体(WeatherText)</returns>
		public virtual WeatherText GetModelShowValue(WeatherText model,bool clearValue=false)
        {
            model=GetModelValue(model);
		if (model.DataTime!=null)
		{
			model.DataTime_ShowValue=((DateTime)model.DataTime).ToString("yyyy-MM-dd HH:mm");
		}
			if(clearValue)
			{
				model.DataTime = null;
			}
			return model;
		}
		
		/// <summary>
        /// 设置文本实体(WeatherText)的列表显示值
        /// </summary>
        /// <param name="model">文本实体(WeatherText)</param>
        /// <returns>文本实体(WeatherText)</returns>
		public virtual WeatherText GetModelGridShowValue(WeatherText model){
			model=GetModelShowValue(model);
			return model;
        }

        public virtual WeatherText GetInfoByID(object id){
            WeatherText model = GetModelByID(id);
            model = GetModelShowValue(model);
            return model;
        } 


      #region 新建相关方法
		/// <summary>
        /// 设置新增入库时文本实体(WeatherText)默认值
        /// </summary>
        /// <param name="model">文本实体(WeatherText)</param>
        /// <returns>文本实体(WeatherText)</returns>
		public virtual WeatherText GetInsertModelValue(WeatherText model)
		{
			model.ID =null;
			return model;
		}		/// <summary>
        /// 设置新建页面的文本实体(WeatherText)默认值
        /// </summary>
        /// <param name="model">文本实体(WeatherText)</param>
        /// <returns>文本实体(WeatherText)</returns>
		public virtual WeatherText GetCreateFormDefaultValue()
		{
            WeatherText model = new WeatherText();
            return model;
		}

		/// <summary>
        /// 新建数据格式验证
        /// </summary>
        /// <param name="model">文本实体(WeatherText)</param>
        public virtual void CreateFormValidator(WeatherText model)
        {
			string value="";
}
      #endregion

      #region 修改相关方法
		/// <summary>
        /// 设置更新入库时文本实体(WeatherText)默认值
        /// </summary>
        /// <param name="model">文本实体(WeatherText)</param>
        /// <returns>文本实体(WeatherText)</returns>
		public virtual WeatherText GetUpdateModelValue(WeatherText model)
		{
			return model;
		}		/// <summary>
        /// 设置编辑页面的文本实体(WeatherText)默认值
        /// </summary>
        /// <param name="model">文本实体(WeatherText)</param>
        /// <returns>文本实体(WeatherText)</returns>
		public virtual WeatherText GetEditFormDefaultValue(WeatherText model)
		{
			return model;
		}

		/// <summary>
        /// 编辑数据格式验证
        /// </summary>
        /// <param name="model">文本实体(WeatherText)</param>
        public virtual void EditFormValidator(WeatherText model)
        {
			string value="";
}
      #endregion

    }
}