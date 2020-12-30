using System;

namespace MireroTicket.Web.Models.Api
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Total { get; set; }
        public DateTime PlacedTime { get; set; }
        public bool Paid { get; set; }
    }
}
