using System;

namespace RabbitMQ.Queue.Messages
{
    public class SampleMessage
    {
        public DateTime TimeCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{nameof(TimeCode)}: {TimeCode}, {nameof(Message)}: {Message}";
        }
    }
}