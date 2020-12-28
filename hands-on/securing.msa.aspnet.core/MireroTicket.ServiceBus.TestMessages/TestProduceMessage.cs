using System;
using MediatR;

namespace MireroTicket.ServiceBus.TestMessages
{
    public class TestProduceMessage : IRequest
    {
        public DateTime CreatedAt { get; set; }
        public string Body { get; set; }
    }
}