using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MireroTicket.ServiceBus.RabbitMQ
{
    public class Subscriber<T> : IDisposable
    {
        private readonly ConnectionProvider _connectionProvider;
        private IConnection _connection;
        private IModel _channel;
        private EventingBasicConsumer _consumer;

        public Subscriber(ConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public event Action<T> OnNotified;

        public void Start()
        {
            if (_connection != null || _channel != null)
            {
                Console.WriteLine("Consumer Already Started.");
                return;
            }

            _connection = _connectionProvider.CreateConnection();
            _channel = _connection.CreateModel();

            var exchangeName = NamingRule.PubSubExchangeNameOf<T>();
            _channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);

            var queueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queueName, exchangeName, "");

            _consumer = new EventingBasicConsumer(_channel);
            _consumer.Received += ConsumerOnReceived;

            _channel.BasicConsume(queue: queueName, autoAck: true, consumer: _consumer);
        }

        private void ConsumerOnReceived(object sender, BasicDeliverEventArgs e)
        {
            try
            {
                // TODO Check Header["message_type"] == typeof(T).AssemblyQualifiedName
                var message = Encoding.UTF8.GetString(e.Body.ToArray());
                var notification = JsonSerializer.Deserialize<T>(message);
                OnNotified?.Invoke(notification);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void Stop()
        {
            if (_connection != null || _channel != null || _consumer != null)
            {
                _connection?.Dispose();
                _connection = null;
                _channel?.Dispose();
                _channel = null;
                _consumer = null;
                Console.WriteLine($"Consumer<{typeof(T).FullName}> Stopped.");
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}