using System;
using MediatR;

namespace MireroTicket.Messages
{
    public class NotificationMessage : INotification
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}