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
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Yamon.Framework.Common;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/WeiXinMenu.cshtml")]
    public partial class _Views_Home_WeiXinMenu_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Home_WeiXinMenu_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<style");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    .box-body input {\r\n        margin-top: 5px;\r\n    }\r\n</style>\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <!-- left column -->\r\n    <div");

WriteLiteral(" class=\"col-md-8\"");

WriteLiteral(">\r\n        <!-- general form elements -->\r\n        <div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">Quick Example</h3>\r\n            </div>\r\n            <!-- /.box-header -->\r\n\r\n   " +
"         <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <!--ko foreach: button-->\r\n                    <ul");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n                        <li");

WriteLiteral(" data-bind=\"foreach:sub_button\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-bind=\"value:name,click: $root.setSelected\"");

WriteLiteral(" />\r\n                        </li>\r\n                        <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-bind=\"value:name,click: $root.setSelected\"");

WriteLiteral(" />\r\n                        </li>\r\n                    </ul>\r\n                  " +
"  <!--/ko-->\r\n                   \r\n                </div>\r\n\r\n            </div>\r" +
"\n            <!-- /.box-body -->\r\n\r\n            <div");

WriteLiteral(" class=\"box-footer text-center\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" class=\"btn btn-primary\"");

WriteLiteral(" data-bind=\"click:save()\"");

WriteLiteral(">提交</button>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n    <!-- /.box --" +
">\r\n    <div");

WriteLiteral(" class=\"col-md-4\"");

WriteLiteral(">\r\n        <!-- general form elements -->\r\n        <div");

WriteLiteral(" class=\"box box-primary\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"box-header with-border\"");

WriteLiteral(">\r\n                <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">菜单设置</h3>\r\n            </div>\r\n\r\n            <!--ko foreach: button-->\r\n\r\n      " +
"      <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(" data-bind=\"visible: isSelected\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label>\r\n                        菜单名称\r\n                   " +
"     <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"菜单名称\"");

WriteLiteral(" data-bind=\"value: name\"");

WriteLiteral(" />\r\n                    </label>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label>菜单事件</label>\r\n                    <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                        <option");

WriteLiteral(" value=\"click\"");

WriteLiteral(" selected=\"selected\"");

WriteLiteral(">点击事件（传回服务器）</option>\r\n                        <option");

WriteLiteral(" value=\"view\"");

WriteLiteral(">访问网页（直接跳转）</option>\r\n                        <option");

WriteLiteral(" value=\"location_select\"");

WriteLiteral(">弹出地理位置选择器</option>\r\n                        <option");

WriteLiteral(" value=\"pic_photo_or_album\"");

WriteLiteral(">弹出拍照或者相册发图</option>\r\n                        <option");

WriteLiteral(" value=\"pic_sysphoto\"");

WriteLiteral(">弹出系统拍照发图</option>\r\n                        <option");

WriteLiteral(" value=\"pic_weixin\"");

WriteLiteral(">弹出微信相册发图器</option>\r\n                        <option");

WriteLiteral(" value=\"scancode_push\"");

WriteLiteral(">扫码推事件</option>\r\n                        <option");

WriteLiteral(" value=\"scancode_waitmsg\"");

WriteLiteral(">扫码推事件且弹出“消息接收中”提示框</option>\r\n                    </select>\r\n                </di" +
"v>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label>\r\n                        链接地址\r\n                   " +
"     <input");

WriteLiteral(" type=\"url\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"链接地址\"");

WriteLiteral(">\r\n                    </label>\r\n                </div>\r\n            </div>\r\n\r\n  " +
"          <!--ko foreach: sub_button-->\r\n            <div");

WriteLiteral(" class=\"box-body\"");

WriteLiteral(" data-bind=\"visible: isSelected\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label>\r\n                        菜单名称\r\n                   " +
"     <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"菜单名称\"");

WriteLiteral(" data-bind=\"value: name\"");

WriteLiteral(" />\r\n                    </label>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label>菜单事件</label>\r\n                    <select");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n                        <option");

WriteLiteral(" value=\"click\"");

WriteLiteral(" selected=\"selected\"");

WriteLiteral(">点击事件（传回服务器）</option>\r\n                        <option");

WriteLiteral(" value=\"view\"");

WriteLiteral(">访问网页（直接跳转）</option>\r\n                        <option");

WriteLiteral(" value=\"location_select\"");

WriteLiteral(">弹出地理位置选择器</option>\r\n                        <option");

WriteLiteral(" value=\"pic_photo_or_album\"");

WriteLiteral(">弹出拍照或者相册发图</option>\r\n                        <option");

WriteLiteral(" value=\"pic_sysphoto\"");

WriteLiteral(">弹出系统拍照发图</option>\r\n                        <option");

WriteLiteral(" value=\"pic_weixin\"");

WriteLiteral(">弹出微信相册发图器</option>\r\n                        <option");

WriteLiteral(" value=\"scancode_push\"");

WriteLiteral(">扫码推事件</option>\r\n                        <option");

WriteLiteral(" value=\"scancode_waitmsg\"");

WriteLiteral(">扫码推事件且弹出“消息接收中”提示框</option>\r\n                    </select>\r\n                </di" +
"v>\r\n                <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                    <label>\r\n                        链接地址\r\n                   " +
"     <input");

WriteLiteral(" type=\"url\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" placeholder=\"链接地址\"");

WriteLiteral(">\r\n                    </label>\r\n                </div>\r\n            </div>\r\n    " +
"        <!--/ko-->\r\n            <!--/ko-->\r\n           \r\n\r\n            <div");

WriteLiteral(" class=\"box-footer\"");

WriteLiteral(">\r\n               \r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- /.bo" +
"x -->\r\n</div>\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4666), Tuple.Create("\"", 4710)
, Tuple.Create(Tuple.Create("", 4672), Tuple.Create<System.Object, System.Int32>(Href("~/Resources/JsLib/knockout/knockout.js")
, 4672), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 4734), Tuple.Create("\"", 4770)
, Tuple.Create(Tuple.Create("", 4740), Tuple.Create<System.Object, System.Int32>(Href("~/Static/Home/js/WeiXinMenu.js")
, 4740), false)
);

WriteLiteral("></script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
