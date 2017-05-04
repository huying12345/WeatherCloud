
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Linq.Expressions;
using System.Web.Mvc;
using Yamon.Framework.DAL;
using Yamon.Module.UCenter.Entity;
using Yamon.Module.UCenter.DAL;
using Newtonsoft.Json;
using Yamon.Framework.Common;
using Yamon.Module.SiteManage.DAL;
using Senparc.Weixin.QY.AdvancedAPIs.MailList;
using Senparc.Weixin.QY.AdvancedAPIs;



namespace Yamon.Module.UCenter.WebApi
{
    /// <summary>
    /// 部门模型
    /// </summary>
    public partial class DepartmentController : _DepartmentController
    {
        public static readonly string Token = ConfigHelper.GetConfigString("QY_Token");//与微信企业账号后台的Token设置保持一致，区分大小写。
        public static readonly string EncodingAesKey = ConfigHelper.GetConfigString("QY_EncodingAESKey");//与微信企业账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string CorpId = ConfigHelper.GetConfigString("QY_CorpId");//与微信企业账号后台的CorpId设置保持一致，区分大小写。
        public static readonly string CorpSecrets = ConfigHelper.GetConfigString("QY_CorpSecrets");

        //下载部门
        public ActionResult SyncOfWeiXin()
        {
            try
            {
                var accessToken = Senparc.Weixin.QY.Containers.AccessTokenContainer.TryGetToken(CorpId, CorpSecrets);
                DepartmentDAL dal = new DepartmentDAL();
                GetDepartmentListResult result = MailListApi.GetDepartmentList(accessToken);
                List<DepartmentList> list = result.department;

                //获取本地所有部门列表
                List<Department> departmentList = dal.GetEntityList("", new object[] { }, "", 0, "");

                foreach (DepartmentList item in list)
                {
                    List<Department> listTemp = departmentList.Where(o => o.DepartmentID == item.id).ToList();

                    Department depart = new Department();
                    depart.DepartmentID = item.id;
                    depart.DepartmentName = item.name;
                    depart.ParentID = item.parentid;
                    depart.OrderID = item.order;

                    if (listTemp.Count == 0)
                    {
                        dal.InsertByModel(depart);
                    }
                    else
                    {
                        dal.UpdateByModel(depart);
                    }
                }
                
                hash["message"] = "更新成功！";
                hash["success"] = true;
            }
            catch (Exception ex)
            {
                hash["message"] = "更新失败！" + ex.Message;
            }
            return Content(JsonConvert.SerializeObject(hash));
        }

        //上传部门
        public ActionResult SyncDBWeiXin()
        {
            try
            {
                var accessToken = Senparc.Weixin.QY.Containers.AccessTokenContainer.TryGetToken(CorpId, CorpSecrets);
                GetDepartmentListResult result = MailListApi.GetDepartmentList(accessToken);
                List<DepartmentList> list = result.department; //获取微信上的部门列表

                //获取本地所有部门列表
                List<Department> departmentList = dal.GetEntityList("", new object[] { }, "", 0, "");

                foreach (Department department in departmentList)
                {
                    List<DepartmentList> listTemp = list.Where(o => o.id == department.DepartmentID).ToList();
                    int parentID=DataConverter.ToInt(department.ParentID);
                    if (listTemp.Count == 0) //判断用户是否在微信上不存在
                    {
                        MailListApi.CreateDepartment(accessToken, department.DepartmentName,
                            parentID,
                            DataConverter.ToInt(department.OrderID),
                            DataConverter.ToInt(department.DepartmentID));
                    }
                    else //存在修改
                    {
                        MailListApi.UpdateDepartment(accessToken, department.DepartmentID.ToString(),
                            department.DepartmentName,
                            parentID,
                            DataConverter.ToInt(department.OrderID));
                    }
                }
               

                //删除部门
                try
                {

                    for (int i = list.Count-1; i >= 0; i--)
                    {

                        List<Department> listTemp = departmentList.Where(o => o.DepartmentID == list[i].id).ToList();
                        if (listTemp.Count == 0)
                        {
                            MailListApi.DeleteDepartment(accessToken, list[i].id.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                hash["message"] = "上传部门成功！";
                hash["success"] = true;
            }
            catch (Exception ex)
            {
                hash["message"] = "上传部门失败！" + ex.Message;
            }

            return Content(JsonConvert.SerializeObject(hash));
        }

        //获取部门成员详细信息
        public ActionResult GetDepartmentMemberInfo()
        {
            var accessToken = Senparc.Weixin.QY.Containers.AccessTokenContainer.TryGetToken(CorpId, CorpSecrets);
            /**            
               参数	       必须	  说明
            access_token	是	调用接口凭证
            departmentid	是	获取的部门id  根部门 1  二级部门为2
            fetchchild	    否	1/0：是否递归获取子部门下面的成员
            status	        否	0获取全部成员，1获取已关注成员列表，2获取禁用成员列表，4获取未关注成员列表。status可叠加，未填写则默认为4
             * **/
            GetDepartmentMemberInfoResult result = MailListApi.GetDepartmentMemberInfo(accessToken, 1, 1, 0);
            return Json(result.userlist, JsonRequestBehavior.AllowGet);
        }

        //创建成员
        //页面传参拼接URL直接进行访问
        public string AddMemberInfo()
        {
            var accessToken = Senparc.Weixin.QY.Containers.AccessTokenContainer.TryGetToken(CorpId, CorpSecrets);
            string param = RequestHelper.GetUrl();
            string url = "https://qyapi.weixin.qq.com/cgi-bin/user/create?";

            HttpHelper http = new HttpHelper();
            //    string result = http.Post(url,param);

            return param;
        }
    }
}
