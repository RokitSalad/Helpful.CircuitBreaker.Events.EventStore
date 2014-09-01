namespace Helpful.CircuitBreaker.Events.EventStore.Test.Integration
{
    class TestConfig : ICircuitBreakerDefinition
    {
        public string BreakerId { get; set; }

        public string TestValue { get; set; }
    }
}
