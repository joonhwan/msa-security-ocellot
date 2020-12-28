using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MireroTicket.ServiceBus.RabbitMQ
{
    public class ServiceBusBuilder : IServiceBusBuilder
    {
        public ServiceBusBuilder(IServiceCollection services)
        {
            services.AddSingleton<ConnectionProvider>();
        }

        public IServiceCollection Services { get; set; }

        public IServiceBusBuilder AddPublisher<T>() where T : INotification
        {
            Services.TryAddTransient<IMessagePublisher<T>, Publisher<T>>();
            return this;
        }

        public IServiceBusBuilder AddSubscriptionService<T>() where T : INotification
        {
            Services.AddHostedService<SubscriptionService<T>>();
            return this;
        }

        public IServiceBusBuilder AddProducer<T>() where T : IRequest
        {
            Services.TryAddTransient<IMessageProducer<T>, Producer<T>>();
            return this;
        }

        public IServiceBusBuilder AddConsumerService<T>() where T : IRequest
        {
            Services.AddHostedService<ConsumerService<T>>();
            return this;
        }
    }
}