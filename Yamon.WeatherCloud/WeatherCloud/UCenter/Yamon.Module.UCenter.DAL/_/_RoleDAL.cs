﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由亚萌智能表单代码生成工具生成。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。除非此项目不再使用代码生成器生成。
//     如果想修改此文件的方法，请在此文件的上级目录中的RoleDAL重写(override)该方法。
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
using Yamon.Module.UCenter.Entity;

namespace Yamon.Module.UCenter.DAL
{
    /// <summary>
    /// 角色模型实体类
    ///</summary>
    public partial class _RoleDAL : BaseModelDAL<Role>
    {
        public _RoleDAL():base("UCenter")
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
		public virtual List<Role> GetEntityListByPage(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
		{
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
				order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			string fields="RoleID,RoleName,OrderID,Description";
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
			string fields="RoleID,RoleName,OrderID,Description";
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
			
			
			//RoleID
			if (!("," + notIn.ToLower() + ",").Contains(",roleid,"))
			{
				value = RequestHelper.GetString("RoleID");
				if (!string.IsNullOrEmpty(value))
				{
				 sb.Append(" AND [`RoleID`]=?");
				  param.Add(value);
				}
			}
			
			
			//RoleName
			if (!("," + notIn.ToLower() + ",").Contains(",rolename,"))
			{
			value = RequestHelper.GetString("RoleName");
			if (!string.IsNullOrEmpty(value))
			{
			    string[] arrValue = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			    if (arrValue.Length > 1)
			    {
			        for (int i = 0; i < arrValue.Length; i++)
			        {
			       		sb.Append(" AND [`RoleName`] like ?");
			       		param.Add("%"+ arrValue[i]+"%");
			        }
			    }
			    else
			    {
			          sb.Append(" AND [`RoleName`] like ?");
			          param.Add("%"+ value+"%");
			    }
			}
			}
			arrParam=param.ToArray();
			return sb.ToString();

		}

		
	    public virtual Role GetModelValue(Role model)
        {
            return model;
        }
		/// <summary>
        /// 设置角色模型实体(Role)的显示值
        /// </summary>
        /// <param name="model">角色模型实体(Role)</param>
        /// <returns>角色模型实体(Role)</returns>
		public virtual Role GetModelShowValue(Role model,bool clearValue=false)
        {
            model=GetModelValue(model);
			if(clearValue)
			{
			}
			return model;
		}
		
		/// <summary>
        /// 设置角色模型实体(Role)的列表显示值
        /// </summary>
        /// <param name="model">角色模型实体(Role)</param>
        /// <returns>角色模型实体(Role)</returns>
		public virtual Role GetModelGridShowValue(Role model){
			model=GetModelShowValue(model);
			return model;
        }

        public virtual Role GetInfoByID(object id){
            Role model = GetModelByID(id);
            model = GetModelShowValue(model);
            return model;
        } 


      #region 新建相关方法
		/// <summary>
        /// 设置新增入库时角色模型实体(Role)默认值
        /// </summary>
        /// <param name="model">角色模型实体(Role)</param>
        /// <returns>角色模型实体(Role)</returns>
		public virtual Role GetInsertModelValue(Role model)
		{
			model.RoleID =null;
			return model;
		}		/// <summary>
        /// 设置新建页面的角色模型实体(Role)默认值
        /// </summary>
        /// <param name="model">角色模型实体(Role)</param>
        /// <returns>角色模型实体(Role)</returns>
		public virtual Role GetCreateFormDefaultValue()
		{
            Role model = new Role();
			model.OrderID=GetMaxID("OrderID");
            return model;
		}

		/// <summary>
        /// 新建数据格式验证
        /// </summary>
        /// <param name="model">角色模型实体(Role)</param>
        public virtual void CreateFormValidator(Role model)
        {
			string value="";
			
			//RoleName验证
			value = model.RoleName!=null ? model.RoleName.ToString() : "";
			if ( string.IsNullOrEmpty(value))
			{
				throw new Exception("角色名称不能为空！");
			}
			
			//OrderID验证
			value = model.OrderID!=null ? model.OrderID.ToString() : "";
			if ( string.IsNullOrEmpty(value))
			{
				throw new Exception("排序号不能为空！");
			}
}
      #endregion

      #region 修改相关方法
		/// <summary>
        /// 设置更新入库时角色模型实体(Role)默认值
        /// </summary>
        /// <param name="model">角色模型实体(Role)</param>
        /// <returns>角色模型实体(Role)</returns>
		public virtual Role GetUpdateModelValue(Role model)
		{
			return model;
		}		/// <summary>
        /// 设置编辑页面的角色模型实体(Role)默认值
        /// </summary>
        /// <param name="model">角色模型实体(Role)</param>
        /// <returns>角色模型实体(Role)</returns>
		public virtual Role GetEditFormDefaultValue(Role model)
		{
			return model;
		}

		/// <summary>
        /// 编辑数据格式验证
        /// </summary>
        /// <param name="model">角色模型实体(Role)</param>
        public virtual void EditFormValidator(Role model)
        {
			string value="";
			
			//RoleName验证
			value = model.RoleName!=null ? model.RoleName.ToString() : "";
			if ( string.IsNullOrEmpty(value))
			{
				throw new Exception("角色名称不能为空！");
			}
			
			//OrderID验证
			value = model.OrderID!=null ? model.OrderID.ToString() : "";
			if ( string.IsNullOrEmpty(value))
			{
				throw new Exception("排序号不能为空！");
			}
}
      #endregion

    }
}