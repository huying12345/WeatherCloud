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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/zdz/Views/zdzinstant/_/Edit.cshtml")]
    public partial class _Areas_zdz_Views_zdzinstant___Edit_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_zdz_Views_zdzinstant___Edit_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
  
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
    ViewBag.Title="编辑自动站数据";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" region=\"center\"");

WriteLiteral(" border=\"true\"");

WriteLiteral(" style=\"padding: 10px; background: #F6F6F6; border: 1px solid #ccc;\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"myForm\"");

WriteLiteral(" name=\"myForm\"");

WriteLiteral(" action=\"/api/zdz/zdzinstant/Edit\"");

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

WriteLiteral(">编号：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"ID\"");

WriteLiteral(" name=\"ID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 811), Tuple.Create("\"", 830)
            
            #line 22 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 819), Tuple.Create<System.Object, System.Int32>(Model.ID
            
            #line default
            #line hidden
, 819), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral(" required=\"true\"");

WriteLiteral("  maxlength=\"30\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">站名：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"station\"");

WriteLiteral(" name=\"station\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1016), Tuple.Create("\"", 1040)
            
            #line 25 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1024), Tuple.Create<System.Object, System.Int32>(Model.station
            
            #line default
            #line hidden
, 1024), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"30\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_sun_rad\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">太阳辐射：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"sun_rad\"");

WriteLiteral(" name=\"sun_rad\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1248), Tuple.Create("\"", 1272)
            
            #line 30 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1256), Tuple.Create<System.Object, System.Int32>(Model.sun_rad
            
            #line default
            #line hidden
, 1256), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">平均太阳辐射：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"aver_rad\"");

WriteLiteral(" name=\"aver_rad\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1447), Tuple.Create("\"", 1472)
            
            #line 33 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1455), Tuple.Create<System.Object, System.Int32>(Model.aver_rad
            
            #line default
            #line hidden
, 1455), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_max_rad\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最高太阳辐射：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"max_rad\"");

WriteLiteral(" name=\"max_rad\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1681), Tuple.Create("\"", 1705)
            
            #line 38 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1689), Tuple.Create<System.Object, System.Int32>(Model.max_rad
            
            #line default
            #line hidden
, 1689), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最高太阳辐射时间：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"max_rad_time\"");

WriteLiteral(" name=\"max_rad_time\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1890), Tuple.Create("\"", 1919)
            
            #line 41 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 1898), Tuple.Create<System.Object, System.Int32>(Model.max_rad_time
            
            #line default
            #line hidden
, 1898), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_uv\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">uv：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"uv\"");

WriteLiteral(" name=\"uv\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2109), Tuple.Create("\"", 2128)
            
            #line 46 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 2117), Tuple.Create<System.Object, System.Int32>(Model.uv
            
            #line default
            #line hidden
, 2117), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">aver_uv：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"aver_uv\"");

WriteLiteral(" name=\"aver_uv\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2302), Tuple.Create("\"", 2326)
            
            #line 49 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 2310), Tuple.Create<System.Object, System.Int32>(Model.aver_uv
            
            #line default
            #line hidden
, 2310), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_max_uv\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">max_uv：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"max_uv\"");

WriteLiteral(" name=\"max_uv\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2532), Tuple.Create("\"", 2555)
            
            #line 54 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 2540), Tuple.Create<System.Object, System.Int32>(Model.max_uv
            
            #line default
            #line hidden
, 2540), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">max_uv_time：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"max_uv_time\"");

WriteLiteral(" name=\"max_uv_time\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2741), Tuple.Create("\"", 2769)
            
            #line 57 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 2749), Tuple.Create<System.Object, System.Int32>(Model.max_uv_time
            
            #line default
            #line hidden
, 2749), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_instant_vis\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">能见度：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"instant_vis\"");

WriteLiteral(" name=\"instant_vis\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2987), Tuple.Create("\"", 3015)
            
            #line 62 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 2995), Tuple.Create<System.Object, System.Int32>(Model.instant_vis
            
            #line default
            #line hidden
, 2995), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"9\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">十分钟平均能见度：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"ten_aver_vis\"");

WriteLiteral(" name=\"ten_aver_vis\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3200), Tuple.Create("\"", 3229)
            
            #line 65 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 3208), Tuple.Create<System.Object, System.Int32>(Model.ten_aver_vis
            
            #line default
            #line hidden
, 3208), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"9\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_two_aver_wd\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">两分钟平均风向：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"two_aver_wd\"");

WriteLiteral(" name=\"two_aver_wd\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3451), Tuple.Create("\"", 3479)
            
            #line 70 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 3459), Tuple.Create<System.Object, System.Int32>(Model.two_aver_wd
            
            #line default
            #line hidden
, 3459), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"6\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">两分钟平均风力：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"two_aver_ws\"");

WriteLiteral(" name=\"two_aver_ws\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3661), Tuple.Create("\"", 3689)
            
            #line 73 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 3669), Tuple.Create<System.Object, System.Int32>(Model.two_aver_ws
            
            #line default
            #line hidden
, 3669), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_ten_aver_wd\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">十分钟平均风向：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"ten_aver_wd\"");

WriteLiteral(" name=\"ten_aver_wd\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3911), Tuple.Create("\"", 3939)
            
            #line 78 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 3919), Tuple.Create<System.Object, System.Int32>(Model.ten_aver_wd
            
            #line default
            #line hidden
, 3919), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"6\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">十分钟平均风力：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"ten_aver_ws\"");

WriteLiteral(" name=\"ten_aver_ws\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4121), Tuple.Create("\"", 4149)
            
            #line 81 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 4129), Tuple.Create<System.Object, System.Int32>(Model.ten_aver_ws
            
            #line default
            #line hidden
, 4129), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_date\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">数据时次：</td><td>&nbsp;    <input");

WriteLiteral(" class=\"Wdate\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" onClick=\"WdatePicker({dateFmt:\'yyyy-MM-dd HH:mm:ss\'})\"");

WriteLiteral(" id=\"date\"");

WriteLiteral(" name=\"date\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4418), Tuple.Create("\"", 4491)
            
            #line 85 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
                                                                                  , Tuple.Create(Tuple.Create("", 4426), Tuple.Create<System.Object, System.Int32>(Model.date==null?"":Model.date.ToString("yyyy-MM-dd HH:mm:ss")
            
            #line default
            #line hidden
, 4426), false)
);

WriteLiteral(" style=\"width:135px;\"");

WriteLiteral(">\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">十分钟最大风向：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"ten_max_wd\"");

WriteLiteral(" name=\"ten_max_wd\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4620), Tuple.Create("\"", 4647)
            
            #line 88 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 4628), Tuple.Create<System.Object, System.Int32>(Model.ten_max_wd
            
            #line default
            #line hidden
, 4628), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"6\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_ten_max_ws\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">十分钟最大风力：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"ten_max_ws\"");

WriteLiteral(" name=\"ten_max_ws\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4866), Tuple.Create("\"", 4893)
            
            #line 93 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 4874), Tuple.Create<System.Object, System.Int32>(Model.ten_max_ws
            
            #line default
            #line hidden
, 4874), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">十分钟最大风力时间：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"ten_maxws_time\"");

WriteLiteral(" name=\"ten_maxws_time\"");

WriteAttribute("value", Tuple.Create(" value=\"", 5083), Tuple.Create("\"", 5114)
            
            #line 96 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 5091), Tuple.Create<System.Object, System.Int32>(Model.ten_maxws_time
            
            #line default
            #line hidden
, 5091), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_instant_wd\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">瞬时风向：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"instant_wd\"");

WriteLiteral(" name=\"instant_wd\"");

WriteAttribute("value", Tuple.Create(" value=\"", 5330), Tuple.Create("\"", 5357)
            
            #line 101 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 5338), Tuple.Create<System.Object, System.Int32>(Model.instant_wd
            
            #line default
            #line hidden
, 5338), false)
);

WriteLiteral(" class=\"easyui-numberbox\"");

WriteLiteral(" min=\"0\"");

WriteLiteral(" max=\"1000\"");

WriteLiteral("  precision=\"0\"");

WriteLiteral(" style=\"width:200px;\"");

WriteLiteral("/>\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">瞬时风力：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"instant_ws\"");

WriteLiteral(" name=\"instant_ws\"");

WriteAttribute("value", Tuple.Create(" value=\"", 5543), Tuple.Create("\"", 5570)
            
            #line 104 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 5551), Tuple.Create<System.Object, System.Int32>(Model.instant_ws
            
            #line default
            #line hidden
, 5551), false)
);

WriteLiteral(" class=\"easyui-numberbox\"");

WriteLiteral(" min=\"0\"");

WriteLiteral(" max=\"1000\"");

WriteLiteral("  precision=\"1\"");

WriteLiteral(" style=\"width:200px;\"");

WriteLiteral("/>\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_max_flu_wd\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">max_flu_wd：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"max_flu_wd\"");

WriteLiteral(" name=\"max_flu_wd\"");

WriteAttribute("value", Tuple.Create(" value=\"", 5801), Tuple.Create("\"", 5828)
            
            #line 109 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 5809), Tuple.Create<System.Object, System.Int32>(Model.max_flu_wd
            
            #line default
            #line hidden
, 5809), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"6\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">max_flu_ws：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"max_flu_ws\"");

WriteLiteral(" name=\"max_flu_ws\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6011), Tuple.Create("\"", 6038)
            
            #line 112 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 6019), Tuple.Create<System.Object, System.Int32>(Model.max_flu_ws
            
            #line default
            #line hidden
, 6019), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_max_flu_time\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">max_flu_time：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"max_flu_time\"");

WriteLiteral(" name=\"max_flu_time\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6268), Tuple.Create("\"", 6297)
            
            #line 117 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 6276), Tuple.Create<System.Object, System.Int32>(Model.max_flu_time
            
            #line default
            #line hidden
, 6276), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">一小时降雨量：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"one_rain\"");

WriteLiteral(" name=\"one_rain\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6472), Tuple.Create("\"", 6497)
            
            #line 120 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 6480), Tuple.Create<System.Object, System.Int32>(Model.one_rain
            
            #line default
            #line hidden
, 6480), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_temper\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">温度：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"temper\"");

WriteLiteral(" name=\"temper\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6699), Tuple.Create("\"", 6722)
            
            #line 125 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 6707), Tuple.Create<System.Object, System.Int32>(Model.temper
            
            #line default
            #line hidden
, 6707), false)
);

WriteLiteral(" class=\"easyui-numberbox\"");

WriteLiteral(" min=\"0\"");

WriteLiteral(" max=\"1000\"");

WriteLiteral("  style=\"width:200px;\"");

WriteLiteral("/>\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最高温度：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"max_temper\"");

WriteLiteral(" name=\"max_temper\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6894), Tuple.Create("\"", 6921)
            
            #line 128 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 6902), Tuple.Create<System.Object, System.Int32>(Model.max_temper
            
            #line default
            #line hidden
, 6902), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_max_temp_time\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最高温度时间：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"max_temp_time\"");

WriteLiteral(" name=\"max_temp_time\"");

WriteAttribute("value", Tuple.Create(" value=\"", 7148), Tuple.Create("\"", 7178)
            
            #line 133 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 7156), Tuple.Create<System.Object, System.Int32>(Model.max_temp_time
            
            #line default
            #line hidden
, 7156), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最低温度：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"min_temper\"");

WriteLiteral(" name=\"min_temper\"");

WriteAttribute("value", Tuple.Create(" value=\"", 7355), Tuple.Create("\"", 7382)
            
            #line 136 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 7363), Tuple.Create<System.Object, System.Int32>(Model.min_temper
            
            #line default
            #line hidden
, 7363), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_min_temp_time\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最低温度时间：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"min_temp_time\"");

WriteLiteral(" name=\"min_temp_time\"");

WriteAttribute("value", Tuple.Create(" value=\"", 7609), Tuple.Create("\"", 7639)
            
            #line 141 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 7617), Tuple.Create<System.Object, System.Int32>(Model.min_temp_time
            
            #line default
            #line hidden
, 7617), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">湿度：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"rel_humi\"");

WriteLiteral(" name=\"rel_humi\"");

WriteAttribute("value", Tuple.Create(" value=\"", 7810), Tuple.Create("\"", 7835)
            
            #line 144 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 7818), Tuple.Create<System.Object, System.Int32>(Model.rel_humi
            
            #line default
            #line hidden
, 7818), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"6\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_min_relhumi\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最小湿度：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"min_relhumi\"");

WriteLiteral(" name=\"min_relhumi\"");

WriteAttribute("value", Tuple.Create(" value=\"", 8054), Tuple.Create("\"", 8082)
            
            #line 149 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 8062), Tuple.Create<System.Object, System.Int32>(Model.min_relhumi
            
            #line default
            #line hidden
, 8062), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"6\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最小湿度时间：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"min_relhumi_time\"");

WriteLiteral(" name=\"min_relhumi_time\"");

WriteAttribute("value", Tuple.Create(" value=\"", 8273), Tuple.Create("\"", 8306)
            
            #line 152 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 8281), Tuple.Create<System.Object, System.Int32>(Model.min_relhumi_time
            
            #line default
            #line hidden
, 8281), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_vap_press\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"vap_press\"");

WriteLiteral(" name=\"vap_press\"");

WriteAttribute("value", Tuple.Create(" value=\"", 8515), Tuple.Create("\"", 8541)
            
            #line 157 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 8523), Tuple.Create<System.Object, System.Int32>(Model.vap_press
            
            #line default
            #line hidden
, 8523), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">露点：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"dew_point\"");

WriteLiteral(" name=\"dew_point\"");

WriteAttribute("value", Tuple.Create(" value=\"", 8714), Tuple.Create("\"", 8740)
            
            #line 160 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 8722), Tuple.Create<System.Object, System.Int32>(Model.dew_point
            
            #line default
            #line hidden
, 8722), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_air_press\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">气压：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"air_press\"");

WriteLiteral(" name=\"air_press\"");

WriteAttribute("value", Tuple.Create(" value=\"", 8951), Tuple.Create("\"", 8977)
            
            #line 165 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 8959), Tuple.Create<System.Object, System.Int32>(Model.air_press
            
            #line default
            #line hidden
, 8959), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最大气压：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"max_press\"");

WriteLiteral(" name=\"max_press\"");

WriteAttribute("value", Tuple.Create(" value=\"", 9152), Tuple.Create("\"", 9178)
            
            #line 168 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 9160), Tuple.Create<System.Object, System.Int32>(Model.max_press
            
            #line default
            #line hidden
, 9160), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_max_press_time\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最大气压时间：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"max_press_time\"");

WriteLiteral(" name=\"max_press_time\"");

WriteAttribute("value", Tuple.Create(" value=\"", 9408), Tuple.Create("\"", 9439)
            
            #line 173 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 9416), Tuple.Create<System.Object, System.Int32>(Model.max_press_time
            
            #line default
            #line hidden
, 9416), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最小气压：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"min_press\"");

WriteLiteral(" name=\"min_press\"");

WriteAttribute("value", Tuple.Create(" value=\"", 9614), Tuple.Create("\"", 9640)
            
            #line 176 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 9622), Tuple.Create<System.Object, System.Int32>(Model.min_press
            
            #line default
            #line hidden
, 9622), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_min_press_time\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">最小气压时间：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"min_press_time\"");

WriteLiteral(" name=\"min_press_time\"");

WriteAttribute("value", Tuple.Create(" value=\"", 9870), Tuple.Create("\"", 9901)
            
            #line 181 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 9878), Tuple.Create<System.Object, System.Int32>(Model.min_press_time
            
            #line default
            #line hidden
, 9878), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">surf_temp：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"surf_temp\"");

WriteLiteral(" name=\"surf_temp\"");

WriteAttribute("value", Tuple.Create(" value=\"", 10081), Tuple.Create("\"", 10107)
            
            #line 184 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 10089), Tuple.Create<System.Object, System.Int32>(Model.surf_temp
            
            #line default
            #line hidden
, 10089), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_max_surf_temp\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">max_surf_temp：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"max_surf_temp\"");

WriteLiteral(" name=\"max_surf_temp\"");

WriteAttribute("value", Tuple.Create(" value=\"", 10341), Tuple.Create("\"", 10371)
            
            #line 189 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 10349), Tuple.Create<System.Object, System.Int32>(Model.max_surf_temp
            
            #line default
            #line hidden
, 10349), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">max_sutemp_time：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"max_sutemp_time\"");

WriteLiteral(" name=\"max_sutemp_time\"");

WriteAttribute("value", Tuple.Create(" value=\"", 10569), Tuple.Create("\"", 10601)
            
            #line 192 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 10577), Tuple.Create<System.Object, System.Int32>(Model.max_sutemp_time
            
            #line default
            #line hidden
, 10577), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n<tr");

WriteLiteral(" id=\"Container_min_surf_temp\"");

WriteLiteral(">\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">min_surf_temp：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"min_surf_temp\"");

WriteLiteral(" name=\"min_surf_temp\"");

WriteAttribute("value", Tuple.Create(" value=\"", 10835), Tuple.Create("\"", 10865)
            
            #line 197 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 10843), Tuple.Create<System.Object, System.Int32>(Model.min_surf_temp
            
            #line default
            #line hidden
, 10843), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n<td");

WriteLiteral(" class=\"labeltd\"");

WriteLiteral(">min_sutemp_time：</td><td>&nbsp;\r\n<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"min_sutemp_time\"");

WriteLiteral(" name=\"min_sutemp_time\"");

WriteAttribute("value", Tuple.Create(" value=\"", 11063), Tuple.Create("\"", 11095)
            
            #line 200 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
, Tuple.Create(Tuple.Create("", 11071), Tuple.Create<System.Object, System.Int32>(Model.min_sutemp_time
            
            #line default
            #line hidden
, 11071), false)
);

WriteLiteral(" class=\"easyui-validatebox textbox\"");

WriteLiteral("  maxlength=\"0\"");

WriteLiteral(" style=\"width:200px\"");

WriteLiteral(" />\r\n</td>\r\n</tr>\r\n\r\n</table>\r\n\r\n");

WriteLiteral("        ");

            
            #line 206 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
   Write(RenderPage("~/Areas/zdz/Views/zdzinstant/Extend/Model_FormHtml.cshtml"));

            
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

            
            #line 234 "..\..\Areas\zdz\Views\zdzinstant\_\Edit.cshtml"
Write(RenderPage("~/Areas/zdz/Views/zdzinstant/Extend/Model_FormJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
