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
    
    #line 21 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
    using System.Data;
    
    #line default
    #line hidden
    using System.IO;
    using System.Linq;
    using System.Net;
    
    #line 22 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/UCenter/Views/Role/_/Grid.cshtml")]
    public partial class _Areas_UCenter_Views_Role___Grid_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_UCenter_Views_Role___Grid_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
  
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

            
            #line 17 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
    
            
            #line default
            #line hidden
            
            #line 17 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
     foreach (ToolBar tool in ViewBag.ToolbarList)
{

            
            #line default
            #line hidden
WriteLiteral("    <a");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteAttribute("id", Tuple.Create(" id=\"", 557), Tuple.Create("\"", 579)
            
            #line 19 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
, Tuple.Create(Tuple.Create("", 562), Tuple.Create<System.Object, System.Int32>(tool.ToolBarID
            
            #line default
            #line hidden
, 562), false)
);

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteAttribute("iconcls", Tuple.Create(" iconcls=\"", 606), Tuple.Create("\"", 633)
            
            #line 19 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
             , Tuple.Create(Tuple.Create("", 616), Tuple.Create<System.Object, System.Int32>(tool.ClassName
            
            #line default
            #line hidden
, 616), false)
);

WriteLiteral(" plain=\"true\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 647), Tuple.Create("\"", 721)
, Tuple.Create(Tuple.Create("", 657), Tuple.Create("T_", 657), true)
            
            #line 19 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
                                                        , Tuple.Create(Tuple.Create("", 659), Tuple.Create<System.Object, System.Int32>(tool.ToolBarID.Replace("-","")
            
            #line default
            #line hidden
, 659), false)
, Tuple.Create(Tuple.Create("", 692), Tuple.Create("ClickHandler();return", 692), true)
, Tuple.Create(Tuple.Create(" ", 713), Tuple.Create("false;", 714), true)
, Tuple.Create(Tuple.Create(" ", 720), Tuple.Create("", 720), true)
);

WriteLiteral(">");

            
            #line 19 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
                                                                                                                                                                                                  Write(tool.ToolBarName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 20 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
}

            
            #line default
            #line hidden
DefineSection("scripts_toolbar", () => {

WriteLiteral("\r\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n");

            
            #line 26 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
    
            
            #line default
            #line hidden
            
            #line 26 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
     foreach (ToolBar tool in ViewBag.ToolbarList)
    {

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral(" function T_");

            
            #line 28 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
              Write(tool.ToolBarID.Replace("-",""));

            
            #line default
            #line hidden
WriteLiteral("ClickHandler() {\r\n");

WriteLiteral("    ");

WriteLiteral("     ");

            
            #line 29 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
      Write(Html.Raw(tool.OnClick));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

WriteLiteral("     return false;\r\n");

WriteLiteral("    ");

WriteLiteral(" }\r\n");

            
            #line 32 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</script>\r\n");

});

WriteLiteral("</div>\r\n");

            
            #line 36 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
Write(RenderPage("~/Areas/UCenter/Views/Role/Extend/Model_GridHtml.cshtml"));

            
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

WriteLiteral(" style=\"position: absolute; z-index: 1;right: 10px; top: 0px;width:400px;height:1" +
"50px;background:#fafafa;\"");

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

WriteLiteral(">\r\n                    <tr>\r\n<td");

WriteLiteral("  class=\"labeltd\"");

WriteLiteral(">角色编号：</td><td>&nbsp;<input");

WriteLiteral(" class=\"easyui-textbox\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"RoleID\"");

WriteLiteral(" name=\"RoleID\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" style=\"width:100px\"");

WriteLiteral(" /></td>\r\n<td");

WriteLiteral("  class=\"labeltd\"");

WriteLiteral(">角色名称：</td><td>&nbsp;<input");

WriteLiteral(" class=\"easyui-textbox\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"RoleName\"");

WriteLiteral(" name=\"RoleName\"");

WriteLiteral(" value=\"\"");

WriteLiteral(" style=\"width:100px\"");

WriteLiteral(" /></td>\r\n</tr>\r\n\r\n                </table>\r\n            </form>\r\n        </div>\r" +
"\n        <div");

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

WriteLiteral(">关闭</a>\r\n        </div>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" id=\"PagerButtons\"");

WriteLiteral("><label><input");

WriteLiteral(" id=\"BatchCheck\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" />多选</label></div>\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    var _baseUrl = '/UCenter/Role';
var _apiUrl = '/api/UCenter/Role';
var _pageUrl = '';
var Data = {
BaseUrl: _baseUrl,
ApiUrl: _apiUrl,
FilterID: '',
DataUrl: _apiUrl + '/Grid?'+_pageUrl,
CreateUrl: _baseUrl + '/Create?'+_pageUrl,
EditUrl: _baseUrl + '/Edit/{id}?'+_pageUrl,
ShowUrl: _baseUrl + '/Show/',
BatchDeleteUrl: _apiUrl + '/BatchDelete?'+_pageUrl,
DeleteUrl: _apiUrl + '/Delete?'+_pageUrl,
ModuleID: 'UCenter',
ModelID: 'Role',
PageSize: 20,
DialogWidth: 450,
DialogHeight: 300,
FieldShowType_Name_FieldName: '',
TreeField: '',
FieldShowType_Name_Title: '',
ItemName: ""角色"",
PrimaryKey: 'RoleID',
SortField: 'OrderID',
OrderType: 'asc',
Height: 0,
UnAutoLoadGrid: ");

            
            #line 88 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
            Write(RequestHelper.GetInt("UnAutoLoadGrid"));

            
            #line default
            #line hidden
WriteLiteral(",\r\ncolumns: [[\r\n");

            
            #line 90 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
 foreach (ToolBar tool in ViewBag.ToolbarColumnList)
{
    if(tool.OrderID < 0)
    {

            
            #line default
            #line hidden
WriteLiteral("        ");

WriteLiteral("{field: \'");

            
            #line 94 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
               Write(tool.ToolBarID);

            
            #line default
            #line hidden
WriteLiteral("\', title: \'");

            
            #line 94 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
                                           Write(tool.ToolBarName);

            
            #line default
            #line hidden
WriteLiteral("\', sortable: false,width:");

            
            #line 94 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
                                                                                       Write(tool.ToolBarName.Length*15+10);

            
            #line default
            #line hidden
WriteLiteral(",align:\'center\',formatter: function(value, row, index){\r\n");

WriteLiteral("        ");

WriteLiteral("    ");

            
            #line 95 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
         Write(Html.Raw(tool.OnClick));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("        ");

WriteLiteral("}},\r\n");

            
            #line 97 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
    }
}

            
            #line default
            #line hidden
WriteLiteral(@"
{field: 'RoleID', title: '角色编号', sortable: true,width:100,align:'left'},
{field: 'RoleName', title: '角色名称', sortable: true,width:80,align:'left'},
{field: 'OrderID', title: '排序号', sortable: false,width:40,align:'center'},
{field: 'Description', title: '角色描述', sortable: true,width:420,align:'left',formatter: function(value, row, index){if(value){return '<div title=""'+value+'"">'+value+'</div>';}}}
");

            
            #line 104 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
 foreach (ToolBar tool in ViewBag.ToolbarColumnList)
{
    if(tool.OrderID >= 0)
    {

            
            #line default
            #line hidden
WriteLiteral(",{field: \'");

            
            #line 108 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
        Write(tool.ToolBarID);

            
            #line default
            #line hidden
WriteLiteral("\', title: \'");

            
            #line 108 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
                                    Write(tool.ToolBarName);

            
            #line default
            #line hidden
WriteLiteral("\', sortable: false,width:");

            
            #line 108 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
                                                                                Write(tool.ToolBarName.Length*15+10);

            
            #line default
            #line hidden
WriteLiteral(",align:\'center\',formatter: function(value, row, index){\r\n");

WriteLiteral("    ");

            
            #line 109 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
 Write(Html.Raw(tool.OnClick));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("}}\r\n");

            
            #line 111 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
    }
}

            
            #line default
            #line hidden
WriteLiteral("]],\r\nfrozenColumns: [\r\n    [\r\n        {\r\n            field: \'ck\',\r\n            ch" +
"eckbox: true\r\n        }\r\n    ]\r\n],\r\ntoolbar: \'#toolbar\',\r\nsingleSelect: ");

            
            #line 123 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
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

WriteLiteral("    ");

            
            #line 131 "..\..\Areas\UCenter\Views\Role\_\Grid.cshtml"
Write(RenderPage("~/Areas/UCenter/Views/Role/Extend/Model_GridJs.cshtml"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591