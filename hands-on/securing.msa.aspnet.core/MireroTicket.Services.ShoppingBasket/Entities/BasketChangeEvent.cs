using System;

namespace MireroTicket.Services.ShoppingBasket.Entities
{
    public class BasketChangeEvent
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string EventId { get; set; }
        public string InsertedAt { get; set; }
        public BasketChangeTypeEnum BasetChangeType { get; set; }
    }

    public enum BasketChangeTypeEnum
    {
        Add,
        Remove
    }
}