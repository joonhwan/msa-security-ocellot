using MireroTicket.Services.ShoppingBasket.Entities;
using MireroTicket.Services.ShoppingBasket.Models;

namespace MireroTicket.Services.ShoppingBasket.Mappers
{
    public static class BasketLineDtoMapper
    {
        public static BasketLineDto From(BasketLine entity)
        {
            EventDto @event = null;
            if (entity.Event != null)
            {
                @event = new EventDto
                {
                    Date = entity.Event.Date,
                    EventId = entity.Event.Id,
                    Name = entity.Event.Name,
                };
            }

            return new BasketLineDto
            {
                Event = @event,
                Price = entity.Price,
                BasketId = entity.BasketId,
                TicketAmount = entity.TicketAmount,
                BasketLineId = entity.Id,
            };
        }
    }
}