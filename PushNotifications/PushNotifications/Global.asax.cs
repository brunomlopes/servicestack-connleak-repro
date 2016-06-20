using System;
using ServiceStack;

namespace PushNotifications
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var appHost = new AppHost();
            appHost
                .SetConfig(new HostConfig()
                {
                    DebugMode = true
                });
            appHost.Init();
        }
    }
}