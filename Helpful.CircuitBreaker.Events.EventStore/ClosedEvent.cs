using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using EventStore.ClientAPI;
using EventStore.ClientAPI.Common.Utils;
using EventStore.ClientAPI.SystemData;

namespace Helpful.CircuitBreaker.Events.EventStore
{
    public class ClosedEvent : IClosedEvent
    {
        public void RaiseEvent(object breakerConfig)
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1113));
            connection.Connect();
            UserCredentials credentials = new UserCredentials("dFine", "Password02");
            connection.AppendToStream("use the breaker name", ExpectedVersion.Any, credentials, breakerConfig.AsJson());
        }
    }
}
