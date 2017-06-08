﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LayIM.NetClient
{
    public static class RouteCollectionExtensions
    {
        /// <summary>
        /// 添加执行命令的路由
        /// </summary>
        /// <param name="routes">路由集合</param>
        /// <param name="pathTemplate">路由地址</param>
        /// <param name="command">执行命令参数</param>
        public static void AddCommand(this RouteCollection routes, string pathTemplate, Func<LayimContext, bool> command)
        {
            Error.ThrowIfNull(routes, nameof(routes));
            Error.ThrowIfNull(pathTemplate, nameof(pathTemplate));
            Error.ThrowIfNull(command, nameof(command));

            routes.Add(pathTemplate, new CommandDispatcher(command));
        }

        /// <summary>
        /// 添加查询命令的路由
        /// </summary>
        /// <param name="routes">路由集合</param>
        /// <param name="pathTemplate">路由地址</param>
        /// <param name="query">查询命令参数</param>
        public static void AddQuery(this RouteCollection routes, string pathTemplate, Func<LayimContext, object> query)
        {
            Error.ThrowIfNull(routes, nameof(routes));
            Error.ThrowIfNull(pathTemplate, nameof(pathTemplate));
            Error.ThrowIfNull(query, nameof(query));

            routes.Add(pathTemplate, new QueryDispatcher(query));
        }

        /// <summary>
        /// 添加带参数的查询命令路由
        /// </summary>
        /// <typeparam name="T">参数类型</typeparam>
        /// <param name="routes">路由集合</param>
        /// <param name="pathTemplate">路由地址</param>
        /// <param name="parameterName">参数名</param>
        /// <param name="query">查询命令参数</param>
        public static void AddQuery<T>(this RouteCollection routes, string pathTemplate, string parameterName, Func<LayimContext, T, object> query)
        {
            Error.ThrowIfNull(routes, nameof(routes));
            Error.ThrowIfNull(pathTemplate, nameof(pathTemplate));
            Error.ThrowIfNull(query, nameof(query));

            routes.Add(pathTemplate, new SingleParameterQueryDispatcher<T>(parameterName, query));
        }

        /// <summary>
        /// 添加路由页面
        /// </summary>
        /// <param name="routes">路由集合</param>
        /// <param name="pathTemplate">路由地址</param>
        /// <param name="pageFunc">生成页面的方法</param>
        public static void AddRazorPage(this RouteCollection routes, string pathTemplate, Func<Match, RazorPage> pageFunc)
        {
            Error.ThrowIfNull(routes, nameof(routes));
            Error.ThrowIfNull(pathTemplate, nameof(pathTemplate));
            Error.ThrowIfNull(pageFunc, nameof(pageFunc));

            routes.Add(pathTemplate, new RazorPageDispatcher(pageFunc));
        }

    }
}
