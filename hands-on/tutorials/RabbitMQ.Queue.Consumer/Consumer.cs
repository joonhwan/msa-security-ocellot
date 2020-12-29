using System;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ.Queue.Consumer
{
    public class Consumer<T> : IDisposable
    {
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        private EventingBasicConsumer _consumer;
        
        public Consumer(IConfiguration config)
        {
            var url = config.GetConnectionString("AMQP");
            _factory = new ConnectionFactory()
            {
                Uri = new Uri(url),
            };
        }

        private string QueueName { get; set; } = typeof(T).FullName;
        public event Action<T> MessageReceived;

        public void Start()
        {
            if (_connection != null || _channel != null)
            {
                Console.WriteLine("Consumer Already Started.");
                return;
            }
            
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(QueueName, false, false, false, null);

            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += OnReceived;
            _channel.BasicConsume(_consumer, QueueName, true);
            Console.WriteLine("Consumer Started.");
        }

        public void Stop()
        {
            _connection?.Dispose();
            _connection = null;
            _channel?.Dispose();
            _channel = null;
            Console.WriteLine("Consumer Stopped.");
        }

        private void OnReceived(object sender, BasicDeliverEventArgs e)
        {
            try
            {
                // TODO Check Header["message_type"] == typeof(T).AssemblyQualifiedName
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                var messageObj = JsonSerializer.Deserialize<T>(message);
                MessageReceived?.Invoke(messageObj);
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