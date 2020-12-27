using System;
using System.ComponentModel.DataAnnotations;

namespace MireroTicket.Services.EventCatalog.Entities
{
    public class Event
    {
        [Required]
        public string EventId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}