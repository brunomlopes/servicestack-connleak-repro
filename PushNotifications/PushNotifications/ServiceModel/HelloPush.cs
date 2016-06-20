using ServiceStack;

namespace PushNotifications.ServiceModel
{
    [Route("/helloPush")]
    [Route("/helloPush/{Name}")]
    public class HelloPush : IReturn<HelloPushResponse>
    {
        public string Name { get; set; }
    }

    public class HelloPushResponse
    {
        public string Result { get; set; }
    }
}
