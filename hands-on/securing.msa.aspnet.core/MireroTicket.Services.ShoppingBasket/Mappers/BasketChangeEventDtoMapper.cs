using MireroTicket.Services.ShoppingBasket.Entities;
using MireroTicket.Services.ShoppingBasket.Models;

namespace MireroTicket.Services.ShoppingBasket.Mappers
{
    public static class BasketChangeEventDtoMapper
    {
        public static BasketChangeEventDto From(BasketChangeEvent entity)
        {
            return new BasketChangeEventDto
            {
                Id = entity.Id,
                EventId = entity.EventId,
                InsertedAt = entity.InsertedAt,
                UserId = entity.UserId,
                BasketChangeType = entity.BasetChangeType,
            };
        }
    }
}