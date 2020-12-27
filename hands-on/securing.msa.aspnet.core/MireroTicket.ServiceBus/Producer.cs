using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using MireroTicket.Messages;
using RabbitMQ.Client;

namespace MireroTicket.ServiceBus
{
    public class Producer
    {
        private readonly ConnectionFactory _factory;

        public Producer(IConfiguration configuration)
        {
            var url = configuration.GetConnectionString("AMQP");
            _factory = new ConnectionFactory()
            {
                Uri = new Uri(url)
            };
        }

        public void Send<T>(T message) 
            where T : CommandMessage
        
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            var queueName = typeof(T).FullName;
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
        }
    }
}