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
    
    #line 24 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
    using System.Data;
    
    #line default
    #line hidden
    using System.IO;
    using System.Linq;
    using System.Net;
    
    #line 25 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/zdz/Views/zdzStation/_/Grid1.cshtml")]
    public partial class _Areas_zdz_Views_zdzStation___Grid1_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_zdz_Views_zdzStation___Grid1_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n");

            
            #line 3 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
  
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

WriteLiteral("></div>\r\n");

            
            #line 17 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
Write(RenderPage("~/Areas/zdz/Views/zdzStation/Extend/Model_GridHtml.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" id=\"toolbar\"");

WriteLiteral(" style=\"padding: 5px; height: auto\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"searchForm\"");

WriteLiteral(" name=\"searchForm\"");

WriteLiteral(" action=\"\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n");

            
            #line 20 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
        
            
            #line default
            #line hidden
            
            #line 20 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
         foreach (ToolBar tool in ViewBag.ToolbarList)
{

            
            #line default
            #line hidden
WriteLiteral("    <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteAttribute("id", Tuple.Create(" id=\"", 707), Tuple.Create("\"", 729)
            
            #line 22 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
, Tuple.Create(Tuple.Create("", 712), Tuple.Create<System.Object, System.Int32>(tool.ToolBarID
            
            #line default
            #line hidden
, 712), false)
);

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteAttribute("iconcls", Tuple.Create(" iconcls=\"", 756), Tuple.Create("\"", 783)
            
            #line 22 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
             , Tuple.Create(Tuple.Create("", 766), Tuple.Create<System.Object, System.Int32>(tool.ClassName
            
            #line default
            #line hidden
, 766), false)
);

WriteLiteral(" plain=\"true\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 797), Tuple.Create("\"", 871)
, Tuple.Create(Tuple.Create("", 807), Tuple.Create("T_", 807), true)
            
            #line 22 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
                                                        , Tuple.Create(Tuple.Create("", 809), Tuple.Create<System.Object, System.Int32>(tool.ToolBarID.Replace("-","")
            
            #line default
            #line hidden
, 809), false)
, Tuple.Create(Tuple.Create("", 842), Tuple.Create("ClickHandler();return", 842), true)
, Tuple.Create(Tuple.Create(" ", 863), Tuple.Create("false;", 864), true)
, Tuple.Create(Tuple.Create(" ", 870), Tuple.Create("", 870), true)
);

WriteLiteral(">");

            
            #line 22 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
                                                                                                                                                                                                  Write(tool.ToolBarName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 23 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
}

            
            #line default
            #line hidden
DefineSection("scripts_toolbar", () => {

WriteLiteral("\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n");

            
            #line 29 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
    
            
            #line default
            #line hidden
            
            #line 29 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
     foreach (ToolBar tool in ViewBag.ToolbarList)
    {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral(" function T_");

            
            #line 31 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
              Write(tool.ToolBarID.Replace("-",""));

            
            #line default
            #line hidden
WriteLiteral("ClickHandler() {\r\n");

WriteLiteral("    ");

WriteLiteral("     ");

            
            #line 32 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
      Write(Html.Raw(tool.OnClick));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

WriteLiteral("     return false;\r\n");

WriteLiteral("    ");

WriteLiteral(" }\r\n");

            
            #line 35 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</script>\r\n");

});

WriteLiteral("\r\n        \r\n    </form>\r\n</div>\r\n<div");

WriteLiteral(" id=\"PagerButtons\"");

WriteLiteral("><label><input");

WriteLiteral(" id=\"BatchCheck\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" />多选</label></div>\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
        var _baseUrl = '/zdz/zdzStation';
var _apiUrl = '/api/zdz/zdzStation';
var _pageUrl = '';
var Data = {
BaseUrl: _baseUrl,
ApiUrl: _apiUrl,
FilterID: '',
DataUrl: _apiUrl + '/Grid1?'+_pageUrl,
CreateUrl: _baseUrl + '/Create?'+_pageUrl,
EditUrl: _baseUrl + '/Edit/{id}?'+_pageUrl,
ShowUrl: _baseUrl + '/Show/',
BatchDeleteUrl: _apiUrl + '/BatchDelete?'+_pageUrl,
DeleteUrl: _apiUrl + '/Delete?'+_pageUrl,
ModuleID: 'zdz',
ModelID: 'zdzStation',
PageSize: 20,
DialogWidth: 700,
DialogHeight: 600,
FieldShowType_Name_FieldName: 'StationName',
TreeField: 'StationName',
FieldShowType_Name_Title: '站点名称',
ItemName: ""自动站站点"",
PrimaryKey: 'StationID',
SortField: 'StationID',
OrderType: 'asc',
Height: 0,
UnAutoLoadGrid: ");

            
            #line 72 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
            Write(RequestHelper.GetInt("UnAutoLoadGrid"));

            
            #line default
            #line hidden
WriteLiteral(",\r\ncolumns: [[\r\n");

            
            #line 74 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
 foreach (ToolBar tool in ViewBag.ToolbarColumnList)
{
    if(tool.OrderID < 0)
    {

            
            #line default
            #line hidden
WriteLiteral("        ");

WriteLiteral("{field: \'");

            
            #line 78 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
               Write(tool.ToolBarID);

            
            #line default
            #line hidden
WriteLiteral("\', title: \'");

            
            #line 78 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
                                           Write(tool.ToolBarName);

            
            #line default
            #line hidden
WriteLiteral("\', sortable: false,width:");

            
            #line 78 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
                                                                                       Write(tool.ToolBarName.Length*15+10);

            
            #line default
            #line hidden
WriteLiteral(",align:\'center\',formatter: function(value, row, index){\r\n");

WriteLiteral("        ");

WriteLiteral("    ");

            
            #line 79 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
         Write(Html.Raw(tool.OnClick));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

WriteLiteral("}},\r\n");

            
            #line 81 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
    }
}

            
            #line default
            #line hidden
WriteLiteral(@"
{field: 'StationID', title: '站点编号', sortable: true,width:100,align:'left'},
{field: 'StationName', title: '站点名称', sortable: true,width:200,align:'left'},
{field: 'ParentID_ShowValue', title: '上级站点', sortable: true,width:100,hidden:true,align:'left'},
{field: 'StationLevel', title: '站点级别', sortable: true,width:100,align:'left'},
{field: 'StationType', title: '站点类型', sortable: true,width:100,align:'left'},
{field: 'Status', title: '状态', sortable: true,width:100,align:'left'},
{field: 'AltitudeHeight', title: '海拔', sortable: true,width:100,align:'left'},
{field: 'OrderID', title: '排序号', sortable: true,width:100,align:'left'},
{field: 'Lon', title: '经度', sortable: true,width:100,align:'left'},
{field: 'Lat', title: '纬度', sortable: true,width:100,align:'left'}
");

            
            #line 94 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
 foreach (ToolBar tool in ViewBag.ToolbarColumnList)
{
    if(tool.OrderID >= 0)
    {

            
            #line default
            #line hidden
WriteLiteral(",{field: \'");

            
            #line 98 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
        Write(tool.ToolBarID);

            
            #line default
            #line hidden
WriteLiteral("\', title: \'");

            
            #line 98 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
                                    Write(tool.ToolBarName);

            
            #line default
            #line hidden
WriteLiteral("\', sortable: false,width:");

            
            #line 98 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
                                                                                Write(tool.ToolBarName.Length*15+10);

            
            #line default
            #line hidden
WriteLiteral(",align:\'center\',formatter: function(value, row, index){\r\n");

WriteLiteral("    ");

            
            #line 99 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
 Write(Html.Raw(tool.OnClick));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("}}\r\n");

            
            #line 101 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
    }
}

            
            #line default
            #line hidden
WriteLiteral("]],\r\nfrozenColumns: [\r\n    [\r\n        {\r\n            field: \'ck\',\r\n            ch" +
"eckbox: true\r\n        }\r\n    ]\r\n],\r\ntoolbar: \'#toolbar\',\r\nsingleSelect: ");

            
            #line 113 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
          Write(RequestHelper.GetBool("SingleSelect",true).ToString().ToLower());

            
            #line default
            #line hidden
WriteLiteral("\r\n}\r\n    </script>\r\n    <script");

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

            
            #line 121 "..\..\Areas\zdz\Views\zdzStation\_\Grid1.cshtml"
Write(RenderPage("~/Areas/zdz/Views/zdzStation/Extend/Model_GridJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591