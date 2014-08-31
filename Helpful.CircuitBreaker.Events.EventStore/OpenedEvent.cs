using System;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;

namespace Helpful.CircuitBreaker.Events.EventStore
{
    public class OpenedEvent : IOpenedEvent
    {
        private readonly UserCredentials _credentials;
        private readonly IEventStoreConnection _connection;

        public OpenedEvent(UserCredentials credentials, IEventStoreConnection connection)
        {
            _credentials = credentials;
            _connection = connection;
        }

        public void RaiseEvent(ICircuitBreakerDefinition breakerDefinition, BreakerOpenReason reason, Exception thrownException)
        {
            _connection.AppendToStreamAsync(StreamFormatter.GetStreamWithCategory("OpenedEvent", breakerDefinition.BreakerId),
                ExpectedVersion.Any, _credentials, breakerDefinition.AsJson());
        }
    }
}