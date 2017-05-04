
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Yamon.Framework.DBUtility;
using System.Collections;
using Yamon.Framework.Common.DataBase;
using Yamon.Framework.Common;
using Yamon.Framework.Common.IO;
using System.IO;
using System.Linq.Expressions;
using Yamon.Framework.DAL;
using Yamon.Module.UCenter.Entity;
using Senparc.Weixin.QY.AdvancedAPIs.MailList;
using Senparc.Weixin.QY.AdvancedAPIs;

namespace Yamon.Module.UCenter.DAL
{
    /// <summary>
    /// 部门模型实体类
    ///</summary>
    public partial class DepartmentDAL : _DepartmentDAL
    {

        public int DownloadDepartmentToDB(List<DepartmentList> list)
        {
            string del = "delete UC_Department";
            DbHelper.GetConn("UCenter").ExecuteStringSql(del);
            int count = 0;
            foreach(DepartmentList dept in list ){            
                string str = string.Format("insert into UC_Department([DepartmentID],[DepartmentName],[ParentID],[OrderID]) values('{0}','{1}','{2}','{3}')",dept.id,dept.name,dept.parentid,dept.order);
                DbHelper.GetConn("UCenter").ExecuteStringSql(str);

               // MailListApi.CreateDepartment();
                count++;
            }
            return count;       
        }

        //获取数据库的部门数据,DepartmentID不为NULL 可能修改或者更新的
        public DataTable getDepartmentOfDB() {
            string sql = "select * from UC_Department where len([DepartmentID])>0 ";
            return DbHelper.GetConn("UCenter").ExecuteDataTableSql(sql);      
        }

        //DepartmentID 为NULL 都是新建 需要上传的数据 
        public DataTable getDepartmentOfDBOfCreate()
        {
            string sql = "select * from UC_Department where DepartmentID is null";
            return DbHelper.GetConn("UCenter").ExecuteDataTableSql(sql);
        }

        //public override Department GetInsertModelValue(Department model)
        //{
        //    int parentID = DataConverter.ToInt(model.ParentID);
        //    parentID = parentID == 0 ? 1 : parentID;
        //    model.ParentID = parentID;
        //    return base.GetInsertModelValue(model);
        //}

        public void SyncDBAndWeiXin(List<DepartmentList> list)
        {
            DataTable loc = getDepartmentOfDB(); //本地数据
            foreach (DepartmentList dept in list)
            {

                foreach (DataRow row in loc.Rows)
                {





                }


            }
        }
    }
}
