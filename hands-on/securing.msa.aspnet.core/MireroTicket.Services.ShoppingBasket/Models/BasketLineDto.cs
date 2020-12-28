namespace MireroTicket.Services.ShoppingBasket.Models
{
    public class BasketLineDto
    {
        public string BasketLineId { get; set; }
        public string BasketId { get; set; }
        public int TicketAmount { get; set; }
        public int Price { get; set; }
        public EventDto Event { get; set; }
    }
}