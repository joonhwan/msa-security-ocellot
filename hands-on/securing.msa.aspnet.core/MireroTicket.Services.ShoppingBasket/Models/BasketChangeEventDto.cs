using MireroTicket.Services.ShoppingBasket.Entities;

namespace MireroTicket.Services.ShoppingBasket.Models
{
    public class BasketChangeEventDto
    {
        public string Id { get; set;  }
        public string UserId { get; set; }
        public string EventId { get; set; }
        public string InsertedAt { get; set; }
        public BasketChangeTypeEnum BasketChangeType { get; set; }
    }
}