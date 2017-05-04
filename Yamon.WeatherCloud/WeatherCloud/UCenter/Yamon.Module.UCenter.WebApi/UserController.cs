
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
using Yamon.Framework.Common.Encrypt;
using Yamon.Framework.MVC;

using Yamon.Module.SiteManage.DAL;
using Yamon.Module.SiteManage.Entity;
using Senparc.Weixin.QY.AdvancedAPIs.MailList;
using Senparc.Weixin.QY.AdvancedAPIs;


namespace Yamon.Module.UCenter.WebApi
{
    /// <summary>
    /// 用户模型
    /// </summary>
    public partial class UserController : _UserController
    {


        public static readonly string Token = ConfigHelper.GetConfigString("QY_Token");//与微信企业账号后台的Token设置保持一致，区分大小写。
        public static readonly string EncodingAesKey = ConfigHelper.GetConfigString("QY_EncodingAESKey");//与微信企业账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string CorpId = ConfigHelper.GetConfigString("QY_CorpId");//与微信企业账号后台的CorpId设置保持一致，区分大小写。
        public static readonly string CorpSecrets = ConfigHelper.GetConfigString("QY_CorpSecrets");

        [CheckPurview(0)]
        public ActionResult ChangePwd(string oldpassword, string newPassword, string newPassword1)
        {
            int userId = CookieHelper.GetCookieInt("UserID");
            if (userId == 0)
            {
                hash["message"] = "尚未登录！";
            }
            else
            {
                if (newPassword != newPassword1)
                {
                    hash["message"] = "两次密码输入不一致！";
                }
                else
                {
                    oldpassword = MD5Encrypt.Encrypt(oldpassword);
                    newPassword = MD5Encrypt.Encrypt(newPassword);
                    int result = dal.UserEdit(userId, null, oldpassword, newPassword, null, false);
                    if (result == -2 || result == -1)
                    {
                        hash["message"] = "原密码错误！";
                    }
                    else if (result == 1)
                    {
                        hash["success"] = true;
                        hash["message"] = "修改成功！";
                    }
                    else
                    {
                        hash["message"] = result.ToString();
                    }
                }
            }
            LogDAL.AddLog("UCenter_User", userId.ToString(), "修改", "修改密码：" + hash["message"].ToString());
            return Content(JsonConvert.SerializeObject(hash), "application/json");
        }

        [CheckPurview(0)]
        public ActionResult Logout()
        {
            UserDAL userDal = new UserDAL();
            int userId = CookieHelper.GetCookieInt("UserID");
            string cityId = CookieHelper.GetCookie("CityID");
            LogDAL.AddLog("UCenter_User", userId.ToString(), "Login", "注销成功！");
            userDal.LoginOut(userId);
            string loginUrl = ConfigHelper.GetConfigString("LoginUrl", "~/Home/Login");
            return new RedirectResult(string.Format(loginUrl, cityId));
        }

        [CheckPurview(0)]
        public ActionResult UserLogin(string username, string password)
        {
            Hashtable hash = new Hashtable();
            hash["success"] = false;

            UserDAL userDal = new UserDAL();
            if (string.IsNullOrEmpty(username))
            {
                hash["message"] = "用户名不能为空！";
                return Json(hash);
            }
            if (string.IsNullOrEmpty(password))
            {
                hash["message"] = "密码不能为空！";
                return Json(hash);
            }
            int result = userDal.UserLogin(username, password, 1);
            int uid = DataConverter.ToInt(result);
            hash["UserID"] = uid;
            if (uid > 0)
            {
                User memberInfo = userDal.GetCacheEntityModelByID(uid);
                memberInfo = userDal.GetModelShowValue(memberInfo);
                SessionHelper.Set("UserID", result);
                CookieHelper.WriteCookie("UserID", result.ToString());
                CookieHelper.WriteCookie("UserName", memberInfo.UserName);
                CookieHelper.WriteCookie("Email", memberInfo.Email);
                CookieHelper.WriteCookie("TrueName", memberInfo.TrueName);
                CookieHelper.WriteCookie("SkinName", ConfigHelper.GetConfigString("DefaultSkin", "skin-red-light"));
                CookieHelper.WriteCookie("UserFace", memberInfo.Photo);
                CookieHelper.WriteCookie("DepartmentName", memberInfo.DepartmentID_ShowValue);
                CookieHelper.WriteCookie("RoleID", memberInfo.RoleID);
                CookieHelper.WriteCookie("RoleIDList", memberInfo.RoleID);
                CookieHelper.WriteCookie("RoleName", memberInfo.RoleID_ShowValue);
                if (string.IsNullOrEmpty(memberInfo.RoleID))
                {
                    hash["message"] = username + "此用户在该系统没有任何权限！如果有疑问请联系管理员";
                    return Json(hash);
                }
                hash["UserID"] = result;
                if (!string.IsNullOrEmpty(RequestHelper.GetString("apiKey")))
                {
                    hash["token"] = TokenHelper.GetToken(RequestHelper.GetString("apiKey"), 0, uid);
                    hash["User"] = memberInfo;
                }
                hash["success"] = true;
                hash["message"] = "登录成功！";
            }
            else if (uid == -1)
            {
                hash["message"] = username + "用户名不存在！";
            }
            else if (uid == -2)
            {
                hash["message"] = username + "密码错误！";
            }
            else if (uid == -100)
            {
                hash["message"] = "自动登录失败，此IP不在允许列表中！";
            }
            else if (uid == -101)
            {
                hash["message"] = "自动登录失败，未开启绑定IP,不允许自动登录！";
            }

            LogDAL.AddLog("UCenter_User", uid.ToString(), "Login", hash["message"].ToString());

            return Content(JsonConvert.SerializeObject(hash), "application/json");
        }

        [NoCheckLogin]
        public ActionResult Login(string username, string password)
        {
            password = Yamon.Framework.Common.Encrypt.MD5Encrypt.Encrypt(password);
            return UserLogin(username, password);
        }

        [CheckPurview("UCenter_Role_SetUserRole")]
        public ActionResult GetUserListByRoleID(int selected = 0)
        {
            StringBuilder jsonsb = new StringBuilder();
            string order = RequestHelper.GetFormString("order");
            string roleId = RequestHelper.GetRequestString("RoleID");
            string sort = RequestHelper.GetFormString("sort", "UserID").Replace("_ShowValue", "");
            string orderby = "[" + sort + "] " + order;
            DataTable modellist = dal.GetListByRoleID(roleId, selected, orderby);
            jsonsb.Append("{\"total\":" + modellist.Rows.Count + ",\"rows\":");
            jsonsb.Append(modellist.ToJson());
            jsonsb.Append("}");
            return Content(jsonsb.ToString());
        }


        //同步微信用户到数据库
        public ActionResult SyncOfWeiXin()
        {
            try
            {
                var accessToken = Senparc.Weixin.QY.Containers.AccessTokenContainer.TryGetToken(CorpId, CorpSecrets);
                GetDepartmentMemberInfoResult result = MailListApi.GetDepartmentMemberInfo(accessToken, 1, 1, 0);
                List<GetMemberResult> list = result.userlist;

                if (list.Count > 0)
                {
                    int count = dal.DownloadUsersToDB(list);
                }
                hash["message"] = "下载用户成功！";
                hash["success"] = true;
            }
            catch (Exception ex)
            {
                hash["message"] = "下载用户失败:(" + ex.Message + ")！";
            }
            return Content(JsonConvert.SerializeObject(hash));
        }

        //上传用户
        public ActionResult SyncloadUsersToDB()
        {
            try
            {
                var accessToken = Senparc.Weixin.QY.Containers.AccessTokenContainer.TryGetToken(CorpId, CorpSecrets);
                GetDepartmentMemberInfoResult result = MailListApi.GetDepartmentMemberInfo(accessToken, 1, 1, 0);
                List<GetMemberResult> list = result.userlist;

                List<User> userList = dal.GetEntityList("", new object[] { }, "", 0, "");
                foreach (User users in userList)
                {
                    List<GetMemberResult> listTemp = list.Where(o => o.userid == users.UserName).ToList();
                    if (listTemp.Count == 0) //判断用户是否在微信上不存在
                    {
                        MailListApi.CreateMember(accessToken, users.UserName, users.TrueName, new int[] { DataConverter.ToInt(users.DepartmentID) }, null, users.Tel, users.Email,
                            null, null, null, 10000);
                    }
                    else
                    {
                        //修改用户
                        MailListApi.UpdateMember(accessToken, users.UserName, users.TrueName, new int[] { DataConverter.ToInt(users.DepartmentID) }, null, users.Tel, users.Email,
                            null, 1, null, null, 10000);
                    }
                }
                try
                {
                    ArrayList alist = new ArrayList();
                    string userDel = "";
                    int num = 0;
                    //删除用户
                    for (int i = 0; i < list.Count; i++)
                    {
                        List<User> listTemp = userList.Where(o => o.UserName == list[i].userid).ToList();
                        if (listTemp.Count == 0)
                        {
                            userDel += list[i].userid + ",";
                            num++;
                            if (num >= 195)
                            {
                                alist.Add(userDel);
                                userDel = "";
                                num = 0;
                            }
                        }
                        if (i == list.Count - 1)
                        {
                            alist.Add(userDel);
                        }
                    }
                    foreach (var item in alist)
                    {
                        string[] userlist = item.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        MailListApi.BatchDeleteMember(accessToken, userlist);
                    }
                }
                catch (Exception ex)
                {
                }
               
                hash["message"] = "上传用户成功！";
                hash["success"] = true;
            }
            catch (Exception ex)
            {
                hash["message"] = "上传用户失败:(" + ex.Message + ")！";
            }
            return Content(JsonConvert.SerializeObject(hash));
        }
        
    }
}
