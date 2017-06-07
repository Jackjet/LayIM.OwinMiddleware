using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace LayIM.NetClient
{
    /*
     *查询命令，非GET方法不能访问
     * 
     */
    internal class QueryDispatcher : ILayimDispatcher
    {
        private readonly Func<LayimContext, object> _command;
        /// <summary>
        /// 命令只准使用GET执行
        /// </summary>
        private const string CommandMethod = "GET";

        public QueryDispatcher(Func<LayimContext, object> command)
        {
            _command = command;
        }
        public async Task Dispatch(LayimContext context)
        {
            var request = context.Request;
            var response = context.Response;

            if (!CommandMethod.Equals(request.Method, StringComparison.OrdinalIgnoreCase))
            {
                response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                await Task.FromResult(false);
            }

            context.Response.ContentType = "application/json";

            var result = _command(context);

            var json = context.Options.Serializer.SerializeObject(result);

            await context.Response.WriteAsync(json);
        }
    }
}
