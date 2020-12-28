using RabbitMQ.Client;

namespace MireroTicket.ServiceBus.RabbitMQ
{
    internal class NamingRule
    {
        public static string PubSubExchangeNameOf<T>()
        {
            return $"pub@{typeof(T).FullName}";
        }

        public static string WorkerQueueNameOf<T>()
        {
            return $"wrk@{typeof(T).FullName}";
        }
        
    }
}