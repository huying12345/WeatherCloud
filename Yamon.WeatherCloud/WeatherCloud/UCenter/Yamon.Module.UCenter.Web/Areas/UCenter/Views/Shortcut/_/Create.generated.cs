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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/UCenter/Views/Shortcut/_/Create.cshtml")]
    public partial class _Areas_UCenter_Views_Shortcut___Create_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_UCenter_Views_Shortcut___Create_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\UCenter\Views\Shortcut\_\Create.cshtml"
  
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
    ViewBag.Title="新建快捷菜单";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" region=\"center\"");

WriteLiteral(" border=\"true\"");

WriteLiteral(" style=\"padding: 10px; background: #F6F6F6; border: 1px solid #ccc;\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"myForm\"");

WriteLiteral(" name=\"myForm\"");

WriteLiteral(" action=\"/UCenter/Shortcut/CreateAction\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"mytable\"");

WriteLiteral("  cellpadding=\"1\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n<tr");

WriteLiteral(" id=\"Container_LinkType\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_LinkType\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">链接类型：</td><td>&nbsp;\r\n<select");

WriteLiteral(" id=\"LinkType\"");

WriteLiteral(" class=\"easyui-combobox\"");

WriteLiteral(" name=\"LinkType\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(">\r\n<option");

WriteLiteral(" value=\"\"");

WriteLiteral(">请选择</option>\r\n");

            
            #line 23 "..\..\Areas\UCenter\Views\Shortcut\_\Create.cshtml"
Write(Html.Raw(MyHtmlHelper2.ShowSelectOptions(ViewBag.DAL.NameValue_LinkType, Model.LinkType)));

            
            #line default
            #line hidden
WriteLiteral("\r\n</select></td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_LinkName\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_LinkName\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">链接名称：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"LinkName\"");

WriteLiteral(" name=\"LinkName\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1172), Tuple.Create("\"", 1197)
            
            #line 26 "..\..\Areas\UCenter\Views\Shortcut\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1180), Tuple.Create<System.Object, System.Int32>(Model.LinkName
            
            #line default
            #line hidden
, 1180), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"50\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_LinkUrl\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_LinkUrl\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">链接地址：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"LinkUrl\"");

WriteLiteral(" name=\"LinkUrl\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1420), Tuple.Create("\"", 1444)
            
            #line 29 "..\..\Areas\UCenter\Views\Shortcut\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1428), Tuple.Create<System.Object, System.Int32>(Model.LinkUrl
            
            #line default
            #line hidden
, 1428), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"500\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td></tr>\r\n<tr");

WriteLiteral(" id=\"Container_LinkMenuID\"");

WriteLiteral("><td");

WriteLiteral(" id=\"Label_LinkMenuID\"");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">链接菜单：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"LinkMenuID\"");

WriteLiteral(" name=\"LinkMenuID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1680), Tuple.Create("\"", 1707)
            
            #line 32 "..\..\Areas\UCenter\Views\Shortcut\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1688), Tuple.Create<System.Object, System.Int32>(Model.LinkMenuID
            
            #line default
            #line hidden
, 1688), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"50\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td></tr>\r\n<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"UserID\"");

WriteLiteral("  name=\"UserID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1843), Tuple.Create("\"", 1866)
            
            #line 34 "..\..\Areas\UCenter\Views\Shortcut\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1851), Tuple.Create<System.Object, System.Int32>(Model.UserID
            
            #line default
            #line hidden
, 1851), false)
);

WriteLiteral("/>\r\n</table>\r\n\r\n");

WriteLiteral("        ");

            
            #line 37 "..\..\Areas\UCenter\Views\Shortcut\_\Create.cshtml"
   Write(RenderPage("~/Areas/UCenter/Views/Shortcut/Extend/Model_FormHtml.cshtml"));

            
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
        jQuery(function () {
            CheckConditions();
jQuery('#LinkType').bind('change', CheckConditions);
function CheckConditions(){
if((jQuery('#LinkType').val() == '1'||jQuery('#LinkType').val() == '2'||jQuery('#LinkType').val() == '3')){
jQuery('#Container_LinkMenuID').show();
} 
else{ 
jQuery('#Container_LinkMenuID').hide();
} 
if(jQuery('#LinkType').val() == '0'){
jQuery('#Container_LinkUrl').show();
} 
else{ 
jQuery('#Container_LinkUrl').hide();
} 
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

});

WriteLiteral(";\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
