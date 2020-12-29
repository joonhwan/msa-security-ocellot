using System;
using System.Linq;
using MireroTicket.ServiceBus.Attributes;
using RabbitMQ.Client;

namespace MireroTicket.ServiceBus.RabbitMQ
{
    internal class NamingRule
    {
        public static string PubSubExchangeNameOf<T>()
        {
            var name = GetTypeName<T>();
            return $"pub@{name}";
        }

        public static string WorkerQueueNameOf<T>()
        {
            var name = GetTypeName<T>();
            return $"wrk@{name}";
        }
        private static string GetTypeName<T>()
        {
            var alias = Attribute.GetCustomAttribute(typeof(T), typeof(AliasAttribute)) as AliasAttribute;
            var name = alias?.Name ?? typeof(T).FullName;
            return name;
        }
    }
}