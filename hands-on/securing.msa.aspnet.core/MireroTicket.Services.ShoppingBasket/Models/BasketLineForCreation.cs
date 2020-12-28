using System.ComponentModel.DataAnnotations;

namespace MireroTicket.Services.ShoppingBasket.Models
{
    public class BasketLineForCreation
    {
        [Required]
        public string EventId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int TicketAmount { get; set; }
    }
}