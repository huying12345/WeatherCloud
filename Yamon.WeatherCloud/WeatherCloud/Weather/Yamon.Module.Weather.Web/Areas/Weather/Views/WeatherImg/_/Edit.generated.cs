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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Weather/Views/WeatherImg/_/Edit.cshtml")]
    public partial class _Areas_Weather_Views_WeatherImg___Edit_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_Weather_Views_WeatherImg___Edit_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\Weather\Views\WeatherImg\_\Edit.cshtml"
  
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
    ViewBag.Title="编辑图片";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" region=\"center\"");

WriteLiteral(" border=\"true\"");

WriteLiteral(" style=\"padding: 10px; background: #FFFFFF; border: 1px solid #ccc;\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"myForm\"");

WriteLiteral(" name=\"myForm\"");

WriteLiteral(" action=\"/api/Weather/WeatherImg/Edit\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"mytable\"");

WriteLiteral("  cellpadding=\"1\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n<tr");

WriteLiteral(" id=\"Container_InfoTitle\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">标题：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"InfoTitle\"");

WriteLiteral(" name=\"InfoTitle\"");

WriteAttribute("value", Tuple.Create(" value=\"", 833), Tuple.Create("\"", 859)
            
            #line 22 "..\..\Areas\Weather\Views\WeatherImg\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 841), Tuple.Create<System.Object, System.Int32>(Model.InfoTitle
            
            #line default
            #line hidden
, 841), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"500\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">路径：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"InfoPath\"");

WriteLiteral(" name=\"InfoPath\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1032), Tuple.Create("\"", 1057)
            
            #line 25 "..\..\Areas\Weather\Views\WeatherImg\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1040), Tuple.Create<System.Object, System.Int32>(Model.InfoPath
            
            #line default
            #line hidden
, 1040), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"500\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_DataTime\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">数据时次：</td><td>&nbsp;    <input");

WriteLiteral(" class=\"Wdate\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" onClick=\"WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm\'})\"");

WriteLiteral(" id=\"DataTime\"");

WriteLiteral(" name=\"DataTime\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1337), Tuple.Create("\"", 1372)
            
            #line 29 "..\..\Areas\Weather\Views\WeatherImg\_\Edit.cshtml"
                                                                                       , Tuple.Create(Tuple.Create("", 1345), Tuple.Create<System.Object, System.Int32>(Model.DataTime_ShowValue
            
            #line default
            #line hidden
, 1345), false)
);

WriteLiteral(" style=\"width:135px;\"");

WriteLiteral(">\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">入库时间：</td><td>&nbsp;    <input");

WriteLiteral(" class=\"Wdate\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" onClick=\"WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm\'})\"");

WriteLiteral(" id=\"CreateTime\"");

WriteLiteral(" name=\"CreateTime\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1566), Tuple.Create("\"", 1603)
            
            #line 31 "..\..\Areas\Weather\Views\WeatherImg\_\Edit.cshtml"
                                                                                           , Tuple.Create(Tuple.Create("", 1574), Tuple.Create<System.Object, System.Int32>(Model.CreateTime_ShowValue
            
            #line default
            #line hidden
, 1574), false)
);

WriteLiteral(" style=\"width:135px;\"");

WriteLiteral(">\r\n</td>\r\n</tr>\r\n<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"ID\"");

WriteLiteral("  name=\"ID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1681), Tuple.Create("\"", 1700)
            
            #line 34 "..\..\Areas\Weather\Views\WeatherImg\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1689), Tuple.Create<System.Object, System.Int32>(Model.ID
            
            #line default
            #line hidden
, 1689), false)
);

WriteLiteral("/>\r\n</table>\r\n\r\n");

WriteLiteral("        ");

            
            #line 37 "..\..\Areas\Weather\Views\WeatherImg\_\Edit.cshtml"
   Write(RenderPage("~/Areas/Weather/Views/WeatherImg/Extend/Model_FormHtml.cshtml"));

            
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

            
            #line 65 "..\..\Areas\Weather\Views\WeatherImg\_\Edit.cshtml"
Write(RenderPage("~/Areas/Weather/Views/WeatherImg/Extend/Model_FormJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
