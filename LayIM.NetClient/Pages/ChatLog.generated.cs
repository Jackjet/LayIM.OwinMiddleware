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

namespace LayIM.NetClient
{
    using System;
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    public partial class ChatLog : RazorPage
    {
        public ChatLog()
        {
            
        }
        public override void Execute()
        {

            WriteLiteral("<head>\r\n");
            WriteLiteral("<meta charset=\"utf-8\">\r\n");
            WriteLiteral("<title>聊天记录</title>\r\n");
            WriteLiteral("<link href=\"/Scripts/layui/css/layui.css\" rel=\"stylesheet\">\r\n");
            WriteLiteral("<style>body .layim-chat-main {height: auto;}</style>\r\n");
            WriteLiteral("<link href=\"/css/layim.css\" rel=\"stylesheet\" />\r\n");
            WriteLiteral("</head>\r\n");

            WriteLiteral("<div class=\"layim-chat-main\">\r\n");
            WriteLiteral("<ul id=\"LAY_view\"><div id=\"chatLogMore\" class=\"layim-chat-system\"><span>查看更多记录</span></div> </ul>\r\n");
            WriteLiteral("</div>\r\n");

            WriteLiteral("<script src=\"https://cdn.bootcss.com/jquery/3.2.1/jquery.min.js\"></script>\r\n");
            WriteLiteral("<script src=\"/Scripts/chatlog.min.js\"></script>\r\n");
            WriteLiteral($"<script>chatLogParam.init('{Query("type")}', '{Query("id")}');</script>\r\n");

        }
    }
}
#pragma warning restore 1591
