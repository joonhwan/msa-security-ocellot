using System;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace MireroTicket.ServiceBus.RabbitMQ
{
    public class ConnectionProvider
    {
        private readonly ConnectionFactory _factory;

        public ConnectionProvider(IOptions<ServiceBusOptions> configuration)
        {
            var url = configuration.Value.ConnectionString;
            _factory = new ConnectionFactory()
            {
                Uri = new Uri(url),
                ClientProvidedName = configuration.Value.AppId,
            };
        }
        
        public IConnection CreateConnection() => _factory.CreateConnection();
    }
}