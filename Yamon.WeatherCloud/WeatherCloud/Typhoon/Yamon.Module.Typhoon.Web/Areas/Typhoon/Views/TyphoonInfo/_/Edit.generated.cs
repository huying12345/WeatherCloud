﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Typhoon/Views/TyphoonInfo/_/Edit.cshtml")]
    public partial class _Areas_Typhoon_Views_TyphoonInfo___Edit_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_Typhoon_Views_TyphoonInfo___Edit_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\Typhoon\Views\TyphoonInfo\_\Edit.cshtml"
  
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
    ViewBag.Title="编辑台风信息";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" region=\"center\"");

WriteLiteral(" border=\"true\"");

WriteLiteral(" style=\"padding: 10px; background: #F6F6F6; border: 1px solid #ccc;\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"myForm\"");

WriteLiteral(" name=\"myForm\"");

WriteLiteral(" action=\"/api/Typhoon/TyphoonInfo/Edit\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"mytable\"");

WriteLiteral("  cellpadding=\"1\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n<tr");

WriteLiteral(" id=\"Container_EnName\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">台风英文名称：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"EnName\"");

WriteLiteral(" name=\"EnName\"");

WriteAttribute("value", Tuple.Create(" value=\"", 831), Tuple.Create("\"", 854)
            
            #line 22 "..\..\Areas\Typhoon\Views\TyphoonInfo\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 839), Tuple.Create<System.Object, System.Int32>(Model.EnName
            
            #line default
            #line hidden
, 839), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"30\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">台风中文名称：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"CnName\"");

WriteLiteral(" name=\"CnName\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1026), Tuple.Create("\"", 1049)
            
            #line 25 "..\..\Areas\Typhoon\Views\TyphoonInfo\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1034), Tuple.Create<System.Object, System.Int32>(Model.CnName
            
            #line default
            #line hidden
, 1034), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"30\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_DataInfo\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">台风数据说明：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"DataInfo\"");

WriteLiteral(" name=\"DataInfo\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1262), Tuple.Create("\"", 1287)
            
            #line 30 "..\..\Areas\Typhoon\Views\TyphoonInfo\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1270), Tuple.Create<System.Object, System.Int32>(Model.DataInfo
            
            #line default
            #line hidden
, 1270), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"200\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">发报中心：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"ReportCenter\"");

WriteLiteral(" name=\"ReportCenter\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1470), Tuple.Create("\"", 1499)
            
            #line 33 "..\..\Areas\Typhoon\Views\TyphoonInfo\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1478), Tuple.Create<System.Object, System.Int32>(Model.ReportCenter
            
            #line default
            #line hidden
, 1478), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"200\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_TYear\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">台风发生年：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"TYear\"");

WriteLiteral(" name=\"TYear\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1703), Tuple.Create("\"", 1725)
            
            #line 38 "..\..\Areas\Typhoon\Views\TyphoonInfo\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1711), Tuple.Create<System.Object, System.Int32>(Model.TYear
            
            #line default
            #line hidden
, 1711), false)
);

WriteLiteral(" class=\"easyui-numberbox\"");

WriteLiteral(" min=\"1900\"");

WriteLiteral(" max=\"2999\"");

WriteLiteral("  style=\"width:200px;\"");

WriteLiteral("/>\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最新预报时间：</td><td>&nbsp;    <input");

WriteLiteral(" class=\"Wdate\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" onClick=\"WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm:ss\'})\"");

WriteLiteral(" id=\"LastReportTime\"");

WriteLiteral(" name=\"LastReportTime\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1981), Tuple.Create("\"", 2074)
            
            #line 40 "..\..\Areas\Typhoon\Views\TyphoonInfo\_\Edit.cshtml"
                                                                                                        , Tuple.Create(Tuple.Create("", 1989), Tuple.Create<System.Object, System.Int32>(Model.LastReportTime==null?"":Model.LastReportTime.ToString("yyyy-MM-dd HH:mm:ss")
            
            #line default
            #line hidden
, 1989), false)
);

WriteLiteral(" style=\"width:135px;\"");

WriteLiteral(">\r\n</td>\r\n</tr>\r\n<input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id=\"TyphoonID\"");

WriteLiteral("  name=\"TyphoonID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2166), Tuple.Create("\"", 2192)
            
            #line 43 "..\..\Areas\Typhoon\Views\TyphoonInfo\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 2174), Tuple.Create<System.Object, System.Int32>(Model.TyphoonID
            
            #line default
            #line hidden
, 2174), false)
);

WriteLiteral("/>\r\n</table>\r\n\r\n");

WriteLiteral("        ");

            
            #line 46 "..\..\Areas\Typhoon\Views\TyphoonInfo\_\Edit.cshtml"
   Write(RenderPage("~/Areas/Typhoon/Views/TyphoonInfo/Extend/Model_FormHtml.cshtml"));

            
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

            
            #line 74 "..\..\Areas\Typhoon\Views\TyphoonInfo\_\Edit.cshtml"
Write(RenderPage("~/Areas/Typhoon/Views/TyphoonInfo/Extend/Model_FormJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
