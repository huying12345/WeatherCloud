/*----------------------------------------------------------------
    Copyright (C) 2015 Senparc
    
    文件名：QYController.cs
    文件功能描述：企业号对接测试
    
    
    创建标识：Senparc - 20150312
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;
using Senparc.Weixin.MP.MvcExtension;
using Senparc.Weixin.QY.AdvancedAPIs;
using Senparc.Weixin.QY.AdvancedAPIs.MailList;
using Senparc.Weixin.QY.AdvancedAPIs.Mass;
using Senparc.Weixin.QY.Entities;
using Yamon.Framework.Common;
using Yamon.Framework.MVC;
using Yamon.Monitor.WeixinMP.CommonService.QyMessageHandlers;

namespace Yamon.Module.WeiXin.Web.Controllers
{
    /// <summary>
    /// 企业号对接测试
    /// </summary>
    [NoCheckLogin]
    public class QYController : Controller
    {
        public static readonly string Token = ConfigHelper.GetConfigString("QY_Token");//与微信企业账号后台的Token设置保持一致，区分大小写。
        public static readonly string EncodingAesKey = ConfigHelper.GetConfigString("QY_EncodingAESKey");//与微信企业账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string CorpId = ConfigHelper.GetConfigString("QY_CorpId");//与微信企业账号后台的CorpId设置保持一致，区分大小写。
        public static readonly string CorpSecrets = ConfigHelper.GetConfigString("QY_CorpSecrets");

        /// <summary>
        /// 微信后台验证地址（使用Get），微信企业后台应用的“修改配置”的Url填写如：http://weixin.senparc.com/qy
        /// </summary>
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(string msg_signature = "", string timestamp = "", string nonce = "", string echostr = "")
        {
            //return Content(echostr); //返回随机字符串则表示验证通过
            var verifyUrl = Senparc.Weixin.QY.Signature.VerifyURL(Token, EncodingAesKey, CorpId, msg_signature, timestamp, nonce,
                echostr);
            if (verifyUrl != null)
            {
                return Content(verifyUrl); //返回解密后的随机字符串则表示验证通过
            }
            else
            {
                return Content("如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
            }
        }

        /// <summary>
        /// 微信后台验证地址（使用Post），微信企业后台应用的“修改配置”的Url填写如：http://weixin.senparc.com/qy
        /// </summary>
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post(PostModel postModel)
        {
            var maxRecordCount = 10;

            postModel.Token = Token;
            postModel.EncodingAESKey = EncodingAesKey;
            postModel.CorpId = CorpId;

            //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
            var messageHandler = new QyCustomMessageHandler(Request.InputStream, postModel, maxRecordCount);

            if (messageHandler.RequestMessage == null)
            {
                //验证不通过或接受信息有错误
            }

            try
            {

                //测试时可开启此记录，帮助跟踪数据，使用前请确保App_Data文件夹存在，且有读写权限。
                messageHandler.RequestDocument.Save(Server.MapPath("~/App_Data/Qy/" + DateTime.Now.Ticks + "_Request_" + messageHandler.RequestMessage.FromUserName + ".txt"));
                //执行微信处理过程
                messageHandler.Execute();
                //测试时可开启，帮助跟踪数据
                messageHandler.ResponseDocument.Save(Server.MapPath("~/App_Data/Qy/" + DateTime.Now.Ticks + "_Response_" + messageHandler.ResponseMessage.ToUserName + ".txt"));
                messageHandler.FinalResponseDocument.Save(Server.MapPath("~/App_Data/Qy/" + DateTime.Now.Ticks + "_FinalResponse_" + messageHandler.ResponseMessage.ToUserName + ".txt"));

                //自动返回加密后结果
                return new FixWeixinBugWeixinResult(messageHandler);//为了解决官方微信5.0软件换行bug暂时添加的方法，平时用下面一个方法即可
            }
            catch (Exception ex)
            {
                using (TextWriter tw = new StreamWriter(Server.MapPath("~/App_Data/Qy/Qy_Error_" + DateTime.Now.Ticks + ".txt")))
                {
                    tw.WriteLine("ExecptionMessage:" + ex.Message);
                    tw.WriteLine(ex.Source);
                    tw.WriteLine(ex.StackTrace);
                    //tw.WriteLine("InnerExecptionMessage:" + ex.InnerException.Message);

                    if (messageHandler.FinalResponseDocument != null)
                    {
                        tw.WriteLine(messageHandler.FinalResponseDocument.ToString());
                    }
                    tw.Flush();
                    tw.Close();
                }
                return Content("");
            }
        }

        /// <summary>
        /// 这是一个最简洁的过程演示
        /// </summary>
        /// <param name="postModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MiniPost(PostModel postModel)
        {
            var maxRecordCount = 10;

            postModel.Token = Token;
            postModel.EncodingAESKey = EncodingAesKey;
            postModel.CorpId = CorpId;

            //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
            var messageHandler = new QyCustomMessageHandler(Request.InputStream, postModel, maxRecordCount);
            //执行微信处理过程
            messageHandler.Execute();
            //自动返回加密后结果
            return new FixWeixinBugWeixinResult(messageHandler);
        }

        public ActionResult SendTextMsg()
        {
            var accessToken = Senparc.Weixin.QY.Containers.AccessTokenContainer.TryGetToken(CorpId, CorpSecrets);
            MassResult result = MassApi.SendText(accessToken, "wubo", "", "", "4", "测试");
            return Content("");
        }

        public ActionResult GetDepartmentList()
        {
            var accessToken = Senparc.Weixin.QY.Containers.AccessTokenContainer.TryGetToken(CorpId, CorpSecrets);

            GetDepartmentListResult result = MailListApi.GetDepartmentList(accessToken);
           
            return Json(result.department,JsonRequestBehavior.AllowGet);
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
            string url ="https://qyapi.weixin.qq.com/cgi-bin/user/create?";
          
            HttpHelper http = new HttpHelper();
        //    string result = http.Post(url,param);

            return param;
        }
    }
}