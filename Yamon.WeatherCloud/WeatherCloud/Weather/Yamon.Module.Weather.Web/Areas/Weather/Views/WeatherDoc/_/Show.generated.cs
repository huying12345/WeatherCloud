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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Weather/Views/WeatherDoc/_/Show.cshtml")]
    public partial class _Areas_Weather_Views_WeatherDoc___Show_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_Weather_Views_WeatherDoc___Show_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\Weather\Views\WeatherDoc\_\Show.cshtml"
  
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

WriteLiteral(" action=\"/api/Weather/WeatherDoc/Show\"");

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

WriteLiteral(">类型名称：</td><td>&nbsp;<span");

WriteLiteral(" id=\"InfoTitle\"");

WriteLiteral(">");

            
            #line 19 "..\..\Areas\Weather\Views\WeatherDoc\_\Show.cshtml"
                                                         Write(Html.Raw(Model.InfoTitle));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">路径：</td><td>&nbsp;<span");

WriteLiteral(" id=\"InfoPath\"");

WriteLiteral(">");

            
            #line 20 "..\..\Areas\Weather\Views\WeatherDoc\_\Show.cshtml"
                                                      Write(Html.Raw(Model.InfoPath));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_DataTime\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">数据时次：</td><td>&nbsp;<span");

WriteLiteral(" id=\"DataTime\"");

WriteLiteral(">");

            
            #line 23 "..\..\Areas\Weather\Views\WeatherDoc\_\Show.cshtml"
                                                        Write(Html.Raw(Model.DataTime_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">入库时间：</td><td>&nbsp;<span");

WriteLiteral(" id=\"CreateTime\"");

WriteLiteral(">");

            
            #line 24 "..\..\Areas\Weather\Views\WeatherDoc\_\Show.cshtml"
                                                          Write(Html.Raw(Model.CreateTime_ShowValue));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n\r\n</table>\r\n\r\n");

WriteLiteral("        ");

            
            #line 29 "..\..\Areas\Weather\Views\WeatherDoc\_\Show.cshtml"
   Write(RenderPage("~/Areas/Weather/Views/WeatherDoc/Extend/Model_ViewHtml.cshtml"));

            
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

            
            #line 37 "..\..\Areas\Weather\Views\WeatherDoc\_\Show.cshtml"
Write(RenderPage("~/Areas/Weather/Views/WeatherDoc/Extend/Model_ViewJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591