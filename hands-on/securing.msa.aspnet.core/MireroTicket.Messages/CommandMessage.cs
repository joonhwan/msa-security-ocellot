﻿using System;
using MediatR;

namespace MireroTicket.Messages
{
    public class CommandMessage : IRequest
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}