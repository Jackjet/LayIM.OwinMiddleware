
using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

using LayIM.NetClient;
using LayIM.SqlServer;

[assembly: OwinStartup(typeof(MVCSample.Startup))]

namespace MVCSample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //使用SQL Server
            GlobalConfiguration.Configuration.UseSqlServer("LayIM_Connection");

            //使用layim api 6tnym1brnmpt7
            var options = new LayimOptions
            {
                RongCloudSetting = new RongCloudSetting()
            };

           // options.UseProvider(() => { return null; });
           // options.UseSerializer(() => { return null; });

            app.UseLayimApi("/layim", options);
        }
    }
}
