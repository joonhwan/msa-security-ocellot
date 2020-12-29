using System.Collections.Generic;
using MireroTicket.Messages;
using MireroTicket.ServiceBus.Attributes;

namespace MireroTicket.Services.ShoppingBasket.Messages
{
    [Alias("BasketCheckoutMessage")]
    public class BasketCheckoutMessage : CommandMessage
    {
        public string BasketId { get; set; }
        
        // user
        public string UserId { get; set; }
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
        
        public List<BasketLineMessage> BasketLines { get; set; }
        public int BasketTotal { get; set; }
    }
}