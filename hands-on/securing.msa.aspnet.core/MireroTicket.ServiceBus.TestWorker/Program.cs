using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MireroTicket.ServiceBus.TestMessages;

namespace MireroTicket.ServiceBus.TestWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<WorkerIdentity>();
                    services.Configure<ServiceBusOptions>(hostContext.Configuration.GetSection("ServiceBus"));
                    services.AddRabbitServiceBus(builder =>
                    {
                        builder.AddConsumerService<TestProduceMessage>();
                        builder.AddSubscriptionService<TestPublishMessage>();
                    });
                    // services.AddHostedService<Worker>();

                    services.AddMediatR(new[]
                    {
                        typeof(TestProduceMessage).Assembly,
                        typeof(Program).Assembly,
                    });
                    
                    // var provider = services.BuildServiceProvider();
                    // var mediator = provider.GetRequiredService<IMediator>();
                    // //mediator.Publish(new TestProduceMessage() {Message = "Hi, I'm Publishing"});
                    // mediator.Send(new TestProduceMessage() {Message = "Hi, I'm Sending"});
                    // var handler = provider.GetRequiredService< IRequestHandler<TestProduceMessage, Unit> >();
                    // handler.Handle(new TestProduceMessage() {Message = "Hi."}, CancellationToken.None);
                });
    }
    
    
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var response = await next();
            _logger.LogInformation($"Handled {typeof(TResponse).Name}");

            return response;
        }
    }
}