using System;
using MediatR;

namespace MireroTicket.ServiceBus.TestMessages
{
    public class TestPublishMessage : INotification
    {
        public DateTime CreatedAt { get; set; }
        public string Body { get; set; }
    }
}