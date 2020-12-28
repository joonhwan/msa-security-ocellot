using System.ComponentModel.DataAnnotations;

namespace MireroTicket.Services.ShoppingBasket.Models
{
    public class BasketLineForUpdate
    {
        [Required]
        public int TicketAmount { get; set; }
    }
}