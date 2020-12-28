using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace MireroTicket.ServiceBus.RabbitMQ
{
    public class Producer<T> : IMessageProducer<T> 
        where T : IRequest
    {
        private readonly ConnectionProvider _connectionProvider;
        
        public Producer(ConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public Task Produce(T message)
        {
            using var connection = _connectionProvider.CreateConnection();
            using var channel = connection.CreateModel();

            var queueName = NamingRule.WorkerQueueNameOf<T>();
            var queueDeclareOk = channel.QueueDeclare(queueName, false, false, false);
            
            var json = JsonSerializer.Serialize(message);
            var bytes = Encoding.UTF8.GetBytes(json);
            var messageType = typeof(T).AssemblyQualifiedName;

            var props = channel.CreateBasicProperties();
            // props.AppId = "MireroTicket";
            props.ContentEncoding = "utf8";
            props.ContentType = "application/json";
            props.Headers = new Dictionary<string, object>
            {
                ["message_type"] = messageType,
            };
            channel.BasicPublish("", queueName, props, bytes);

            return Task.CompletedTask; 
        }
    }
}