namespace MireroTicket.Services.ShoppingBasket.Messages
{
    public class BasketLineMessage
    {
        public string BasketLineId { get; set; }
        public int Price { get; set; }
        public int TicketAmount { get; set; }
    }
}