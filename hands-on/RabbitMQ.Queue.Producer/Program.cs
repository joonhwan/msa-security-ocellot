using System;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Logging;
using RabbitMQ.Queue.Messages;

namespace RabbitMQ.Queue.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigHelper.GetAppSettingsConfig();
            var publisher = new Publisher(config);
            
            var message = new SampleMessage
            {
                TimeCode = DateTime.UtcNow,
                Message = $"Hello I'm Producer"
            };
            publisher.Publish(message);
        }
    }
}