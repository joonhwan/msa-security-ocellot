using System.ComponentModel.DataAnnotations;

namespace MireroTicket.Services.ShoppingBasket.Entities
{
    public class BasketLine
    {
        public string Id { get; set; }
        
        [Required]
        public string BasketId { get; set; }

        [Required]
        public string EventId { get; set; }
        
        [Required]
        public int TicketAmount { get; set; }

        [Required]
        public int Price { get; set; }

        // Mapped 객체들. 
        // public Basket Basket { get; set; }
        public Event Event { get; set; }
    }
}