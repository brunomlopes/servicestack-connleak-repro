using Funq;
using PushNotifications.ServiceInterface;
using ServiceStack;
using ServiceStack.Caching;
using ServiceStack.Text;

namespace PushNotifications
{
    public class AppHost : AppHostBase
    {

        /// <summary>
        /// Default constructor.
        /// Base constructor requires a name and assembly to locate web service classes. 
        /// </summary>
        public AppHost()
            : base("PushNotifications", typeof(MyServices).Assembly)
        {
        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        /// <param name="container"></param>
        public override void Configure(Container container)
        {
            RegisterPlugins();

            RegisterDependencies(container);

            SetupIdiomaticJavascriptOutput();
        }

        private void SetupIdiomaticJavascriptOutput()
        {
            JsConfig.EmitCamelCaseNames = true;
        }

        private void RegisterPlugins()
        {
            Plugins.Add(new ServerEventsFeature
            {
                NotifyChannelOfSubscriptions = false,
                OnSubscribe = subscription =>
                {
                    // validate permissions
                },
                LimitToAuthenticatedUsers = false,
                
            });
        }

        private static void RegisterDependencies(Container container)
        {
            container.Register<ICacheClient>(new MemoryCacheClient());
        }
    }
}
