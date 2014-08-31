using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;

namespace Helpful.CircuitBreaker.Events.EventStore
{
    public class ClosedEvent : IClosedEvent
    {
        private readonly UserCredentials _credentials;
        private readonly IEventStoreConnection _connection;

        public ClosedEvent(UserCredentials credentials, IEventStoreConnection connection)
        {
            _credentials = credentials;
            _connection = connection;
        }

        public void RaiseEvent(ICircuitBreakerDefinition breakerDefinition)
        {
            _connection.AppendToStreamAsync(StreamFormatter.GetStreamWithCategory("ClosedEvent", breakerDefinition.BreakerId),
                ExpectedVersion.Any, _credentials, breakerDefinition.AsJson());

            //var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1113));
            //connection.Connect();
            //UserCredentials credentials = new UserCredentials("dFine", "Password02");
            //connection.AppendToStream("use the breaker name", ExpectedVersion.Any, credentials, breakerConfig.AsJson());
        }
    }
}
