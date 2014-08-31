using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;

namespace Helpful.CircuitBreaker.Events.EventStore
{
    public class UnregisterBreakerEvent : IUnregisterBreakerEvent
    {
        private readonly UserCredentials _credentials;
        private readonly IEventStoreConnection _connection;

        public UnregisterBreakerEvent(UserCredentials credentials, IEventStoreConnection connection)
        {
            _credentials = credentials;
            _connection = connection;
        }

        public void RaiseEvent(ICircuitBreakerDefinition breakerDefinition)
        {
            _connection.AppendToStreamAsync(StreamFormatter.GetStreamWithCategory("UnregisterBreakerEvent", breakerDefinition.BreakerId),
                ExpectedVersion.Any, _credentials, breakerDefinition.AsJson());
        }
    }
}