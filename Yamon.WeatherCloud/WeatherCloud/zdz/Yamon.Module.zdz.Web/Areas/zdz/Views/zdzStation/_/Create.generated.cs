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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/zdz/Views/zdzStation/_/Create.cshtml")]
    public partial class _Areas_zdz_Views_zdzStation___Create_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_zdz_Views_zdzStation___Create_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
  
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
    ViewBag.Title="新建自动站站点";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" region=\"center\"");

WriteLiteral(" border=\"true\"");

WriteLiteral(" style=\"padding: 10px; background: #F6F6F6; border: 1px solid #ccc;\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"myForm\"");

WriteLiteral(" name=\"myForm\"");

WriteLiteral(" action=\"/api/zdz/zdzStation/Create\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"mytable\"");

WriteLiteral("  cellpadding=\"1\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n<tr");

WriteLiteral(" id=\"Container_StationID\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">站点编号：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"StationID\"");

WriteLiteral(" name=\"StationID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 836), Tuple.Create("\"", 862)
            
            #line 22 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 844), Tuple.Create<System.Object, System.Int32>(Model.StationID
            
            #line default
            #line hidden
, 844), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral(" required=\"true\"");

WriteLiteral("  maxlength=\"50\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">站点名称：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"StationName\"");

WriteLiteral(" name=\"StationName\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1058), Tuple.Create("\"", 1086)
            
            #line 25 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1066), Tuple.Create<System.Object, System.Int32>(Model.StationName
            
            #line default
            #line hidden
, 1066), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"50\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_ParentID\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">上级站点：</td><td>&nbsp;\r\n\r\n<input");

WriteLiteral(" id=\"ParentID\"");

WriteLiteral(" name=\"ParentID\"");

WriteAttribute("url", Tuple.Create(" url=\"", 1287), Tuple.Create("\"", 1356)
, Tuple.Create(Tuple.Create("", 1293), Tuple.Create("/api/zdz/zdzStation/EditTree?&iscombo=1&Value=", 1293), true)
            
            #line 31 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
         , Tuple.Create(Tuple.Create("", 1339), Tuple.Create<System.Object, System.Int32>(Model.ParentID
            
            #line default
            #line hidden
, 1339), false)
);

WriteAttribute("value", Tuple.Create(" value=\"", 1357), Tuple.Create("\"", 1382)
            
            #line 31 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
                                   , Tuple.Create(Tuple.Create("", 1365), Tuple.Create<System.Object, System.Int32>(Model.ParentID
            
            #line default
            #line hidden
, 1365), false)
);

WriteLiteral(" style=\"width: 200px\"");

WriteLiteral(" required=\"true\"");

WriteLiteral(" />\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n    var ParentID_Value = \'");

            
            #line 33 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
                      Write(Model.ParentID);

            
            #line default
            #line hidden
WriteLiteral(@"';
    jQuery(function() {
        jQuery('#ParentID').combotree(
        {
            onLoadSuccess:function(node, data) {
                jQuery('#ParentID').combotree('setValue',ParentID_Value);
            }
        });
    });
</script>
</td>
<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">站点级别：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"StationLevel\"");

WriteLiteral(" name=\"StationLevel\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1859), Tuple.Create("\"", 1888)
            
            #line 45 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 1867), Tuple.Create<System.Object, System.Int32>(Model.StationLevel
            
            #line default
            #line hidden
, 1867), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"4\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_StationType\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">站点类型：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"StationType\"");

WriteLiteral(" name=\"StationType\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2107), Tuple.Create("\"", 2135)
            
            #line 50 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 2115), Tuple.Create<System.Object, System.Int32>(Model.StationType
            
            #line default
            #line hidden
, 2115), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"4\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">经度：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Latitude\"");

WriteLiteral(" name=\"Latitude\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2306), Tuple.Create("\"", 2331)
            
            #line 53 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 2314), Tuple.Create<System.Object, System.Int32>(Model.Latitude
            
            #line default
            #line hidden
, 2314), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"8\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_Longitude\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">纬度：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Longitude\"");

WriteLiteral(" name=\"Longitude\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2542), Tuple.Create("\"", 2568)
            
            #line 58 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 2550), Tuple.Create<System.Object, System.Int32>(Model.Longitude
            
            #line default
            #line hidden
, 2550), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"8\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">状态：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Status\"");

WriteLiteral(" name=\"Status\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2735), Tuple.Create("\"", 2758)
            
            #line 61 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 2743), Tuple.Create<System.Object, System.Int32>(Model.Status
            
            #line default
            #line hidden
, 2743), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"4\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_AltitudeHeight\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">海拔：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"AltitudeHeight\"");

WriteLiteral(" name=\"AltitudeHeight\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2984), Tuple.Create("\"", 3015)
            
            #line 66 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 2992), Tuple.Create<System.Object, System.Int32>(Model.AltitudeHeight
            
            #line default
            #line hidden
, 2992), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"50\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">排序号：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"OrderID\"");

WriteLiteral(" name=\"OrderID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3186), Tuple.Create("\"", 3210)
            
            #line 69 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 3194), Tuple.Create<System.Object, System.Int32>(Model.OrderID
            
            #line default
            #line hidden
, 3194), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"4\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_Lon\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">经度：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Lon\"");

WriteLiteral(" name=\"Lon\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3403), Tuple.Create("\"", 3423)
            
            #line 74 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 3411), Tuple.Create<System.Object, System.Int32>(Model.Lon
            
            #line default
            #line hidden
, 3411), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"8\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">纬度：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"Lat\"");

WriteLiteral(" name=\"Lat\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3584), Tuple.Create("\"", 3604)
            
            #line 77 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
, Tuple.Create(Tuple.Create("", 3592), Tuple.Create<System.Object, System.Int32>(Model.Lat
            
            #line default
            #line hidden
, 3592), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"8\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n\r\n</table>\r\n\r\n");

WriteLiteral("        ");

            
            #line 83 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
   Write(RenderPage("~/Areas/zdz/Views/zdzStation/Extend/Model_FormHtml.cshtml"));

            
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

            
            #line 111 "..\..\Areas\zdz\Views\zdzStation\_\Create.cshtml"
Write(RenderPage("~/Areas/zdz/Views/zdzStation/Extend/Model_FormJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591