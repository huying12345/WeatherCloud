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
    
    #line 23 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
    using System.Data;
    
    #line default
    #line hidden
    using System.IO;
    using System.Linq;
    using System.Net;
    
    #line 24 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
    using System.Text;
    
    #line default
    #line hidden
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/UCenter/Views/Shortcut/_/Grid.cshtml")]
    public partial class _Areas_UCenter_Views_Shortcut___Grid_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_UCenter_Views_Shortcut___Grid_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
  
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

WriteLiteral(" id=\"tt\"");

WriteLiteral("></div>\r\n<div");

WriteLiteral(" id=\"toolbar\"");

WriteLiteral(" style=\"padding: 5px; height: auto\"");

WriteLiteral(">\r\n");

            
            #line 17 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
    
            
            #line default
            #line hidden
            
            #line 17 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
      

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 19 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
 foreach (ToolBar tool in ViewBag.ToolbarList)
{

            
            #line default
            #line hidden
WriteLiteral("    <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteAttribute("id", Tuple.Create(" id=\"", 564), Tuple.Create("\"", 586)
            
            #line 21 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
, Tuple.Create(Tuple.Create("", 569), Tuple.Create<System.Object, System.Int32>(tool.ToolBarID
            
            #line default
            #line hidden
, 569), false)
);

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteAttribute("iconcls", Tuple.Create(" iconcls=\"", 613), Tuple.Create("\"", 640)
            
            #line 21 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
             , Tuple.Create(Tuple.Create("", 623), Tuple.Create<System.Object, System.Int32>(tool.ClassName
            
            #line default
            #line hidden
, 623), false)
);

WriteLiteral(" plain=\"true\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 654), Tuple.Create("\"", 710)
            
            #line 21 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
                                                      , Tuple.Create(Tuple.Create("", 664), Tuple.Create<System.Object, System.Int32>(tool.ToolBarID
            
            #line default
            #line hidden
, 664), false)
, Tuple.Create(Tuple.Create("", 681), Tuple.Create("ClickHandler();return", 681), true)
, Tuple.Create(Tuple.Create(" ", 702), Tuple.Create("false;", 703), true)
, Tuple.Create(Tuple.Create(" ", 709), Tuple.Create("", 709), true)
);

WriteLiteral(">");

            
            #line 21 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
                                                                                                                                                                                Write(tool.ToolBarName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 22 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
}

            
            #line default
            #line hidden
DefineSection("scripts_toolbar", () => {

WriteLiteral("\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n");

            
            #line 28 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
    
            
            #line default
            #line hidden
            
            #line 28 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
     foreach (ToolBar tool in ViewBag.ToolbarList)
    {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral(" function ");

            
            #line 30 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
            Write(tool.ToolBarID);

            
            #line default
            #line hidden
WriteLiteral("ClickHandler() {\r\n");

WriteLiteral("    ");

WriteLiteral("     ");

            
            #line 31 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
      Write(Html.Raw(tool.OnClick));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

WriteLiteral("     return false;\r\n");

WriteLiteral("    ");

WriteLiteral(" }\r\n");

            
            #line 34 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</script>\r\n");

});

WriteLiteral("</div>\r\n");

            
            #line 38 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
Write(RenderPage("~/Areas/UCenter/Views/Shortcut/Extend/Model_GridHtml.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" id=\"p\"");

WriteLiteral(" class=\"easyui-panel\"");

WriteLiteral(" title=\"\"");

WriteLiteral(" closed=\"true\"");

WriteLiteral(" icon=\"icon-save\"");

WriteLiteral(" collapsible=\"true\"");

WriteLiteral(" minimizable=\"true\"");

WriteLiteral(" maximizable=\"false\"");

WriteLiteral(" closable=\"true\"");

WriteLiteral(" style=\"position: absolute; z-index: 1;right: 10px; top: 0px;width:500px;height:3" +
"00px;background:#fafafa;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"easyui-layout\"");

WriteLiteral(" fit=\"true\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" region=\"center\"");

WriteLiteral(" border=\"true\"");

WriteLiteral(" style=\"padding: 5px; background: #F6F6F6; border: 1px solid #ccc;\"");

WriteLiteral(">\r\n            <form");

WriteLiteral(" id=\"searchForm\"");

WriteLiteral(" name=\"searchForm\"");

WriteLiteral(" action=\"\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n                高级查询\r\n                <table");

WriteLiteral(" id=\"searchtable\"");

WriteLiteral(" class=\"mytable\"");

WriteLiteral(" width=\"100%\"");

WriteLiteral(" cellpadding=\"0\"");

WriteLiteral(" cellspacing=\"0\"");

WriteLiteral(" align=\"center\"");

WriteLiteral(">\r\n                    \r\n                </table>\r\n            </form>\r\n        <" +
"/div>\r\n        <div");

WriteLiteral(" region=\"south\"");

WriteLiteral(" border=\"false\"");

WriteLiteral(" style=\"text-align: right; background: #F6F6F6;height: 30px; line-height: 30px;\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" id=\"btnSubmit\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" icon=\"icon-ok\"");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(">查询</a>\r\n            \r\n            <a");

WriteLiteral(" id=\"btnCancel\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" icon=\"icon-cancel\"");

WriteLiteral(" href=\"javascript:ShowSearchFrm(false);\"");

WriteLiteral(">关闭</a>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    var _baseUrl = '/UCenter/Shortcut';
var _pageUrl = '';
var Data = {
BaseUrl: _baseUrl,
DataUrl: _baseUrl + '/GridAction?'+_pageUrl,
CreateUrl: _baseUrl + '/Create?'+_pageUrl,
EditUrl: _baseUrl + '/Edit/{id}?'+_pageUrl,
ShowUrl: _baseUrl + '/Show/',
BatchDeleteUrl: _baseUrl + '/BatchDeleteAction?'+_pageUrl,
DeleteUrl: _baseUrl + '/DeleteAction?'+_pageUrl,
ModuleID: 'UCenter',
ModelID: 'Shortcut',
PageSize: 20,
DialogWidth: 500,
DialogHeight: 300,
FieldShowType_Name_FieldName: '',
TreeField: '',
FieldShowType_Name_Title: '',
ItemName: ""快捷菜单"",
PrimaryKey: 'LinkID',
SortField: 'LinkID',
OrderType: 'asc',
Height: 0,
UnAutoLoadGrid: ");

            
            #line 83 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
            Write(RequestHelper.GetInt("UnAutoLoadGrid"));

            
            #line default
            #line hidden
WriteLiteral(",\r\ncolumns: [[\r\n");

            
            #line 85 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
 foreach (ToolBar tool in ViewBag.ToolbarColumnList)
{
    if(tool.OrderID < 0)
    {

            
            #line default
            #line hidden
WriteLiteral("        ");

WriteLiteral("{field: \'");

            
            #line 89 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
               Write(tool.ToolBarID);

            
            #line default
            #line hidden
WriteLiteral("\', title: \'");

            
            #line 89 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
                                           Write(tool.ToolBarName);

            
            #line default
            #line hidden
WriteLiteral("\', sortable: false,width:");

            
            #line 89 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
                                                                                       Write(tool.ToolBarName.Length*15+10);

            
            #line default
            #line hidden
WriteLiteral(",align:\'center\',formatter: function(value, row, index){\r\n");

WriteLiteral("        ");

WriteLiteral("    ");

            
            #line 90 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
         Write(Html.Raw(tool.OnClick));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

WriteLiteral("}},\r\n");

            
            #line 92 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
    }
}

            
            #line default
            #line hidden
WriteLiteral(@"
{field: 'LinkID', title: '编号', sortable: true,width:100,align:'left'},
{field: 'LinkName', title: '链接名称', sortable: true,width:100,align:'left'},
{field: 'LinkUrl', title: '链接地址', sortable: true,width:300,align:'left'},
{field: 'LinkType_ShowValue', title: '链接类型', sortable: true,width:100,align:'left'},
{field: 'LinkMenuID', title: '链接菜单', sortable: true,width:100,align:'left'}
");

            
            #line 100 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
 foreach (ToolBar tool in ViewBag.ToolbarColumnList)
{
    if(tool.OrderID >= 0)
    {

            
            #line default
            #line hidden
WriteLiteral(",{field: \'");

            
            #line 104 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
        Write(tool.ToolBarID);

            
            #line default
            #line hidden
WriteLiteral("\', title: \'");

            
            #line 104 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
                                    Write(tool.ToolBarName);

            
            #line default
            #line hidden
WriteLiteral("\', sortable: false,width:");

            
            #line 104 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
                                                                                Write(tool.ToolBarName.Length*15+10);

            
            #line default
            #line hidden
WriteLiteral(",align:\'center\',formatter: function(value, row, index){\r\n");

WriteLiteral("    ");

            
            #line 105 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
 Write(Html.Raw(tool.OnClick));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("}}\r\n");

            
            #line 107 "..\..\Areas\UCenter\Views\Shortcut\_\Grid.cshtml"
    }
}

            
            #line default
            #line hidden
WriteLiteral("]],\r\nfrozenColumns: [\r\n    [\r\n        {\r\n            field: \'ck\',\r\n            ch" +
"eckbox: true\r\n        }\r\n    ]\r\n],\r\ntoolbar: \'#toolbar\',\r\nsingleSelect: false\r\n}" +
"\r\n    </script>\r\n    <script");

WriteLiteral(" src=\"/Resources/JsLib/jquery.query.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"/Resources/JsLib/jquery.form.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"/Static/v1/js/GridUtils.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"/Static/v1/js/SmartFormGrid.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"/Static/v1/js/Grid.js\"");

WriteLiteral("></script>\r\n");

});

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
