using System;
using System.Diagnostics;

namespace MireroTicket.ServiceBus.TestWorker
{
    public class WorkerIdentity
    {
        public WorkerIdentity()
        {
            Id = $"Process[{Process.GetCurrentProcess().Id}] Worker";
        }
        
        public string Id { get; }
    }
}