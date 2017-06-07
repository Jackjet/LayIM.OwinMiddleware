# LayIM.OwinMiddleware 

### 对接 LayIM 实现的一个.NET后端组件。基于Owin开发,组件与WebUI解耦，无论是WebForm还是MVC都可以在 Owin Startup 中配置使用。

## Quick Start

### 引入 LayIM.NetClient.dll,LayIM.SqlServer.dll,Owin.dll（nuget）,Microsoft.Owin.dll(nuget)

### Startup.cs 文件代码如下：

 ` ``public void Configuration(IAppBuilder app)
        {
            //使用SQL Server
            GlobalConfiguration.Configuration.UseSqlServer("LayIM_Connection");

            //使用layim api 
            app.UseLayimApi("/layim", new LayimOptions
            {
                RongCloudSetting = new RongCloudSetting()
            });
        }```
