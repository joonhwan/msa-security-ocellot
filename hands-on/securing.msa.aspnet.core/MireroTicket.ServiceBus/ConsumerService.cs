using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MireroTicket.Messages;

namespace MireroTicket.ServiceBus
{
    // Consumer of "Producer/Consumer". 
    // 수신된 메시지는 오직 하나의 IRequestHandler<TMessage>로 간다.
    public class ConsumerService<T> : IHostedService
        where T : CommandMessage
    {
        private readonly ILogger<ConsumerService<T>> _logger;
        private readonly Consumer<T> _consumer;

        public ConsumerService(IConfiguration configuration, IMediator mediator, ILogger<ConsumerService<T>> logger)
        {
            _logger = logger;
            _consumer = new Consumer<T>(configuration);
            _consumer.OnCommand += obj =>
            {
                mediator.Send(obj); // send only one handler.
            };
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _consumer.Start();
            _logger.LogInformation("Service Started");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _consumer.Stop();
            _consumer.Dispose();
            _logger.LogInformation("Service Stopped");
            return Task.CompletedTask;
        }
    }
}