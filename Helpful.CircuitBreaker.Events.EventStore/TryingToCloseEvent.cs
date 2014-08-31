using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;

namespace Helpful.CircuitBreaker.Events.EventStore
{
    public class TryingToCloseEvent : ITryingToCloseEvent
    {
        private readonly UserCredentials _credentials;
        private readonly IEventStoreConnection _connection;

        public TryingToCloseEvent(UserCredentials credentials, IEventStoreConnection connection)
        {
            _credentials = credentials;
            _connection = connection;
        }

        public void RaiseEvent(ICircuitBreakerDefinition breakerDefinition)
        {
            _connection.AppendToStreamAsync(StreamFormatter.GetStreamWithCategory("TryingToCloseEvent", breakerDefinition.BreakerId),
                ExpectedVersion.Any, _credentials, breakerDefinition.AsJson());
        }
    }
}