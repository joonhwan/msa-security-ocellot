using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using RabbitMQ.Client;

namespace MireroTicket.ServiceBus.RabbitMQ
{
    public class Publisher<T> : IMessagePublisher<T> where T : INotification
    {
        private readonly ConnectionProvider _connectionProvider;

        public Publisher(ConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }
        
        // TODO 어떻게 async 하게?
        public Task Publish(T message)
        {
            try
            {
                using var connection = _connectionProvider.CreateConnection();
                using var channel = connection.CreateModel();

                var exchangeName = NamingRule.PubSubExchangeNameOf<T>();
                channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout, durable: false, autoDelete: false, null);
            
                var messageType = typeof(T).AssemblyQualifiedName;
            
                var props = channel.CreateBasicProperties();
                // props.AppId = "MireroTicket";
                props.ContentEncoding = "utf8";
                props.ContentType = "application/json";
                props.Headers = new Dictionary<string, object>
                {
                    ["message_type"] = messageType,
                };
            
                var json = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchangeName, "", props, body);

                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                throw new ServiceBusException($"Failed in Publish Message(Type={typeof(T).FullName}", e);
            }
        }
    }
}