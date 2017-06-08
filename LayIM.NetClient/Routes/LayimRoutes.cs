using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayIM.NetClient
{
   /*
    * LayIM 路由
    * 所有关于 LayIM 的请求都会从此路由中寻找相应的请求地址
    */
    public static class LayimRoutes
    {
        //对外共开
        public static RouteCollection Routes { get; }

        static LayimRoutes()
        {
            Routes = new RouteCollection();

            //获取用户好友列表
            Routes.AddQuery<long>("/init", "id", (context, uid) =>
             {
                 var client = new LayimUserClient(context.Storage, uid);
                 return client.GetInitInfo();
             });

            //根据群id 获取组员列表
            Routes.AddQuery<long>("/members","id", (context,gid) =>
            {
                var client = new LayimUserClient(context.Storage, gid);
                return client.GetGroupMembers();
            });

            //获取融云token方法
            Routes.AddQuery<string>("/token", "id", (context, uid) =>
            {

                var cloud = RongCloudContainer.CreateInstance(context.Options?.RongCloudSetting);
                var token = cloud.GetToken(uid);
                return token;
            });

            //添加历史记录
            Routes.AddCommand("/chat", context =>
            {
                var client = new LayimUserClient(context.Storage, context.Request);
                return client.AddMsg();
            });


            //页面
            Routes.AddRazorPage("/chatlog", x => new ChatLog());
            //历史记录局部视图
            Routes.AddRazorPage("/history", x => new HistoryMessagePage());
        }
    }
}
