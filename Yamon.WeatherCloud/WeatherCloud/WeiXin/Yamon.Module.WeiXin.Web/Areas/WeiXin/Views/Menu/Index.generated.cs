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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/WeiXin/Views/Menu/Index.cshtml")]
    public partial class _Areas_WeiXin_Views_Menu_Index_cshtml : System.Web.Mvc.WebViewPage<Senparc.Weixin.MP.Entities.GetMenuResult>
    {
        public _Areas_WeiXin_Views_Menu_Index_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
  
    ViewBag.Title = "自定义菜单工具";
    Layout = "~/Areas/WeiXin/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("styles", () => {

WriteLiteral(@"
    <style>
        .txtButton {
            width: 120px;
        }

        select.dllButtonDetails {
            padding: 5px;
        }

            select.dllButtonDetails option {
                padding: 5px;
            }

        .txtButtonDetails {
            width: 200px;
        }

        .txtToken {
            width: 80%;
        }

        .submitArea {
            clear: both;
        }

        .leftArea {
            width: 450px;
        }

        #addConditionalArea {
            padding: 0px 0px 30px 20px;
        }

            #addConditionalArea input {
                width: 500px;
            }

            #addConditionalArea h3 {
                font-size: 60%;
            }

        #reveiveJSON {
            margin: 30px 40px;
        }

            #reveiveJSON textarea {
                width: 90%;
                height: 150px;
            }
    </style>
");

});

WriteLiteral("<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"menuLogin\"");

WriteLiteral(" class=\"md-5\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n            <ul>\r\n                <li>\r\n                    <div");

WriteLiteral(" class=\"control-head\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" class=\"control-title\"");

WriteLiteral(">获取AccessToken</label>\r\n                    </div>\r\n                </li>\r\n      " +
"          <li>\r\n                    <label");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">AppId:</label>\r\n                    <input");

WriteLiteral(" class=\"control-input\"");

WriteLiteral(" id=\"menuLogin_AppId\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" />\r\n                </li>\r\n                <li>\r\n                    <label");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">AppSecret:</label>\r\n                    <input");

WriteLiteral(" class=\"control-input\"");

WriteLiteral(" id=\"menuLogin_AppSecret\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" />\r\n                </li>\r\n                <li>\r\n                    <button");

WriteLiteral(" class=\"control-btn\"");

WriteLiteral(" id=\"menuLogin_Submit\"");

WriteLiteral(">获取AccessToken</button>\r\n                </li>\r\n                <li>\r\n           " +
"         <p");

WriteLiteral(" class=\"control-p\"");

WriteLiteral(">注：</p>\r\n                    <p");

WriteLiteral(" class=\"control-p\"");

WriteLiteral(">1.使用菜单需要成为“服务号”，或通过认证的“订阅号”。到微信后台【高级功能>开发模式】下获取信息</p>\r\n                    <p");

WriteLiteral(" class=\"control-p\"");

WriteLiteral(">2.这里的Token已经使用AccessTokenContainer管理起来，有效期内不会重复获取，过了有效期自动获取。也就是说如果已经在本网页上获取一次，接下" +
"去只需要提供AppId即可（直到服务器重启或列队过长被清理）</p>\r\n                </li>\r\n            </ul>\r\n  " +
"          <p");

WriteLiteral(" style=\"padding: 15px 20px; font-size: 16px;\"");

WriteLiteral(">或：</p>\r\n            <ul>\r\n                <li>\r\n                    <div");

WriteLiteral(" class=\"control-head\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" class=\"control-title\"");

WriteLiteral(">我有当前可用Token</label>\r\n                    </div>\r\n                </li>\r\n        " +
"        <li>\r\n                    <label");

WriteLiteral(" class=\"control-label\"");

WriteLiteral(">Token:</label>\r\n                    <input");

WriteLiteral(" class=\"control-input\"");

WriteLiteral(" id=\"menuLogin_OldToken\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" />\r\n                </li>\r\n                <li>\r\n                    <button");

WriteLiteral(" class=\"control-btn\"");

WriteLiteral(" id=\"menuLogin_SubmitOldToken\"");

WriteLiteral(">直接使用</button>\r\n                </li>\r\n                <li>\r\n                    " +
"<p");

WriteLiteral(" class=\"control-p\"");

WriteLiteral(">注：这个Token是通过AppId和AppSecret得到的自动生成的Token。</p>\r\n                </li>\r\n          " +
"  </ul>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"up-experience\"");

WriteLiteral(">\r\n                <p>请先登录</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n " +
"   <div");

WriteLiteral(" id=\"menuEditor\"");

WriteLiteral(" class=\"md-7\"");

WriteLiteral(@">
        <h3>使用说明及规则，请仔细阅读</h3>
        <ul>
            <li>官方要求：一级菜单按钮个数为2-3个</li>
            <li>官方要求：如果设置了二级菜单，子按钮个数为2-5个</li>
            <li>官方要求：按钮描述，既按钮名字，不超过16个字节，子菜单不超过40个字节</li>
            <li>如果name不填，此按钮将被忽略</li>
            <li>如果一级菜单为空，该列所有设置的二级菜单都会被忽略</li>
            <li>key仅在SingleButton（单击按钮，无下级菜单）的状态下设置，如果此按钮有下级菜单，key将被忽略</li>
            <li>所有二级菜单都为SingleButton</li>
            <li>如果要快速看到微信上的菜单最新状态，需要重新关注，否则需要静静等待N小时</li>
        </ul>
        <p></p>
        <h3>编辑工具</h3>
");

            
            #line 124 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
        
            
            #line default
            #line hidden
            
            #line 124 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
         using (Html.BeginForm("CreateMenu", "Menu", FormMethod.Post, new { id = "form_Menu" }))
        {

            
            #line default
            #line hidden
WriteLiteral("            <p>\r\n                当前Token:\r\n                <input");

WriteLiteral(" id=\"tokenStr\"");

WriteLiteral(" name=\"token\"");

WriteLiteral(" class=\"control-input\"");

WriteLiteral(" style=\"width: 900px;\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" readonly=\"readonly\"");

WriteLiteral(" /><br />\r\n            </p>\r\n");

WriteLiteral("            <p>\r\n                <input");

WriteLiteral(" id=\"btnGetMenu\"");

WriteLiteral(" class=\"control-btn\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" value=\"获取当前菜单\"");

WriteLiteral(" />\r\n                <input");

WriteLiteral(" id=\"btnDeleteMenu\"");

WriteLiteral(" class=\"control-btn\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" value=\"删除菜单\"");

WriteLiteral(" />\r\n            </p>\r\n");

WriteLiteral("            <p");

WriteLiteral(" class=\"menu-state\"");

WriteLiteral(">\r\n                操作状态：<strong");

WriteLiteral(" id=\"menuState\"");

WriteLiteral(">-</strong>\r\n            </p>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"float-left menu-list\"");

WriteLiteral(@">
                <table>
                    <thead>
                        <tr>
                            <th></th>
                            <th>第一列</th>
                            <th>第二列</th>
                            <th>第三列</th>
                        </tr>
                    </thead>
                    <tbody>
");

            
            #line 148 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 148 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                         for (int i = 0; i < 6; i++)
                        {
                            var isRootMenu = i == 5;

            
            #line default
            #line hidden
WriteLiteral("                            <tr");

WriteAttribute("id", Tuple.Create(" id=\"", 5022), Tuple.Create("\"", 5076)
            
            #line 151 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
, Tuple.Create(Tuple.Create("", 5027), Tuple.Create<System.Object, System.Int32>(isRootMenu ? "subMenuRow_" + i : "rootMenuRow"
            
            #line default
            #line hidden
, 5027), false)
);

WriteLiteral(">\r\n                                <td>\r\n");

WriteLiteral("                                    ");

            
            #line 153 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                                Write(isRootMenu ? "一级菜单按钮" : ("二级菜单No." + (i + 1)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </td>\r\n");

            
            #line 155 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 155 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                                 for (int j = 0; j < 3; j++)
                                {
                                    var namePrefix = isRootMenu ? string.Format("menu.button[{0}]", j) : string.Format("menu.button[{0}].sub_button[{1}]", j, i);
                                    var idPrefix = isRootMenu ? string.Format("menu_button{0}", j) : string.Format("menu_button{0}_sub_button{1}", j, i);

            
            #line default
            #line hidden
WriteLiteral("                                    <td>\r\n                                       " +
" <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" class=\"control-input\"");

WriteAttribute("name", Tuple.Create(" name=\"", 5782), Tuple.Create("\"", 5806)
            
            #line 160 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
          , Tuple.Create(Tuple.Create("", 5789), Tuple.Create<System.Object, System.Int32>(namePrefix
            
            #line default
            #line hidden
, 5789), false)
, Tuple.Create(Tuple.Create("", 5802), Tuple.Create(".key", 5802), true)
);

WriteAttribute("id", Tuple.Create(" id=\"", 5807), Tuple.Create("\"", 5827)
            
            #line 160 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                                 , Tuple.Create(Tuple.Create("", 5812), Tuple.Create<System.Object, System.Int32>(idPrefix
            
            #line default
            #line hidden
, 5812), false)
, Tuple.Create(Tuple.Create("", 5823), Tuple.Create("_key", 5823), true)
);

WriteLiteral(" />\r\n                                        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" class=\"control-input\"");

WriteAttribute("name", Tuple.Create(" name=\"", 5915), Tuple.Create("\"", 5940)
            
            #line 161 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
          , Tuple.Create(Tuple.Create("", 5922), Tuple.Create<System.Object, System.Int32>(namePrefix
            
            #line default
            #line hidden
, 5922), false)
, Tuple.Create(Tuple.Create("", 5935), Tuple.Create(".type", 5935), true)
);

WriteAttribute("id", Tuple.Create(" id=\"", 5941), Tuple.Create("\"", 5962)
            
            #line 161 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                                  , Tuple.Create(Tuple.Create("", 5946), Tuple.Create<System.Object, System.Int32>(idPrefix
            
            #line default
            #line hidden
, 5946), false)
, Tuple.Create(Tuple.Create("", 5957), Tuple.Create("_type", 5957), true)
);

WriteLiteral(" value=\"click\"");

WriteLiteral(" />\r\n                                        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" class=\"control-input\"");

WriteAttribute("name", Tuple.Create(" name=\"", 6064), Tuple.Create("\"", 6088)
            
            #line 162 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
          , Tuple.Create(Tuple.Create("", 6071), Tuple.Create<System.Object, System.Int32>(namePrefix
            
            #line default
            #line hidden
, 6071), false)
, Tuple.Create(Tuple.Create("", 6084), Tuple.Create(".url", 6084), true)
);

WriteAttribute("id", Tuple.Create(" id=\"", 6089), Tuple.Create("\"", 6109)
            
            #line 162 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                                 , Tuple.Create(Tuple.Create("", 6094), Tuple.Create<System.Object, System.Int32>(idPrefix
            
            #line default
            #line hidden
, 6094), false)
, Tuple.Create(Tuple.Create("", 6105), Tuple.Create("_url", 6105), true)
);

WriteLiteral(" />\r\n                                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"control-input\"");

WriteAttribute("name", Tuple.Create(" name=\"", 6195), Tuple.Create("\"", 6220)
            
            #line 163 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
        , Tuple.Create(Tuple.Create("", 6202), Tuple.Create<System.Object, System.Int32>(namePrefix
            
            #line default
            #line hidden
, 6202), false)
, Tuple.Create(Tuple.Create("", 6215), Tuple.Create(".name", 6215), true)
);

WriteAttribute("id", Tuple.Create(" id=\"", 6221), Tuple.Create("\"", 6242)
            
            #line 163 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                                , Tuple.Create(Tuple.Create("", 6226), Tuple.Create<System.Object, System.Int32>(idPrefix
            
            #line default
            #line hidden
, 6226), false)
, Tuple.Create(Tuple.Create("", 6237), Tuple.Create("_name", 6237), true)
);

WriteLiteral(" class=\"txtButton\"");

WriteLiteral(" data-i=\"");

            
            #line 163 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                                                                                                                                                      Write(i);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" data-j=\"");

            
            #line 163 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                                                                                                                                                                  Write(j);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" ");

            
            #line 163 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                                                                                                                                                                      Write(Html.Raw(isRootMenu ? string.Format(@"data-root=""{0}""", j) : ""));

            
            #line default
            #line hidden
WriteLiteral(" />\r\n                                    </td>\r\n");

            
            #line 165 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </tr>\r\n");

            
            #line 167 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"float-left\"");

WriteLiteral(" id=\"buttonDetails\"");

WriteLiteral(">\r\n                <h3>按钮其他参数</h3>\r\n                <p>Name：<input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" id=\"buttonDetails_name\"");

WriteLiteral(" class=\"control-input txtButton\"");

WriteLiteral(" disabled=\"disabled\"");

WriteLiteral(" /></p>\r\n                <p>\r\n                    Type：\r\n                    <sel" +
"ect");

WriteLiteral(" id=\"buttonDetails_type\"");

WriteLiteral(" class=\"dllButtonDetails\"");

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

WriteLiteral(">扫码推事件且弹出“消息接收中”提示框</option>\r\n                    </select>\r\n                </p>" +
"\r\n                <p");

WriteLiteral(" id=\"buttonDetails_key_area\"");

WriteLiteral(">\r\n                    Key：<input");

WriteLiteral(" id=\"buttonDetails_key\"");

WriteLiteral(" class=\"control-input txtButtonDetails\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" />\r\n                </p>\r\n                <p");

WriteLiteral(" id=\"buttonDetails_url_area\"");

WriteLiteral(">\r\n                    Url：<input");

WriteLiteral(" id=\"buttonDetails_url\"");

WriteLiteral(" class=\"control-input txtButtonDetails\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" />\r\n                </p>\r\n                <p>\r\n                    如果还有下级菜单请忽略Ty" +
"pe和Key、Url。<br />\r\n                </p>\r\n            </div>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"clear\"");

WriteLiteral("></div>\r\n");

WriteLiteral("            <div");

WriteLiteral(" id=\"addConditionalArea\"");

WriteLiteral(">\r\n                <p><h3>个性化菜单设置</h3></p>\r\n                <p>\r\n                " +
"    <table>\r\n                        <tr>\r\n                            <td>group" +
"_id</td>\r\n                            <td>\r\n                                <inp" +
"ut");

WriteLiteral(" type=\"text\"");

WriteLiteral(" name=\"MenuMatchRule.group_id\"");

WriteLiteral(" placeholder=\"用户分组id，可通过用户分组管理接口获取\r\n\"");

WriteLiteral(" class=\"control-input\"");

WriteLiteral(" />\r\n                            </td>\r\n                        </tr>\r\n          " +
"              <tr><td>sex</td><td><input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" name=\"MenuMatchRule.sex\"");

WriteLiteral(" placeholder=\"性别：男（1）女（2），不填则不做匹配\"");

WriteLiteral(" class=\"control-input\"");

WriteLiteral(" /></td></tr>\r\n                        <tr><td>country</td><td><input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" name=\"MenuMatchRule.country\"");

WriteLiteral(" placeholder=\"国家信息，是用户在微信中设置的地区，具体请参考地区信息表\"");

WriteLiteral(" class=\"control-input\"");

WriteLiteral(" /></td></tr>\r\n                        <tr><td>province</td><td><input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" name=\"MenuMatchRule.province\"");

WriteLiteral(" placeholder=\"省份信息，是用户在微信中设置的地区，具体请参考地区信息表\"");

WriteLiteral(" class=\"control-input\"");

WriteLiteral(" /></td></tr>\r\n                        <tr><td>city</td><td><input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" name=\"MenuMatchRule.city\"");

WriteLiteral(" placeholder=\"城市信息，是用户在微信中设置的地区，具体请参考地区信息表\"");

WriteLiteral(" class=\"control-input\"");

WriteLiteral(" /></td></tr>\r\n                        <tr><td>client_platform_type</td><td><inpu" +
"t");

WriteLiteral(" type=\"text\"");

WriteLiteral(" name=\"MenuMatchRule.client_platform_type\"");

WriteLiteral(" placeholder=\"客户端版本，当前只具体到系统型号：IOS(1), Android(2),Others(3)，不填则不做匹配\"");

WriteLiteral(" class=\"control-input\"");

WriteLiteral(" /></td></tr>\r\n                    </table>\r\n                </p>\r\n              " +
"  <p><i>提示：如果所有字段都留空，则使用普通自定义菜单，如果任何一个条件有值，则使用个性化菜单接口</i></p>\r\n            </div" +
">\r\n");

            
            #line 218 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"


            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"clear\"");

WriteLiteral("></div>\r\n");

WriteLiteral("            <div");

WriteLiteral(" id=\"submitArea\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"control-btn\"");

WriteLiteral(" value=\"更新到服务器\"");

WriteLiteral(" id=\"submitMenu\"");

WriteLiteral(" />\r\n            </div>\r\n");

            
            #line 223 "..\..\Areas\WeiXin\Views\Menu\Index.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" id=\"reveiveJSON\"");

WriteLiteral(">\r\n            <p>接收菜单JSON：</p>\r\n            <p><textarea");

WriteLiteral(" id=\"txtReveiceJSON\"");

WriteLiteral("></textarea></p>\r\n\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"clear\"");

WriteLiteral("></div>\r\n    </div>\r\n</div>\r\n<div");

WriteLiteral(" class=\"clear\"");

WriteLiteral("></div>\r\n<script");

WriteLiteral(" src=\"/Static/WeiXin/js/senparc.menu.js\"");

WriteLiteral("></script>\r\n<script>\r\n    $(function () {\r\n        senparc.menu.init();\r\n    });\r" +
"\n</script>\r\n");

        }
    }
}
#pragma warning restore 1591
