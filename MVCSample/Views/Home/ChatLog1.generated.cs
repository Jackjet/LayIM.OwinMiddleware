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
    using MVCSample;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/ChatLog.cshtml")]
    public partial class _Views_Home_ChatLog_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Home_ChatLog_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<head>\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(">\r\n    <title>聊天记录</title>\r\n    <link");

WriteLiteral(" href=\"/Scripts/layui/css/layui.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(">\r\n    <style>body .layim-chat-main {height: auto;}</style>\r\n    <link");

WriteLiteral(" href=\"/css/layim.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" />\r\n</head>\r\n    <div");

WriteLiteral(" class=\"layim-chat-main\"");

WriteLiteral(">\r\n        <ul");

WriteLiteral(" id=\"LAY_view\"");

WriteLiteral(">  \r\n            <div");

WriteLiteral(" id=\"chatLogMore\"");

WriteLiteral(" class=\"layim-chat-system\"");

WriteLiteral(" style=\"display:none;\"");

WriteLiteral("><span>查看更多记录</span></div>\r\n         </ul>\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"LAY_page\"");

WriteLiteral(" style=\"margin: 0 10px;\"");

WriteLiteral("></div>\r\n    <script");

WriteLiteral(" src=\"https://cdn.bootcss.com/jquery/3.2.1/jquery.min.js\"");

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" src=\"/Scripts/chatlog.js\"");

WriteLiteral("></script>\r\n    <script>\r\n        chatLogParam.init(\'");

            
            #line 17 "..\..\Views\Home\ChatLog.cshtml"
                      Write(Request["type"]);

            
            #line default
            #line hidden
WriteLiteral("\', \'");

            
            #line 17 "..\..\Views\Home\ChatLog.cshtml"
                                          Write(Request["id"]);

            
            #line default
            #line hidden
WriteLiteral("\');\r\n    </script>\r\n");

        }
    }
}
#pragma warning restore 1591
