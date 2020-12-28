using System;
using System.Text;
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MireroTicket.ServiceBus.RabbitMQ
{
    public class Consumer<T> : IDisposable
        where T : IRequest
    {
        private readonly ConnectionProvider _connectionProvider;
        private IConnection _connection;
        private IModel _channel;
        private EventingBasicConsumer _consumer;
        
        public Consumer(ConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public event Action<T> OnCommand;

        public void Start()
        {
            if (_connection != null || _channel != null)
            {
                Console.WriteLine("Consumer Already Started.");
                return;
            }

            var queueName = NamingRule.WorkerQueueNameOf<T>();
            _connection = _connectionProvider.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queueName, false, false, false, null);

            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += OnReceived;
            _channel.BasicConsume(_consumer, queueName, true);
        }

        public void Stop()
        {
            _connection?.Dispose();
            _connection = null;
            _channel?.Dispose();
            _channel = null;
            Console.WriteLine($"Consumer<{typeof(T).FullName}> Stopped.");
        }

        private void OnReceived(object sender, BasicDeliverEventArgs e)
        {
            try
            {
                // TODO Check Header["message_type"] == typeof(T).AssemblyQualifiedName
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                var command = JsonSerializer.Deserialize<T>(message);
                OnCommand?.Invoke(command);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}