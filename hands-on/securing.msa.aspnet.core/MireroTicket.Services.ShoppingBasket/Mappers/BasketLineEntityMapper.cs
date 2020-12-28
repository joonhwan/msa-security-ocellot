using MireroTicket.Services.ShoppingBasket.Entities;
using MireroTicket.Services.ShoppingBasket.Models;

namespace MireroTicket.Services.ShoppingBasket.Mappers
{
    public static class BasketLineEntityMapper
    {
        public static BasketLine From(string basketId, BasketLineForCreation basketLineForCreation)
        {
            return new BasketLine
            {
                Id = null,
                BasketId = basketId,
                Price = basketLineForCreation.Price,
                EventId = basketLineForCreation.EventId,
                TicketAmount = basketLineForCreation.TicketAmount
            };
        }
    }
}