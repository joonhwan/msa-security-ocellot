using System.ComponentModel.DataAnnotations;

namespace MireroTicket.Services.ShoppingBasket.Models
{
    public class BasketForCreation
    {
        [Required]
        public string UserId { get; set; }
    }

    public class BasketCheckout
    {
        public string BasketId { get; set; }
        
        // user
        // public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        
        // payment
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpiration { get; set; }
        public string CvvCode { get; set; }
    }
}