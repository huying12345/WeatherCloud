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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/UCenter/Views/UserConfig/_/Create.cshtml")]
    public partial class _Areas_UCenter_Views_UserConfig___Create_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_UCenter_Views_UserConfig___Create_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\UCenter\Views\UserConfig\_\Create.cshtml"
  
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
    ViewBag.Title="新建用户配置";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" region=\"center\"");

WriteLiteral(" border=\"true\"");

WriteLiteral(" style=\"padding: 10px; background: #F6F6F6; border: 1px solid #ccc;\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"myForm\"");

WriteLiteral(" name=\"myForm\"");

WriteLiteral(" action=\"/api/UCenter/UserConfig/Create\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n        <fieldset");

WriteLiteral(" class=\"myfieldset\"");

WriteLiteral(">\r\n<legend");

WriteLiteral(" id=\"tab_1\"");

WriteLiteral(">评分用户配置</legend>\r\n<table");

WriteLiteral(" class=\"mytable\"");

WriteLiteral(" cellpadding=\"1\"");

WriteLiteral(" width=\"98%\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n<tr");

WriteLiteral(" id=\"Container_PF_UserName\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_PF_UserName\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">预报评分用户名：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"PF_UserName\"");

WriteLiteral(" name=\"PF_UserName\"");

WriteAttribute("value", Tuple.Create(" value=\"", 934), Tuple.Create("\"", 962)
            
            #line 23 "..\..\Areas\UCenter\Views\UserConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 942), Tuple.Create<System.Object, System.Int32>(Model.PF_UserName
            
            #line default
            #line hidden
, 942), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"30\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_PF_PassWord\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_PF_PassWord\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">预报评分密码：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"PF_PassWord\"");

WriteLiteral(" name=\"PF_PassWord\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1203), Tuple.Create("\"", 1231)
            
            #line 26 "..\..\Areas\UCenter\Views\UserConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1211), Tuple.Create<System.Object, System.Int32>(Model.PF_PassWord
            
            #line default
            #line hidden
, 1211), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"30\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td></tr>\r\n\r\n</table>\r\n</fieldset>\r\n<fieldset");

WriteLiteral(" class=\"myfieldset\"");

WriteLiteral(">\r\n<legend");

WriteLiteral(" id=\"tab_2\"");

WriteLiteral(">用户信息配置</legend>\r\n<table");

WriteLiteral(" class=\"mytable\"");

WriteLiteral(" cellpadding=\"1\"");

WriteLiteral(" width=\"98%\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n<tr");

WriteLiteral(" id=\"Container_UserNumber\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_UserNumber\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">用户编号：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"UserNumber\"");

WriteLiteral(" name=\"UserNumber\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1642), Tuple.Create("\"", 1669)
            
            #line 35 "..\..\Areas\UCenter\Views\UserConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1650), Tuple.Create<System.Object, System.Int32>(Model.UserNumber
            
            #line default
            #line hidden
, 1650), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"30\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_IsLockIP\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_IsLockIP\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">是否限制IP：</td><td>&nbsp;\r\n\r\n");

            
            #line 39 "..\..\Areas\UCenter\Views\UserConfig\_\Create.cshtml"
Write(Html.Raw(MyHtmlHelper2.ShowRadio(ViewBag.DAL.NameValue_IsLockIP, "IsLockIP", Model.IsLockIP, "&nbsp;&nbsp;")));

            
            #line default
            #line hidden
WriteLiteral("\r\n</td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_LockIP\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_LockIP\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">限定IP：</td><td>&nbsp;\r\n<textarea");

WriteLiteral(" id=\"LockIP\"");

WriteLiteral(" name=\"LockIP\"");

WriteLiteral(" class=\"easyui-validatebox\"");

WriteLiteral("  style=\"width:400px;height:60px\"");

WriteLiteral(">");

            
            #line 42 "..\..\Areas\UCenter\Views\UserConfig\_\Create.cshtml"
                                                                                            Write(Model.LockIP);

            
            #line default
            #line hidden
WriteLiteral("</textarea>\r\n</td></tr>\r\n\r\n</table>\r\n</fieldset>\r\n<fieldset");

WriteLiteral(" class=\"myfieldset\"");

WriteLiteral(">\r\n<legend");

WriteLiteral(" id=\"tab_3\"");

WriteLiteral(">AOSM</legend>\r\n<table");

WriteLiteral(" class=\"mytable\"");

WriteLiteral(" cellpadding=\"1\"");

WriteLiteral(" width=\"98%\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n<tr");

WriteLiteral(" id=\"Container_ASOMID\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_ASOMID\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">ASOM用户名：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"ASOMID\"");

WriteLiteral(" name=\"ASOMID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2505), Tuple.Create("\"", 2528)
            
            #line 51 "..\..\Areas\UCenter\Views\UserConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 2513), Tuple.Create<System.Object, System.Int32>(Model.ASOMID
            
            #line default
            #line hidden
, 2513), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"30\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_ASOMPWD\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_ASOMPWD\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">ASOM密码：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"ASOMPWD\"");

WriteLiteral(" name=\"ASOMPWD\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2753), Tuple.Create("\"", 2777)
            
            #line 54 "..\..\Areas\UCenter\Views\UserConfig\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 2761), Tuple.Create<System.Object, System.Int32>(Model.ASOMPWD
            
            #line default
            #line hidden
, 2761), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"30\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td></tr>\r\n\r\n</table>\r\n</fieldset>\r\n\r\n");

WriteLiteral("        ");

            
            #line 60 "..\..\Areas\UCenter\Views\UserConfig\_\Create.cshtml"
   Write(RenderPage("~/Areas/UCenter/Views/UserConfig/Extend/Model_FormHtml.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </form>\r\n</div>\r\n<div");

WriteLiteral(" region=\"south\"");

WriteLiteral(" border=\"false\"");

WriteLiteral(" style=\"text-align: right; background: #F6F6F6;height: 30px; line-height: 30px;\"");

WriteLiteral(">\r\n    <a");

WriteLiteral(" id=\"btnSubmit\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" icon=\"icon-ok\"");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(">确定</a>\r\n    <a");

WriteLiteral(" id=\"btnCancel\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" icon=\"icon-cancel\"");

WriteLiteral(" href=\"javascript:CloseDialog();\"");

WriteLiteral(">\r\n        取消\r\n    </a>\r\n</div>\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" src=\"/Resources/JsLib/jquery.form.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"/Resources/JsLib/My97DatePicker/WdatePicker.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"/Static/v1/js/Utils.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"/Static/v1/js/form.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
        jQuery(function() {
            CheckConditions();
function CheckConditions(){
jQuery('fieldset').show(); 
jQuery(""fieldset"").each(function(){ 
if(jQuery('tr',this).length>0){
if(jQuery('tr:visible',this).length>0){jQuery(this).show()} else{jQuery(this).hide()}
}
});
}
;
        });
    </script>
");

WriteLiteral("    ");

            
            #line 88 "..\..\Areas\UCenter\Views\UserConfig\_\Create.cshtml"
Write(RenderPage("~/Areas/UCenter/Views/UserConfig/Extend/Model_FormJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591