using System;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;

namespace Helpful.CircuitBreaker.Events.EventStore
{
    public class TolleratedOpenEvent : ITolleratedOpenEvent
    {
        private readonly UserCredentials _credentials;
        private readonly IEventStoreConnection _connection;

        public TolleratedOpenEvent(UserCredentials credentials, IEventStoreConnection connection)
        {
            _credentials = credentials;
            _connection = connection;
        }

        public void RaiseEvent(short tolleratedOpenEventCount, ICircuitBreakerDefinition breakerDefinition, BreakerOpenReason reason,
            Exception thrownException)
        {
            _connection.AppendToStreamAsync(StreamFormatter.GetStreamWithCategory("TolleratedOpenEvent", breakerDefinition.BreakerId),
                ExpectedVersion.Any, _credentials, breakerDefinition.AsJson());
        }
    }
}