using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MireroTicket.ServiceBus.TestMessages;

namespace MireroTicket.ServiceBus.TestWorker.Handlers
{
    public class TestPublishMessageHandler : INotificationHandler<TestPublishMessage>
    {
        private readonly WorkerIdentity _worker;

        public TestPublishMessageHandler(WorkerIdentity worker)
        {
            _worker = worker;
        }
        
        public Task Handle(TestPublishMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{_worker.Id} : Received `TestPublishMessage`");
            Console.WriteLine($"   ---> message = {request.Body}, createdAT = {request.CreatedAt:s}");
            return Task.CompletedTask;
        }
    }
}