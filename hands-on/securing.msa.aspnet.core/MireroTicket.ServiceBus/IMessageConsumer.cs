using MediatR;

namespace MireroTicket.ServiceBus
{
    public interface IMessageConsumer<in T>
        where T : IRequest
    {
        void Consume(T message);
    }
}