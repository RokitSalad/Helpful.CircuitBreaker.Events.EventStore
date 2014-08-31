using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;

namespace Helpful.CircuitBreaker.Events.EventStore
{
    public class EventFactory : IEventFactory
    {
        private readonly UserCredentials _credentials;
        private readonly IEventStoreConnection _connection;

        public EventFactory(UserCredentials credentials, IEventStoreConnection connection)
        {
            _credentials = credentials;
            _connection = connection;
        }

        public IClosedEvent GetClosedEvent()
        {
            throw new NotImplementedException();
        }

        public IOpenedEvent GetOpenedEvent()
        {
            throw new NotImplementedException();
        }

        public ITryingToCloseEvent GetTriedToCloseEvent()
        {
            throw new NotImplementedException();
        }

        public IUnregisterBreakerEvent GetUnregisterBreakerEvent()
        {
            throw new NotImplementedException();
        }

        public IRegisterBreakerEvent GetRegisterBreakerEvent()
        {
            throw new NotImplementedException();
        }

        public ITolleratedOpenEvent GetTolleratedOpenEvent()
        {
            throw new NotImplementedException();
        }
    }
}
