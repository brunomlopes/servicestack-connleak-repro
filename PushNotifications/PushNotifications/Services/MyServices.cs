using System;
using PushNotifications.ServiceModel;
using ServiceStack;

namespace PushNotifications.ServiceInterface
{
    public class MyServices : Service
    {
        private readonly IServerEvents _serverEvents;

        public MyServices( IServerEvents serverEvents)
        {
            _serverEvents = serverEvents;
        }

        public object Any(Hello request)
        {
            return new HelloResponse
            {
                Version = 1
            };
        }

        public object Any(HelloPush request)
        {
            // Notify everyone in the channel for public messages
            _serverEvents.NotifyChannel("chan", "chan.names", request.Name);

            _serverEvents.NotifyChannel("chan", "chan.testing", new Dto
            {
                Id = 1,
                Name = "Name",
                Birthday = DateTimeOffset.UtcNow
            });

            return new HelloPushResponse
            {
                Result = "Hello, {0}!".Fmt(request.Name)
            };
        }
    }

    public class Dto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Birthday { get; set; }
    }
}
