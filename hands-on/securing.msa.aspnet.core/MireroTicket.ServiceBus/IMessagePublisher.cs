using System.Threading.Tasks;
using MediatR;

namespace MireroTicket.ServiceBus
{
    public interface IMessagePublisher<in T>
        where T : INotification
    {
        Task Publish(T message);
    }
}