namespace MireroTicket.Services.EventCatalog.Models
{
    public class EventDto
    {
        public string EventId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        // linked category
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}