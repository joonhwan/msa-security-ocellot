using System.Linq;
using MireroTicket.Services.ShoppingBasket.Entities;
using MireroTicket.Services.ShoppingBasket.Models;

namespace MireroTicket.Services.ShoppingBasket.Mappers
{
    public static class BasketDtoMapper
    {
        public static BasketDto From(Basket entity)
        {
            var itemCount = entity.BasketLines.Sum(line => line.TicketAmount);
            return new BasketDto()
            {
                BasketId = entity.Id,
                UserId = entity.UserId,
                CouponId = null,
                ItemCount = itemCount,
            };
        }
    }
}