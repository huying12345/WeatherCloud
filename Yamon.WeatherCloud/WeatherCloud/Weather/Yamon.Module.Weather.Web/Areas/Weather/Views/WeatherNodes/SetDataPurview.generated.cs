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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Weather/Views/WeatherNodes/SetDataPurview.cshtml")]
    public partial class _Areas_Weather_Views_WeatherNodes_SetDataPurview_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_Weather_Views_WeatherNodes_SetDataPurview_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Areas\Weather\Views\WeatherNodes\SetDataPurview.cshtml"
  
    ViewBag.Title="设置数据权限";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        var UserID = ");

            
            #line 7 "..\..\Areas\Weather\Views\WeatherNodes\SetDataPurview.cshtml"
                 Write(RequestHelper.GetInt("UserID",0));

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var DepartmentID = ");

            
            #line 8 "..\..\Areas\Weather\Views\WeatherNodes\SetDataPurview.cshtml"
                       Write(RequestHelper.GetInt("DepartmentID", 0));

            
            #line default
            #line hidden
WriteLiteral(";\r\n        var loadNodes=\"\";\r\n        var ischecked = false;\r\n\r\n        jQuery(fu" +
"nction () {\r\n\r\n            jQuery(\"#NodesTree\").tree(\r\n            {\r\n          " +
"      animate: true,\r\n                lines: true,\r\n                checkbox: tr" +
"ue,\r\n                cascadeCheck: false,\r\n                url: \"/api/Weather/We" +
"atherNodes/EditTree\",\r\n                animate: true,\r\n                onLoadSuc" +
"cess: function (node, data) {\r\n                    jQuery(\"#NodesTree\").tree(\'co" +
"llapseAll\');\r\n                    LoadWeatherNodes();\r\n                    //jQu" +
"ery(\"#NodesTree\").tree(\'expand\', jQuery(\"#NodesTree\").tree(\"getRoot\").target);\r\n" +
"                },\r\n                onDblClick: function (node) {\r\n             " +
"       checkAllChild(node, ischecked ? \'uncheck\' : \'check\');\r\n                }," +
"\r\n                onCheck: function (node, checked) {\r\n                    if (c" +
"hecked) {\r\n                        var parent = $(\"#NodesTree\").tree(\'getParent\'" +
", node.target);\r\n                        if (parent) {\r\n                        " +
"    $(\"#NodesTree\").tree(\'check\', parent.target);\r\n                        }\r\n  " +
"                  }else{\r\n                        var child = $(\"#NodesTree\").tr" +
"ee(\'getChildren\', node.target);\r\n                        if (child) {\r\n         " +
"                   for (var i = 0; i < child.length; i++) {\r\n                   " +
"             $(\"#NodesTree\").tree(\'uncheck\', child[i].target);\r\n                " +
"            }\r\n                        }\r\n                    }\r\n               " +
" }\r\n            });\r\n\r\n            jQuery(\'#btnOK\').click(function () {\r\n\r\n     " +
"           jQuery.messager.confirm(\'保存数据权限\', \'您确定要保存数据权限吗?\', function(r) {\r\n    " +
"                if (r) {\r\n\r\n                        jQuery(\"#btnOK\").linkbutton(" +
"\"disable\");\r\n                        jQuery.ajax({\r\n                            " +
"type: \'post\',\r\n                            dataType: \'json\',\r\n                  " +
"          url: \'/api/Weather/WeatherNodes/SetDataPurview?\',\r\n                   " +
"         data: { \"UserID\": UserID,\"DepartmentID\":DepartmentID, \"NodeID\": getNode" +
"sTreeChecked() },\r\n                            success: function (msg) {\r\n      " +
"                          jQuery(\"#btnOK\").linkbutton(\'enable\');\r\n              " +
"                  if (msg.success) {\r\n                                    alert(" +
"\"操作成功！\");\r\n                                    parent.CloseDialog();\r\n          " +
"                      } else {\r\n                                    alert(\"操作失败：" +
"\" + msg);\r\n                                    return;\r\n                        " +
"        }\r\n                            },\r\n                            error: fu" +
"nction (error) { jQuery(\"#btnOK\").linkbutton(\'enable\'); }\r\n                     " +
"   });\r\n\r\n                    }\r\n                });\r\n\r\n\r\n            });\r\n     " +
"   });\r\n\r\n        function getNodesTreeChecked() {\r\n            var nodes = $(\'#" +
"NodesTree\').tree(\'getChecked\');\r\n            var s = \'\';\r\n            for (var i" +
" = 0; i < nodes.length; i++) {\r\n                if (s != \'\') s += \',\';\r\n        " +
"        s += nodes[i].id;\r\n            }\r\n            return s;\r\n        }\r\n\r\n\r\n" +
"        function expandAll(idTree) {\r\n            jQuery(\'#\' + idTree).tree(\'exp" +
"andAll\');\r\n            return;\r\n        }\r\n\r\n        function collapseAll(idTree" +
") {\r\n            jQuery(\'#\' + idTree).tree(\'collapseAll\');\r\n        }\r\n\r\n       " +
" function selectAll() {\r\n            var check = jQuery(\'#chkCheckAll\').is(\':che" +
"cked\') ? \'check\' : \'uncheck\';\r\n            var roots = jQuery(\"#NodesTree\").tree" +
"(\'getRoots\');\r\n            for (var i = 0; i < roots.length; i++) {\r\n           " +
"     jQuery(\"#NodesTree\").tree(check, roots[i].target);\r\n                var chi" +
"ld = jQuery(\"#NodesTree\").tree(\'getChildren\', roots[i].target);\r\n               " +
" for (var j = 0; j < child.length; j++) {\r\n                    jQuery(\"#NodesTre" +
"e\").tree(check, child[j].target);\r\n                }\r\n            }\r\n           " +
" // jQuery(\"#NodesTree\").tree(\"check\", jQuery(\"#NodesTree\").tree(\'getRoot\'));\r\n " +
"       }\r\n\r\n        function checkAllChild(node, checkType) {\r\n            ische" +
"cked = checkType == \'check\';\r\n            $(\'#NodesTree\').tree(checkType, node.t" +
"arget);\r\n            var childs = $(\'#NodesTree\').tree(\'getChildren\', node.targe" +
"t);\r\n            for (var i = 0; i < childs.length; i++) {\r\n                chec" +
"kAllChild(childs[i], checkType);\r\n            }\r\n        }\r\n\r\n        function L" +
"oadWeatherNodes(){\r\n            if(loadNodes==\"\"){\r\n                jQuery.ajax(" +
"{\r\n                    type: \'post\',\r\n                    dataType: \'json\',\r\n   " +
"                 url: \'/api/Weather/WeatherNodes/GetDataPurview?\',\r\n            " +
"        data: { \"UserID\": UserID,\"DepartmentID\":DepartmentID },\r\n               " +
"     success: function (msg) {\r\n                        if(msg.success){\r\n      " +
"                      loadNodes=msg.data;\r\n                            setLoadWe" +
"ather();\r\n                        }\r\n                    },\r\n                   " +
" error: function (error) { }\r\n                });\r\n            }else{\r\n         " +
"       setLoadWeather();\r\n            }\r\n        }\r\n\r\n        function setLoadWe" +
"ather(){\r\n            var nodeLoadList=loadNodes.split(\",\");\r\n            for (v" +
"ar i = 0; i < nodeLoadList.length; i++) {\r\n                var node = $(\'#NodesT" +
"ree\').tree(\'find\', nodeLoadList[i]);\r\n                $(\'#NodesTree\').tree(\'chec" +
"k\', node.target);\r\n            }\r\n        }\r\n    </script>\r\n");

});

WriteLiteral("\r\n<div");

WriteLiteral(" class=\"easyui-layout\"");

WriteLiteral(" data-options=\"fit:true\"");

WriteLiteral(" style=\"height:600px;\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"p\"");

WriteLiteral(" data-options=\"region:\'west\'\"");

WriteLiteral(" title=\"任务列表\"");

WriteLiteral(" style=\"width:100%;padding:10px\"");

WriteLiteral(">\r\n        <div>\r\n            <a");

WriteLiteral(" href=\"javascript:expandAll(\'NodesTree\');\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(">\r\n                全部展开\r\n            </a>\r\n            <a");

WriteLiteral(" href=\"javascript:collapseAll(\'NodesTree\');\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(">\r\n                全部收缩\r\n            </a>\r\n            <input");

WriteLiteral(" id=\"chkCheckAll\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" value=\"1\"");

WriteLiteral(" onchange=\"selectAll()\"");

WriteLiteral(" /><label");

WriteLiteral(" for=\"chkCheckAll\"");

WriteLiteral(">全选/反选</label>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"sjjk_con\"");

WriteLiteral(" id=\"NodesTree\"");

WriteLiteral(">\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" region=\"south\"");

WriteLiteral(" border=\"false\"");

WriteLiteral(" style=\"text-align: right; background: #F6F6F6; height: 30px; line-height: 30px;\"" +
"");

WriteLiteral(">\r\n        <div>\r\n            <label>双击全选或取消选择子节点</label>\r\n            <a");

WriteLiteral(" id=\"btnOK\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" icon=\"icon-ok\"");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(">\r\n                确定\r\n            </a>\r\n            <a");

WriteLiteral(" id=\"btnCancel\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" icon=\"icon-cancel\"");

WriteLiteral(" href=\"javascript:parent.CloseDialog();\"");

WriteLiteral(">\r\n                取消\r\n            </a>\r\n        </div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
