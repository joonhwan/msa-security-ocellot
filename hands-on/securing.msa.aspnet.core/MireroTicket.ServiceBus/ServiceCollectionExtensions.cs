using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MireroTicket.ServiceBus
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitServiceBus(this IServiceCollection services, Action<IServiceBusBuilder> configure)
        {
            var builder = new RabbitMQ.ServiceBusBuilder(services)
            {
                Services = services
            };
            configure?.Invoke(builder);
            return services;
        }
    }

    public interface IServiceBusBuilder
    {
        IServiceCollection Services { get; }
        IServiceBusBuilder AddPublisher<T>() where T : INotification;
        IServiceBusBuilder AddSubscriptionService<T>() where T : INotification;
        IServiceBusBuilder AddProducer<T>() where T : IRequest;
        IServiceBusBuilder AddConsumerService<T>() where T : IRequest;
        
    }

}