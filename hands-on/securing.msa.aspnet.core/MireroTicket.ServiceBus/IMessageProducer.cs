using System.Threading.Tasks;
using MediatR;

namespace MireroTicket.ServiceBus
{
    public interface IMessageProducer<in T>
        where T : IRequest
    {
        public Task Produce(T message);
    }
}