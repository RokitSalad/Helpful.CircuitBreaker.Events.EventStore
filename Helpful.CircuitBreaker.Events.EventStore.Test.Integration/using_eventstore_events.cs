using System.Net;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;

namespace Helpful.CircuitBreaker.Events.EventStore.Test.Integration
{
    abstract class using_eventstore_events : BDD.TestBase
    {
        protected const string BreakerId = "BreakerId";
        protected const string TestValue = "TestValue";

        protected IEventStoreConnection Connection { get; private set; }
        protected UserCredentials UserCredentials { get; private set; }
        protected IEventFactory EventFactory { get; private set; }

        protected override void Given()
        {
            UserCredentials = new UserCredentials("dFine", "Password02");
            Connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1113));
            EventFactory = new EventFactory(UserCredentials,
                Connection);
        }
    }
}
