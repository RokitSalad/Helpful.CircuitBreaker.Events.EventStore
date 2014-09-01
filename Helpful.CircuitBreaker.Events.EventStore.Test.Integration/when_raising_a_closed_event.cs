using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpful.BDD;

namespace Helpful.CircuitBreaker.Events.EventStore.Test.Integration
{
    class when_raising_a_closed_event : using_eventstore_events
    {
        private IClosedEvent _closedEvent;
        private ICircuitBreakerDefinition _definition;
        private string _testValue;

        protected override void Given()
        {
            base.Given();
            _closedEvent = EventFactory.GetClosedEvent();
            _testValue = Guid.NewGuid().ToString();
            _definition = new TestConfig
            {
                BreakerId = "BreakerId",
                TestValue = _testValue
            };
        }

        protected override void When()
        {
            _closedEvent.RaiseEvent(_definition);
        }

        [Then]
        public void the_event_is_in_the_store()
        {
        }
    }
}
