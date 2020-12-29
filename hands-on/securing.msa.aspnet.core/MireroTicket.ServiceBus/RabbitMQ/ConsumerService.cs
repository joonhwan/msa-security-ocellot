using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MireroTicket.ServiceBus.RabbitMQ
{
    // Consumer of "Producer/Consumer". 
    // 수신된 메시지는 오직 하나의 IRequestHandler<TMessage>로 간다.
    public class ConsumerService<T> : BackgroundService
        where T : IRequest
    {
        private readonly ConnectionProvider _connectionProvider;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<ConsumerService<T>> _logger;
        
        public ConsumerService(ConnectionProvider connectionProvider, IServiceScopeFactory serviceScopeFactory, ILogger<ConsumerService<T>> logger)
        {
            _connectionProvider = connectionProvider;
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var consumer = new Consumer<T>(_connectionProvider);
            consumer.OnCommand += message =>
            {
                using var scope = _serviceScopeFactory.CreateScope(); // TODO Correct?
                var mediator = scope.ServiceProvider.GetService<IMediator>();
                mediator.Send(message, stoppingToken); // send only one handler.
            };
            
            consumer.Start();
            _logger.LogInformation($"Started ConsumerService<{typeof(T).FullName}>.");
                
            // 1초에 한번씩 깨어나서 정지요청되었는지 확인.
            while (!stoppingToken.IsCancellationRequested)
            {
                // _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }

            consumer.Stop();
            Console.WriteLine($"Stopped ConsumerService<{typeof(T).FullName}>.");
        }
    }
}