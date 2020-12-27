namespace MireroTicket.Services.Ordering.Entities
{
    public class Order
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int Total { get; set; }
        public string PlacedTime { get; set; }
        public bool Paid { get; set; }
    }
}