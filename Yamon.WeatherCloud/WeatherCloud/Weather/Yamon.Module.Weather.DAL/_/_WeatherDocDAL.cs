﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由亚萌智能表单代码生成工具生成。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。除非此项目不再使用代码生成器生成。
//     如果想修改此文件的方法，请在此文件的上级目录中的WeatherDocDAL重写(override)该方法。
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
    /// 文档实体类
    ///</summary>
    public partial class _WeatherDocDAL : BaseModelDAL<WeatherDoc>
    {
        public _WeatherDocDAL():base("UCenter")
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
		public virtual List<WeatherDoc> GetEntityListByPage(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
		{
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
				order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			string fields="ID,InfoTitle,InfoPath,DataTime,CreateTime";
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
			string fields="ID,InfoTitle,InfoPath,DataTime,CreateTime";
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

		
	    public virtual WeatherDoc GetModelValue(WeatherDoc model)
        {
            return model;
        }
		/// <summary>
        /// 设置文档实体(WeatherDoc)的显示值
        /// </summary>
        /// <param name="model">文档实体(WeatherDoc)</param>
        /// <returns>文档实体(WeatherDoc)</returns>
		public virtual WeatherDoc GetModelShowValue(WeatherDoc model,bool clearValue=false)
        {
            model=GetModelValue(model);
		if (model.DataTime!=null)
		{
			model.DataTime_ShowValue=((DateTime)model.DataTime).ToString("yyyy-MM-dd HH:mm");
		}
		if (model.CreateTime!=null)
		{
			model.CreateTime_ShowValue=((DateTime)model.CreateTime).ToString("yyyy-MM-dd HH:mm");
		}
		if (model.UpdateTime!=null)
		{
			model.UpdateTime_ShowValue=((DateTime)model.UpdateTime).ToString("yyyy-MM-dd HH:mm");
		}
			if(clearValue)
			{
				model.DataTime = null;
				model.CreateTime = null;
				model.UpdateTime = null;
			}
			return model;
		}
		
		/// <summary>
        /// 设置文档实体(WeatherDoc)的列表显示值
        /// </summary>
        /// <param name="model">文档实体(WeatherDoc)</param>
        /// <returns>文档实体(WeatherDoc)</returns>
		public virtual WeatherDoc GetModelGridShowValue(WeatherDoc model){
			model=GetModelShowValue(model);
			return model;
        }

        public virtual WeatherDoc GetInfoByID(object id){
            WeatherDoc model = GetModelByID(id);
            model = GetModelShowValue(model);
            return model;
        } 


      #region 新建相关方法
		/// <summary>
        /// 设置新增入库时文档实体(WeatherDoc)默认值
        /// </summary>
        /// <param name="model">文档实体(WeatherDoc)</param>
        /// <returns>文档实体(WeatherDoc)</returns>
		public virtual WeatherDoc GetInsertModelValue(WeatherDoc model)
		{
			model.ID =null;
			return model;
		}		/// <summary>
        /// 设置新建页面的文档实体(WeatherDoc)默认值
        /// </summary>
        /// <param name="model">文档实体(WeatherDoc)</param>
        /// <returns>文档实体(WeatherDoc)</returns>
		public virtual WeatherDoc GetCreateFormDefaultValue()
		{
            WeatherDoc model = new WeatherDoc();
            return model;
		}

		/// <summary>
        /// 新建数据格式验证
        /// </summary>
        /// <param name="model">文档实体(WeatherDoc)</param>
        public virtual void CreateFormValidator(WeatherDoc model)
        {
			string value="";
}
      #endregion

      #region 修改相关方法
		/// <summary>
        /// 设置更新入库时文档实体(WeatherDoc)默认值
        /// </summary>
        /// <param name="model">文档实体(WeatherDoc)</param>
        /// <returns>文档实体(WeatherDoc)</returns>
		public virtual WeatherDoc GetUpdateModelValue(WeatherDoc model)
		{
			return model;
		}		/// <summary>
        /// 设置编辑页面的文档实体(WeatherDoc)默认值
        /// </summary>
        /// <param name="model">文档实体(WeatherDoc)</param>
        /// <returns>文档实体(WeatherDoc)</returns>
		public virtual WeatherDoc GetEditFormDefaultValue(WeatherDoc model)
		{
			return model;
		}

		/// <summary>
        /// 编辑数据格式验证
        /// </summary>
        /// <param name="model">文档实体(WeatherDoc)</param>
        public virtual void EditFormValidator(WeatherDoc model)
        {
			string value="";
}
      #endregion

    }
}