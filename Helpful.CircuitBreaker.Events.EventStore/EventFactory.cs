using System;
using EventStore.ClientAPI;
using EventStore.ClientAPI.SystemData;

namespace Helpful.CircuitBreaker.Events.EventStore
{
    public class EventFactory : IEventFactory
    {
        private readonly IClosedEvent _closedEvent;
        private readonly IOpenedEvent _openedEvent;
        private readonly IRegisterBreakerEvent _registerBreakerEvent;
        private readonly ITryingToCloseEvent _tryingToCloseEvent;
        private readonly IUnregisterBreakerEvent _unregisterBreakerEvent;
        private readonly ITolleratedOpenEvent _tolleratedOpenEvent;

        public EventFactory(UserCredentials credentials, IEventStoreConnection connection)
        {
            _closedEvent = new ClosedEvent(credentials, connection);
            _openedEvent = new OpenedEvent(credentials, connection);
            _registerBreakerEvent = new RegisterBreakerEvent(credentials, connection);
            _tryingToCloseEvent = new TryingToCloseEvent(credentials, connection);
            _unregisterBreakerEvent = new UnregisterBreakerEvent(credentials, connection);
            _tolleratedOpenEvent = new TolleratedOpenEvent(credentials, connection);
        }

        public IClosedEvent GetClosedEvent()
        {
            return _closedEvent;
        }

        public IOpenedEvent GetOpenedEvent()
        {
            return _openedEvent;
        }

        public ITryingToCloseEvent GetTriedToCloseEvent()
        {
            return _tryingToCloseEvent;
        }

        public IUnregisterBreakerEvent GetUnregisterBreakerEvent()
        {
            return _unregisterBreakerEvent;
        }

        public IRegisterBreakerEvent GetRegisterBreakerEvent()
        {
            return _registerBreakerEvent;
        }

        public ITolleratedOpenEvent GetTolleratedOpenEvent()
        {
            return _tolleratedOpenEvent;
        }
    }
}
