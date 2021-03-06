using MireroTicket.Messages;
using MireroTicket.ServiceBus.Attributes;

namespace MireroTicket.Services.Ordering.Messages
{
    // ReSharper disable once ClassNeverInstantiated.Global
    [Alias("BasketCheckoutMessage")]
    public class BasketCheckoutMessage : CommandMessage // NotificationMessage인가?
    {
        public string UserId { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpiration { get; set; }
        
        public int BasketTotal { get; set; }
    }
}