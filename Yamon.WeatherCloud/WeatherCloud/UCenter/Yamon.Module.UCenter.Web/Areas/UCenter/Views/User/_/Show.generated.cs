﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Yamon.Framework.Common;
    using Yamon.Module.SiteManage.Entity;
    using Yamon.Module.UCenter;
    using Yamon.Module.UCenter.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/UCenter/Views/User/_/Show.cshtml")]
    public partial class _Areas_UCenter_Views_User___Show_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_UCenter_Views_User___Show_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
  
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由亚萌智能表单代码生成工具生成。
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。除非此项目不再使用代码生成器生成。
//     如果想修改此文件的内容，请复制一份到此文件的上级目录进行修改
//
//     如有问题联系zongeasy@qq.com
//</auto-generated>
//------------------------------------------------------------------------------

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" region=\"center\"");

WriteLiteral(" border=\"true\"");

WriteLiteral(" style=\"padding: 10px; background: #F6F6F6; border: 1px solid #ccc;\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"myForm\"");

WriteLiteral(" name=\"myForm\"");

WriteLiteral(" action=\"/api/UCenter/User/Show\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"mytable\"");

WriteLiteral("  cellpadding=\"1\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n<tr");

WriteLiteral(" id=\"Container_UserID\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_UserID\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">用户编号：</td><td>&nbsp;<span");

WriteLiteral(" id=\"UserID\"");

WriteLiteral(">");

            
            #line 18 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                  Write(Html.Raw(Model.UserID));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_UserName\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_UserName\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">用户名：</td><td>&nbsp;<span");

WriteLiteral(" id=\"UserName\"");

WriteLiteral(">");

            
            #line 19 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                       Write(Html.Raw(Model.UserName));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_TrueName\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_TrueName\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">真实姓名：</td><td>&nbsp;<span");

WriteLiteral(" id=\"TrueName\"");

WriteLiteral(">");

            
            #line 20 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                        Write(Html.Raw(Model.TrueName));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_Gender\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_Gender\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">性别：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Gender\"");

WriteLiteral(">");

            
            #line 21 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                Write(Html.Raw(Model.Gender_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_Email\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_Email\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">Email：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Email\"");

WriteLiteral(">");

            
            #line 22 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                Write(Html.Raw(Model.Email));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_DepartmentID\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_DepartmentID\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">所属部门：</td><td>&nbsp;<span");

WriteLiteral(" id=\"DepartmentID\"");

WriteLiteral(">");

            
            #line 23 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                                    Write(Html.Raw(Model.DepartmentID_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_RoleID\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_RoleID\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">系统角色：</td><td>&nbsp;<span");

WriteLiteral(" id=\"RoleID\"");

WriteLiteral(">");

            
            #line 24 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                  Write(Html.Raw(Model.RoleID_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_Tel\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_Tel\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">手机号：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Tel\"");

WriteLiteral(">");

            
            #line 25 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                        Write(Html.Raw(Model.Tel));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_Photo\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_Photo\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">用户照片：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Photo\"");

WriteLiteral(">");

            
            #line 26 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                               Write(Html.Raw(Model.Photo));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_OnLineStatus\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_OnLineStatus\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">在线状态：</td><td>&nbsp;<span");

WriteLiteral(" id=\"OnLineStatus\"");

WriteLiteral(">");

            
            #line 27 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                                    Write(Html.Raw(Model.OnLineStatus_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_Status\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_Status\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">用户状态：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Status\"");

WriteLiteral(">");

            
            #line 28 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                  Write(Html.Raw(Model.Status_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_LastLoginIP\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_LastLoginIP\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最后登陆的IP：</td><td>&nbsp;<span");

WriteLiteral(" id=\"LastLoginIP\"");

WriteLiteral(">");

            
            #line 29 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                                    Write(Html.Raw(Model.LastLoginIP));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_LastLoginTime\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_LastLoginTime\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最后登陆的时间：</td><td>&nbsp;<span");

WriteLiteral(" id=\"LastLoginTime\"");

WriteLiteral(">");

            
            #line 30 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                                          Write(Html.Raw(Model.LastLoginTime));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_LoginTimes\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_LoginTimes\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">登录次数：</td><td>&nbsp;<span");

WriteLiteral(" id=\"LoginTimes\"");

WriteLiteral(">");

            
            #line 31 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                              Write(Html.Raw(Model.LoginTimes));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_RegisterTime\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_RegisterTime\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">注册时间：</td><td>&nbsp;<span");

WriteLiteral(" id=\"RegisterTime\"");

WriteLiteral(">");

            
            #line 32 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                                    Write(Html.Raw(Model.RegisterTime));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_RegisterAppID\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_RegisterAppID\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">注册应用：</td><td>&nbsp;<span");

WriteLiteral(" id=\"RegisterAppID\"");

WriteLiteral(">");

            
            #line 33 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                                       Write(Html.Raw(Model.RegisterAppID));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_LastHitTime\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_LastHitTime\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最后点击时间：</td><td>&nbsp;<span");

WriteLiteral(" id=\"LastHitTime\"");

WriteLiteral(">");

            
            #line 34 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                                   Write(Html.Raw(Model.LastHitTime));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_LastLogoutTime\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_LastLogoutTime\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最后注销时间：</td><td>&nbsp;<span");

WriteLiteral(" id=\"LastLogoutTime\"");

WriteLiteral(">");

            
            #line 35 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                                            Write(Html.Raw(Model.LastLogoutTime));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_IsLockIP\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_IsLockIP\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">是否限制IP：</td><td>&nbsp;<span");

WriteLiteral(" id=\"IsLockIP\"");

WriteLiteral(">");

            
            #line 36 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                          Write(Html.Raw(Model.IsLockIP_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_Horizontal\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_Horizontal\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">横坐标：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Horizontal\"");

WriteLiteral(">");

            
            #line 37 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                             Write(Html.Raw(Model.Horizontal));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_LockIP\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_LockIP\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">限定IP：</td><td>&nbsp;<span");

WriteLiteral(" id=\"LockIP\"");

WriteLiteral(">");

            
            #line 38 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                  Write(Html.Raw(Model.LockIP));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_Ordinate\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_Ordinate\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">纵坐标：</td><td>&nbsp;<span");

WriteLiteral(" id=\"Ordinate\"");

WriteLiteral(">");

            
            #line 39 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                       Write(Html.Raw(Model.Ordinate));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_StationID\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_StationID\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">StationID：</td><td>&nbsp;<span");

WriteLiteral(" id=\"StationID\"");

WriteLiteral(">");

            
            #line 40 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                                Write(Html.Raw(Model.StationID));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_weixinID\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_weixinID\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">微信号：</td><td>&nbsp;<span");

WriteLiteral(" id=\"weixinID\"");

WriteLiteral(">");

            
            #line 41 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                       Write(Html.Raw(Model.weixinID));

            
            #line default
            #line hidden
WriteLiteral("</span></td></tr>\r\n<span");

WriteLiteral(" id=\"Position\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">");

            
            #line 42 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                     Write(Model.Position);

            
            #line default
            #line hidden
WriteLiteral("</span><span");

WriteLiteral(" id=\"Position_ShowValue\"");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">");

            
            #line 42 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
                                                                                                                Write(Model.Position);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n</table>\r\n\r\n");

WriteLiteral("        ");

            
            #line 45 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
   Write(RenderPage("~/Areas/UCenter/Views/User/Extend/Model_ViewHtml.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </form>\r\n</div>\r\n<div");

WriteLiteral(" region=\"south\"");

WriteLiteral(" border=\"false\"");

WriteLiteral(" style=\"text-align: right; background: #F6F6F6;height: 30px; line-height: 30px;\"");

WriteLiteral(">\r\n    <a");

WriteLiteral(" id=\"btnCancel\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" icon=\"icon-cancel\"");

WriteLiteral(" href=\"javascript:CloseDialog();\"");

WriteLiteral(">\r\n        关闭\r\n    </a>\r\n</div>\r\n");

            
            #line 53 "..\..\Areas\UCenter\Views\User\_\Show.cshtml"
Write(RenderPage("~/Areas/UCenter/Views/User/Extend/Model_ViewJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
