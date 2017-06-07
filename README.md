# LayIM.OwinMiddleware 

###### 对接 LayIM 实现的一个.NET后端组件。基于Owin开发,组件与WebUI解耦，无论是WebForm还是MVC都可以在 Owin Startup 中配置使用。

###### Quick Start

######  LayIM.NetClient

###### 实现了路由注册，数据请求处理等公共逻辑。 通讯默认使用了融云通信。

######  LayIM.SqlServer

###### 实现了LayIM的通用接口方法，用户好友列表，群组列表等。

###### Startup.cs 文件代码如下：

 ```C#
 public void Configuration(IAppBuilder app)
        {
            //使用SQL Server
            GlobalConfiguration.Configuration.UseSqlServer("LayIM_Connection");

            //使用layim api 
            app.UseLayimApi("/layim", new LayimOptions
            {
                RongCloudSetting = new RongCloudSetting()
                // RongCloudSetting = new RongCloudSetting("appKey","appSecret");
            });
        }
 ```
###### 或者在配置文件中配置相应的信息。

```
 <!--融云配置-->
    <add key="RongCloud_AppKey" value="pvxdm17jpv1or"/>
    <add key="RongCloud_AppSecret" value="Co2RwQhzkL6G8i"/>
    
     <connectionStrings>
    <add name="LayIM_Connection" connectionString="****************"/>
  </connectionStrings>
```

###### LayIM 官网： http://layim.layui.com
