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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/zdz/Views/zdzinstantHistory/_/Show.cshtml")]
    public partial class _Areas_zdz_Views_zdzinstantHistory___Show_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_zdz_Views_zdzinstantHistory___Show_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
  
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

WriteLiteral(" action=\"/api/zdz/zdzinstantHistory/Show\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"mytable\"");

WriteLiteral("  cellpadding=\"1\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n<tr");

WriteLiteral(" id=\"Container_ID\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">编号：</td><td>&nbsp;<span");

WriteLiteral(" id=\"ID\"");

WriteLiteral(">");

            
            #line 19 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                Write(Html.Raw(Model.ID));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">站名：</td><td>&nbsp;<span");

WriteLiteral(" id=\"station\"");

WriteLiteral(">");

            
            #line 20 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                     Write(Html.Raw(Model.station));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_instant_vis\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">能见度：</td><td>&nbsp;<span");

WriteLiteral(" id=\"instant_vis\"");

WriteLiteral(">");

            
            #line 23 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                          Write(Html.Raw(Model.instant_vis));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">十分钟平均能见度：</td><td>&nbsp;<span");

WriteLiteral(" id=\"ten_aver_vis\"");

WriteLiteral(">");

            
            #line 24 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                                Write(Html.Raw(Model.ten_aver_vis));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_two_aver_wd\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">两分钟平均风向：</td><td>&nbsp;<span");

WriteLiteral(" id=\"two_aver_wd\"");

WriteLiteral(">");

            
            #line 27 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                              Write(Html.Raw(Model.two_aver_wd));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">两分钟平均风力：</td><td>&nbsp;<span");

WriteLiteral(" id=\"two_aver_ws\"");

WriteLiteral(">");

            
            #line 28 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                              Write(Html.Raw(Model.two_aver_ws));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_ten_aver_wd\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">十分钟平均风向：</td><td>&nbsp;<span");

WriteLiteral(" id=\"ten_aver_wd\"");

WriteLiteral(">");

            
            #line 31 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                              Write(Html.Raw(Model.ten_aver_wd));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">十分钟平均风力：</td><td>&nbsp;<span");

WriteLiteral(" id=\"ten_aver_ws\"");

WriteLiteral(">");

            
            #line 32 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                              Write(Html.Raw(Model.ten_aver_ws));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_date\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">数据时次：</td><td>&nbsp;<span");

WriteLiteral(" id=\"date\"");

WriteLiteral(">");

            
            #line 35 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                    Write(Html.Raw(Model.date));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">十分钟最大风向：</td><td>&nbsp;<span");

WriteLiteral(" id=\"ten_max_wd\"");

WriteLiteral(">");

            
            #line 36 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                             Write(Html.Raw(Model.ten_max_wd));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_ten_max_ws\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">十分钟最大风力：</td><td>&nbsp;<span");

WriteLiteral(" id=\"ten_max_ws\"");

WriteLiteral(">");

            
            #line 39 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                             Write(Html.Raw(Model.ten_max_ws));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">十分钟最大风力时间：</td><td>&nbsp;<span");

WriteLiteral(" id=\"ten_maxws_time\"");

WriteLiteral(">");

            
            #line 40 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                                   Write(Html.Raw(Model.ten_maxws_time));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_instant_wd\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">瞬时风向：</td><td>&nbsp;<span");

WriteLiteral(" id=\"instant_wd\"");

WriteLiteral(">");

            
            #line 43 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                          Write(Html.Raw(Model.instant_wd));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">瞬时风力：</td><td>&nbsp;<span");

WriteLiteral(" id=\"instant_ws\"");

WriteLiteral(">");

            
            #line 44 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                          Write(Html.Raw(Model.instant_ws));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_one_rain\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">一小时降雨量：</td><td>&nbsp;<span");

WriteLiteral(" id=\"one_rain\"");

WriteLiteral(">");

            
            #line 47 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                          Write(Html.Raw(Model.one_rain));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">温度：</td><td>&nbsp;<span");

WriteLiteral(" id=\"temper\"");

WriteLiteral(">");

            
            #line 48 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                    Write(Html.Raw(Model.temper));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_max_temper\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最高温度：</td><td>&nbsp;<span");

WriteLiteral(" id=\"max_temper\"");

WriteLiteral(">");

            
            #line 51 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                          Write(Html.Raw(Model.max_temper));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最低温度：</td><td>&nbsp;<span");

WriteLiteral(" id=\"min_temper\"");

WriteLiteral(">");

            
            #line 52 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                          Write(Html.Raw(Model.min_temper));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_rel_humi\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">湿度：</td><td>&nbsp;<span");

WriteLiteral(" id=\"rel_humi\"");

WriteLiteral(">");

            
            #line 55 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                      Write(Html.Raw(Model.rel_humi));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最小湿度：</td><td>&nbsp;<span");

WriteLiteral(" id=\"min_relhumi\"");

WriteLiteral(">");

            
            #line 56 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                           Write(Html.Raw(Model.min_relhumi));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_dew_point\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">露点：</td><td>&nbsp;<span");

WriteLiteral(" id=\"dew_point\"");

WriteLiteral(">");

            
            #line 59 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                       Write(Html.Raw(Model.dew_point));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">气压：</td><td>&nbsp;<span");

WriteLiteral(" id=\"air_press\"");

WriteLiteral(">");

            
            #line 60 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                       Write(Html.Raw(Model.air_press));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_max_press\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最大气压：</td><td>&nbsp;<span");

WriteLiteral(" id=\"max_press\"");

WriteLiteral(">");

            
            #line 63 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                         Write(Html.Raw(Model.max_press));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最小气压：</td><td>&nbsp;<span");

WriteLiteral(" id=\"min_press\"");

WriteLiteral(">");

            
            #line 64 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
                                                         Write(Html.Raw(Model.min_press));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n</tr>\r\n\r\n</table>\r\n\r\n");

WriteLiteral("        ");

            
            #line 69 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
   Write(RenderPage("~/Areas/zdz/Views/zdzinstantHistory/Extend/Model_ViewHtml.cshtml"));

            
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

            
            #line 77 "..\..\Areas\zdz\Views\zdzinstantHistory\_\Show.cshtml"
Write(RenderPage("~/Areas/zdz/Views/zdzinstantHistory/Extend/Model_ViewJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
