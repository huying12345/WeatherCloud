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
    using Yamon.Module.UCenter;
    using Yamon.Module.UCenter.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/UCenter/Views/User/ChangePwd.cshtml")]
    public partial class _Areas_UCenter_Views_User_ChangePwd_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Areas_UCenter_Views_User_ChangePwd_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" region=\"center\"");

WriteLiteral(" border=\"true\"");

WriteLiteral(" style=\"padding: 10px;background: #F6F6F6;border: 1px solid #ccc;\"");

WriteLiteral(">\r\n    <form");

WriteLiteral(" id=\"myForm\"");

WriteLiteral(" name=\"myForm\"");

WriteLiteral(" action=\"/api/UCenter/User/ChangePwd\"");

WriteLiteral(" method=\"post\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" cellpadding=\"3\"");

WriteLiteral(" class=\"mytable\"");

WriteLiteral(" style=\"width: 100%\"");

WriteLiteral(">\r\n            <tr>\r\n                <td>\r\n                    原密码：\r\n            " +
"    </td>\r\n                <td>\r\n                    <input");

WriteLiteral(" id=\"OldPassword\"");

WriteLiteral(" name=\"OldPassword\"");

WriteLiteral(" type=\"password\"");

WriteLiteral(" class=\"easyui-validatebox\"");

WriteLiteral(" required=\"true\"");

WriteLiteral(" missingmessage=\"原密码不能为空！\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                " +
"<td>\r\n                    新密码：\r\n                </td>\r\n                <td>\r\n   " +
"                 <input");

WriteLiteral(" id=\"NewPassword\"");

WriteLiteral(" name=\"NewPassword\"");

WriteLiteral(" type=\"password\"");

WriteLiteral(" class=\"easyui-validatebox\"");

WriteLiteral(" required=\"true\"");

WriteLiteral(" missingmessage=\"新密码不能为空！\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n            <tr>\r\n                " +
"<td>\r\n                    确认密码：\r\n                </td>\r\n                <td>\r\n  " +
"                  <input");

WriteLiteral(" id=\"NewPassword1\"");

WriteLiteral(" name=\"NewPassword1\"");

WriteLiteral(" type=\"password\"");

WriteLiteral(" class=\"easyui-validatebox\"");

WriteLiteral(" required=\"true\"");

WriteLiteral(" missingmessage=\"确认密码不能为空！\"");

WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n        </table>\r\n    </form>\r\n</d" +
"iv>\r\n<div");

WriteLiteral(" region=\"south\"");

WriteLiteral(" border=\"false\"");

WriteLiteral(" style=\"text-align: right;background: #F6F6F6; height: 30px; line-height: 30px;\"");

WriteLiteral(">\r\n    <a");

WriteLiteral(" id=\"btnSubmit\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" icon=\"icon-ok\"");

WriteLiteral(" href=\"javascript:void(0)\"");

WriteLiteral(">确定</a>\r\n    <a");

WriteLiteral(" id=\"btnCancel\"");

WriteLiteral(" class=\"easyui-linkbutton\"");

WriteLiteral(" icon=\"icon-cancel\"");

WriteLiteral(" href=\"javascript: MyForm.CancelDialog();\"");

WriteLiteral(">\r\n        取消\r\n    </a>\r\n</div>\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1606), Tuple.Create("\"", 1644)
, Tuple.Create(Tuple.Create("", 1612), Tuple.Create<System.Object, System.Int32>(Href("~/Resources/JsLib/jquery.form.js")
, 1612), false)
);

WriteLiteral("></script>\r\n    <script");

WriteAttribute("src", Tuple.Create(" src=\"", 1668), Tuple.Create("\"", 1696)
, Tuple.Create(Tuple.Create("", 1674), Tuple.Create<System.Object, System.Int32>(Href("~/Static/v1/js/form.js")
, 1674), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
        jQuery(function () {
            MyForm.validate = function (formData, jqForm, options) {
                if (jQuery(""#NewPassword"").val() != jQuery(""#NewPassword1"").val()) {
                    jQuery.messager.alert('提示', '两次输入的密码不一致!', 'info');
                    return false;
                }
                if (jQuery(""#myForm"").form('validate')) {
                    var win = jQuery.messager.progress({
                        title: '请稍候',
                        msg: '数据提交中...'
                    });
                    return true;
                }
                return false;
            }

            MyForm.onSubmitSuccess = function(msg) {
                jQuery.messager.progress('close');
                if (msg.success) {
                    jQuery.messager.alert('提示', '保存成功！', 'info');
                    CloseDialog();
                } else {
                    jQuery.messager.alert('提示', '保存失败：' + msg.message, 'info');
                    return false;
                }
            }
        });
    </script>
");

});

        }
    }
}
#pragma warning restore 1591
