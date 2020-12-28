using System.Threading.Tasks;
using MediatR;

namespace MireroTicket.ServiceBus
{
    public interface IMessagePublisher<in T>
        where T : INotification
    {
        public Task Publish(T message);
    }
}