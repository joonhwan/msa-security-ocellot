using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MireroTicket.Services.ShoppingBasket.Entities
{
    public class Basket
    {
        public string Id { get; set; }
        [Required]
        public string UserId { get; set; }
        
        public List<BasketLine> BasketLines { get; set; }
    }
}