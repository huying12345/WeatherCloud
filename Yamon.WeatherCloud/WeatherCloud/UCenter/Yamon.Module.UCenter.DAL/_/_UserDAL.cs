﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由亚萌智能表单代码生成工具生成。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。除非此项目不再使用代码生成器生成。
//     如果想修改此文件的方法，请在此文件的上级目录中的UserDAL重写(override)该方法。
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
    /// 用户模型实体类
    ///</summary>
    public partial class _UserDAL : BaseModelDAL<User>
    {
        public _UserDAL():base("UCenter")
        {
        }

		/// <summary>
        /// 性别（Gender）字段的数据集合（键值对）
        /// </summary>
		public MyNameValueCollection NameValue_Gender
		{
			get
			{
			    MyNameValueCollection nv=new MyNameValueCollection();
                nv.Add("0", "未定义");
                nv.Add("1", "男");
                nv.Add("2", "女");
                return nv;

			}
		}
		/// <summary>
        /// 所属部门（DepartmentID）字段的数据集合（键值对）
        /// </summary>
		public MyNameValueCollection NameValue_DepartmentID
		{
			get
			{
			    Yamon.Module.UCenter.DAL.DepartmentDAL dal = new Yamon.Module.UCenter.DAL.DepartmentDAL();
                string cacheKey = dal.CacheKeyPrefix + "NameValue_Department";
                object obj=CacheHelper.Get(cacheKey);
                if (obj == null)
                {
                   obj= dal.GetAllEntityTable("DepartmentID,DepartmentName").ToNameValueCollection();
                   CacheHelper.Insert(cacheKey,obj);
                }
                return (MyNameValueCollection) obj;

			}
		}
		/// <summary>
        /// 系统角色（RoleID）字段的数据集合（键值对）
        /// </summary>
		public MyNameValueCollection NameValue_RoleID
		{
			get
			{
			    Yamon.Module.UCenter.DAL.RoleDAL dal = new Yamon.Module.UCenter.DAL.RoleDAL();
                string cacheKey = dal.CacheKeyPrefix + "NameValue_Role";
                object obj=CacheHelper.Get(cacheKey);
                if (obj == null)
                {
                   obj= dal.GetAllEntityTable("RoleID,RoleName").ToNameValueCollection();
                   CacheHelper.Insert(cacheKey,obj);
                }
                return (MyNameValueCollection) obj;

			}
		}
		/// <summary>
        /// 在线状态（OnLineStatus）字段的数据集合（键值对）
        /// </summary>
		public MyNameValueCollection NameValue_OnLineStatus
		{
			get
			{
			    MyNameValueCollection nv=new MyNameValueCollection();
                nv.Add("1", "在线");
                nv.Add("0", "离线");
                return nv;

			}
		}
		/// <summary>
        /// 用户状态（Status）字段的数据集合（键值对）
        /// </summary>
		public MyNameValueCollection NameValue_Status
		{
			get
			{
			    MyNameValueCollection nv=new MyNameValueCollection();
                nv.Add("-1", "已删除");
                nv.Add("0", "正常");
                nv.Add("1", "锁定");
                return nv;

			}
		}
		/// <summary>
        /// 是否限制IP（IsLockIP）字段的数据集合（键值对）
        /// </summary>
		public MyNameValueCollection NameValue_IsLockIP
		{
			get
			{
			    MyNameValueCollection nv=new MyNameValueCollection();
                nv.Add("0", "否");
                nv.Add("1", "是");
                return nv;

			}
		}



		/// <summary>
		/// 获取数据实体列表(正常用户)
		///</summary>
		/// <param name="nv">页面传递参数集合</param>
		/// <param name="topN">数据条数</param>
		/// <param name="fields">查询的字段</param>
		/// <returns>实体列表</returns>
        public virtual List<User> GetEntityList_Status(int topN = 0,string fields="")
        {
            object[] arrParams = new object[] {  };
            return GetEntityList("1=1 AND Status>=0 ",arrParams, "", topN,fields);
        }
		
		/// <summary>
		/// 获取数据实体列表(正常用户)
		///</summary>
		/// <param name="fields">查询的字段</param>
		/// <returns>实体列表</returns>
        public virtual List<User> GetAllEntityList_Status(string fields="")
        {
            return GetEntityList_Status(0,fields);
        }
		
		/// <summary>
		/// 获取分页的数据实体列表(正常用户)
		///</summary>
		/// <param name="totalRows">记录总条数（out）</param>
		/// <param name="nv">页面传递参数集合</param>
		/// <param name="topN">数据条数</param>
		/// <param name="page">页码</param>
		/// <param name="rows">每页记录数</param>
		/// <param name="orderBy">排序</param>
		/// <returns>实体列表</returns>
        public virtual List<User> GetEntityListByPage_Status(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
        {
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
			   order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			object[] arrParams = new object[] {  };
            arrParams=arrParams.Concat(searchParams).ToArray();
            string fields="UserID,UserName,TrueName,Gender,Email,DepartmentID,Tel,OnLineStatus,LastLoginTime,LoginTimes";
            return GetEntityListByPage("1=1 AND Status>=0 "+ where, arrParams,order,fields ,rows,page,topN,out totalRows);
        }
		
		/// <summary>
		/// 获取数据列表DataTable(正常用户)
		///</summary>
		/// <param name="nv">页面传递参数集合</param>
		/// <param name="topN">数据条数</param>
		/// <param name="fields">查询的字段</param>
		/// <returns>数据列表</returns>
        public virtual DataTable GetEntityTable_Status(int topN = 0,string fields="")
        {
            object[] arrParams = new object[] {  };
            return GetEntityTable("1=1 AND Status>=0 ",arrParams, "", topN,fields);
        }
		
		/// <summary>
		/// 获取数据列表DataTable(正常用户)
		///</summary>
		/// <param name="fields">查询的字段</param>
		/// <returns>数据列表</returns>
        public virtual DataTable GetAllEntityTable_Status(string fields="")
        {
        	return GetEntityTable_Status(0,fields);
        }
		/// <summary>
		/// 获取分页的数据列表DataTable(正常用户)
		///</summary>
		/// <param name="totalRows">记录总条数（out）</param>
		/// <param name="nv">页面传递参数集合</param>
		/// <param name="topN">数据条数</param>
		/// <param name="page">页码</param>
		/// <param name="rows">每页记录数</param>
		/// <param name="orderBy">排序</param>
		/// <returns>DataTable</returns>
        public virtual DataTable GetEntityTableByPage_Status(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
        {
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
			    order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			object[] arrParams = new object[] {  };
            arrParams=arrParams.Concat(searchParams).ToArray();
            string fields="UserID,UserName,TrueName,Gender,Email,DepartmentID,Tel,OnLineStatus,LastLoginTime,LoginTimes";
            return GetEntityTableByPage("1=1 AND Status>=0 "+ where, arrParams,order,fields, rows,page,topN,out totalRows);
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
		public virtual List<User> GetEntityListByPage(out int totalRows,int topN = 0, int page=1,int rows=20,string orderBy="")
		{
			string order = "";
			if (!string.IsNullOrEmpty(orderBy))
			{
				order = orderBy;
			}
			object[] searchParams;
			string where = GetSearchSql("", out searchParams);
			string fields="UserID,UserName,TrueName,Gender,Email,DepartmentID,Tel,OnLineStatus,LastLoginTime,LoginTimes";
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
			string fields="UserID,UserName,TrueName,Gender,Email,DepartmentID,Tel,OnLineStatus,LastLoginTime,LoginTimes";
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
			
			
			//UserID
			if (!("," + notIn.ToLower() + ",").Contains(",userid,"))
			{
				value1 = RequestHelper.GetString("UserID_Start");
				value2 = RequestHelper.GetString("UserID_End");
				value =RequestHelper.GetString("UserID");
				if (!string.IsNullOrEmpty(value) && string.IsNullOrEmpty(value1) && string.IsNullOrEmpty(value2))
				{
				  sb.Append(" AND [`UserID`] =?");
				  param.Add(value);
				}
				if (!string.IsNullOrEmpty(value1))
				{
				  sb.Append(" AND [`UserID`] >=?");
				  param.Add(value1);
				}
				if (!string.IsNullOrEmpty(value2))
				{
				  sb.Append(" AND [`UserID`] <=?");
				  param.Add(value2);
				}
			}
			
			
			//UserName
			if (!("," + notIn.ToLower() + ",").Contains(",username,"))
			{
			value = RequestHelper.GetString("UserName");
			if (!string.IsNullOrEmpty(value))
			{
			    string[] arrValue = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			    if (arrValue.Length > 1)
			    {
			        for (int i = 0; i < arrValue.Length; i++)
			        {
			       		sb.Append(" AND [`UserName`] like ?");
			       		param.Add("%"+ arrValue[i]+"%");
			        }
			    }
			    else
			    {
			          sb.Append(" AND [`UserName`] like ?");
			          param.Add("%"+ value+"%");
			    }
			}
			}
			
			
			//DepartmentID
			if (!("," + notIn.ToLower() + ",").Contains(",departmentid,"))
			{
				value = RequestHelper.GetString("DepartmentID");
				if (!string.IsNullOrEmpty(value))
				{
				 sb.Append(" AND [`DepartmentID`]=?");
				  param.Add(value);
				}
			}
			
			
			//Email
			if (!("," + notIn.ToLower() + ",").Contains(",email,"))
			{
			value = RequestHelper.GetString("Email");
			if (!string.IsNullOrEmpty(value))
			{
			    string[] arrValue = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			    if (arrValue.Length > 1)
			    {
			        for (int i = 0; i < arrValue.Length; i++)
			        {
			       		sb.Append(" AND [`Email`] like ?");
			       		param.Add("%"+ arrValue[i]+"%");
			        }
			    }
			    else
			    {
			          sb.Append(" AND [`Email`] like ?");
			          param.Add("%"+ value+"%");
			    }
			}
			}
			
			
			//Tel
			if (!("," + notIn.ToLower() + ",").Contains(",tel,"))
			{
			value = RequestHelper.GetString("Tel");
			if (!string.IsNullOrEmpty(value))
			{
			    string[] arrValue = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			    if (arrValue.Length > 1)
			    {
			        for (int i = 0; i < arrValue.Length; i++)
			        {
			       		sb.Append(" AND [`Tel`] like ?");
			       		param.Add("%"+ arrValue[i]+"%");
			        }
			    }
			    else
			    {
			          sb.Append(" AND [`Tel`] like ?");
			          param.Add("%"+ value+"%");
			    }
			}
			}
			arrParam=param.ToArray();
			return sb.ToString();

		}

		
	    public virtual User GetModelValue(User model)
        {
            return model;
        }
		/// <summary>
        /// 设置用户模型实体(User)的显示值
        /// </summary>
        /// <param name="model">用户模型实体(User)</param>
        /// <returns>用户模型实体(User)</returns>
		public virtual User GetModelShowValue(User model,bool clearValue=false)
        {
            model=GetModelValue(model);
			if (model.Gender!=null)
			{
				model.Gender_ShowValue=NameValue_Gender.Get(model.Gender.ToString());
			}
			if (model.DepartmentID!=null)
			{
				model.DepartmentID_ShowValue=NameValue_DepartmentID.Get(model.DepartmentID.ToString());
			}
			if (model.RoleID!=null)
			{
				model.RoleID_ShowValue=NameValue_RoleID.GetValues(model.RoleID.ToString());
			}
			if (model.OnLineStatus!=null)
			{
				model.OnLineStatus_ShowValue=NameValue_OnLineStatus.Get(model.OnLineStatus.ToString());
			}
			if (model.Status!=null)
			{
				model.Status_ShowValue=NameValue_Status.Get(model.Status.ToString());
			}
			if (model.IsLockIP!=null)
			{
				model.IsLockIP_ShowValue=NameValue_IsLockIP.Get(model.IsLockIP.ToString());
			}
			if(clearValue)
			{
				model.Gender = null;
				model.DepartmentID = null;
				model.RoleID = null;
				model.OnLineStatus = null;
				model.Status = null;
				model.IsLockIP = null;
			}
			return model;
		}
		
		/// <summary>
        /// 设置用户模型实体(User)的列表显示值
        /// </summary>
        /// <param name="model">用户模型实体(User)</param>
        /// <returns>用户模型实体(User)</returns>
		public virtual User GetModelGridShowValue(User model){
			model=GetModelShowValue(model);
			return model;
        }

        public virtual User GetInfoByID(object id){
            User model = GetModelByID(id);
            model = GetModelShowValue(model);
            return model;
        } 


      #region 新建相关方法
		/// <summary>
        /// 设置新增入库时用户模型实体(User)默认值
        /// </summary>
        /// <param name="model">用户模型实体(User)</param>
        /// <returns>用户模型实体(User)</returns>
		public virtual User GetInsertModelValue(User model)
		{
			model.UserID =GetMaxID();
			model.PassWord = Yamon.Framework.Common.Encrypt.MD5Encrypt.Encrypt(model.PassWord);
			model.ConfirmPassword = Yamon.Framework.Common.Encrypt.MD5Encrypt.Encrypt(model.ConfirmPassword);
			model.OnLineStatus =0;
			model.Status =null;
			model.LastLoginIP =null;
			model.LastLoginTime =null;
			model.LoginTimes =null;
			model.RegisterTime =null;
			model.RegisterAppID =null;
			model.LastHitTime =null;
			model.LastLogoutTime =null;
			return model;
		}		/// <summary>
        /// 设置新建页面的用户模型实体(User)默认值
        /// </summary>
        /// <param name="model">用户模型实体(User)</param>
        /// <returns>用户模型实体(User)</returns>
		public virtual User GetCreateFormDefaultValue()
		{
            User model = new User();
			model.Gender=0;
			model.IsLockIP=0;
            return model;
		}

		/// <summary>
        /// 新建数据格式验证
        /// </summary>
        /// <param name="model">用户模型实体(User)</param>
        public virtual void CreateFormValidator(User model)
        {
			string value="";
			
			//UserName验证
			value = model.UserName!=null ? model.UserName.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("用户名不能为空！");
		            }
            if (!string.IsNullOrEmpty(value)&&ExistsByField("UserName",value))
            {
                throw new Exception(string.Format("用户名为({0})已存在！", value));
            }
			
			//PassWord验证
			value = model.PassWord!=null ? model.PassWord.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("密码不能为空！");
		            }
			
			//ConfirmPassword验证
			value = model.ConfirmPassword!=null ? model.ConfirmPassword.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("密码确认不能为空！");
		            }
			
			//Email验证
			value = model.Email!=null ? model.Email.ToString() : "";
			if (!string.IsNullOrEmpty(value))
			{
				if (!DataValidator.IsEmail(value))
				{
					throw new Exception("Email格式错误！请输入正确的Email地址！示例：zongsg@yamon.com.cn");
				}
		}
            if (!string.IsNullOrEmpty(value)&&ExistsByField("Email",value))
            {
                throw new Exception(string.Format("Email为({0})已存在！", value));
            }
			
			//DepartmentID验证
			value = model.DepartmentID!=null ? model.DepartmentID.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("所属部门不能为空！");
		            }
			
			//RoleID验证
			value = model.RoleID!=null ? model.RoleID.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("系统角色不能为空！");
		            }
			
			//Tel验证
			value = model.Tel!=null ? model.Tel.ToString() : "";
			if (!string.IsNullOrEmpty(value))
			{
				if (!DataValidator.IsMobile(value))
				{
					throw new Exception("手机号格式错误！请输入正确的手机号码！示例：13812345678");
				}
		}
			
			//IsLockIP验证
			value = model.IsLockIP!=null ? model.IsLockIP.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("是否限制IP不能为空！");
		            }
}
      #endregion

      #region 修改相关方法
		/// <summary>
        /// 设置更新入库时用户模型实体(User)默认值
        /// </summary>
        /// <param name="model">用户模型实体(User)</param>
        /// <returns>用户模型实体(User)</returns>
		public virtual User GetUpdateModelValue(User model)
		{
			model.UserName =null;
            model.PassWord = model.PassWord == "**********"?null:Yamon.Framework.Common.Encrypt.MD5Encrypt.Encrypt(model.PassWord);
            model.ConfirmPassword = model.ConfirmPassword == "**********"?null:Yamon.Framework.Common.Encrypt.MD5Encrypt.Encrypt(model.ConfirmPassword);
			model.OnLineStatus =null;
			model.Status =null;
			model.LastLoginIP =null;
			model.LastLoginTime =null;
			model.LoginTimes =null;
			model.RegisterTime =null;
			model.RegisterAppID =null;
			model.LastHitTime =null;
			model.LastLogoutTime =null;
			return model;
		}		/// <summary>
        /// 设置编辑页面的用户模型实体(User)默认值
        /// </summary>
        /// <param name="model">用户模型实体(User)</param>
        /// <returns>用户模型实体(User)</returns>
		public virtual User GetEditFormDefaultValue(User model)
		{
			model.PassWord="**********";
			model.ConfirmPassword="**********";
			return model;
		}

		/// <summary>
        /// 编辑数据格式验证
        /// </summary>
        /// <param name="model">用户模型实体(User)</param>
        public virtual void EditFormValidator(User model)
        {
			string value="";
			
			//PassWord验证
			value = model.PassWord!=null ? model.PassWord.ToString() : "";
                    if (model.PassWord=="")
                    {
                     throw new Exception("密码不能为空！");
                    }
			
			//ConfirmPassword验证
			value = model.ConfirmPassword!=null ? model.ConfirmPassword.ToString() : "";
                    if (model.ConfirmPassword=="")
                    {
                     throw new Exception("密码确认不能为空！");
                    }
			
			//Email验证
			value = model.Email!=null ? model.Email.ToString() : "";
			if (!string.IsNullOrEmpty(value))
			{
				if (!DataValidator.IsEmail(value))
				{
					throw new Exception("Email格式错误！请输入正确的Email地址！示例：zongsg@yamon.com.cn");
				}
		}
            if (!string.IsNullOrEmpty(value)&&ExistsByField("Email",value,model.UserID))
            {
                throw new Exception(string.Format("Email为({0})已存在！", value));
            }
			
			//DepartmentID验证
			value = model.DepartmentID!=null ? model.DepartmentID.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("所属部门不能为空！");
		            }
			
			//RoleID验证
			value = model.RoleID!=null ? model.RoleID.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("系统角色不能为空！");
		            }
			
			//Tel验证
			value = model.Tel!=null ? model.Tel.ToString() : "";
			if (!string.IsNullOrEmpty(value))
			{
				if (!DataValidator.IsMobile(value))
				{
					throw new Exception("手机号格式错误！请输入正确的手机号码！示例：13812345678");
				}
		}
			
			//IsLockIP验证
			value = model.IsLockIP!=null ? model.IsLockIP.ToString() : "";
		            if ( string.IsNullOrEmpty(value))
		            {
		             throw new Exception("是否限制IP不能为空！");
		            }
}
      #endregion

    }
}
