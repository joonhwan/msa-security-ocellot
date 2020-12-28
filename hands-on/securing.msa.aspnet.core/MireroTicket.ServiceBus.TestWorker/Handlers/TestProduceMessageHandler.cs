using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MireroTicket.ServiceBus.TestMessages;

namespace MireroTicket.ServiceBus.TestWorker.Handlers
{
    public class TestProduceMessageHandler : AsyncRequestHandler<TestProduceMessage>
    {
        private readonly WorkerIdentity _worker;

        public TestProduceMessageHandler(WorkerIdentity worker)
        {
            _worker = worker;
        }
        
        // 만일 IRequestHandler<TestProduceMessage> 로 부터 상속 받았다면...
        //
        // public Task<Unit> Handle(TestProduceMessage request, CancellationToken cancellationToken)
        // {
        //     Console.WriteLine($"{_worker.Id} : Received `TestProduceMessage`");
        //     Console.WriteLine($"   ---> message = {request.Message}");
        //     return Task.FromResult(Unit.Value);
        // }
        //
        // --> 지저분해 보이지?  
        
        protected override Task Handle(TestProduceMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{_worker.Id} : Received `TestProduceMessage`");
            Console.WriteLine($"   ---> message = {request.Body}, createdAT = {request.CreatedAt:s}");
            return Task.CompletedTask;
        }
    }
}