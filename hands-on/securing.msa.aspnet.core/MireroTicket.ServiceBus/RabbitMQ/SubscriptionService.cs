using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MireroTicket.ServiceBus.RabbitMQ
{
    public class SubscriptionService<T> : BackgroundService
        where T : INotification
    {
        private readonly ConnectionProvider _connectionProvider;
        private readonly IMediator _mediator;
        private readonly ILogger<SubscriptionService<T>> _logger;

        public SubscriptionService(ConnectionProvider connectionProvider, IMediator mediator,
            ILogger<SubscriptionService<T>> logger)
        {
            _connectionProvider = connectionProvider;
            _mediator = mediator;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var subscriber = new Subscriber<T>(_connectionProvider);
            subscriber.OnNotified += message =>
            {
                _mediator.Publish(message, stoppingToken); // send only one handler.
            };

            subscriber.Start();
            _logger.LogInformation($"Started SubscriptionService<{typeof(T).FullName}>.");

            // 1초에 한번씩 깨어나서 정지요청되었는지 확인.
            while (!stoppingToken.IsCancellationRequested)
            {
                // _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }

            subscriber.Stop();
            Console.WriteLine($"Stopped SubscriptionService<{typeof(T).FullName}>.");
        }
    }
}