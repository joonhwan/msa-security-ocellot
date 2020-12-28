using System;

namespace MireroTicket.ServiceBus
{
    public class ServiceBusException : Exception
    {

        public ServiceBusException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}