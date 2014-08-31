namespace Helpful.CircuitBreaker.Events.EventStore
{
    internal static class StreamFormatter
    {
        internal static string GetStreamWithCategory(string category, string breakerId)
        {
            return string.Format("CircuitBreaker{0}_{1}", breakerId, category);
        }
    }
}
