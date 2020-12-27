using MireroTicket.Services.EventCatalog.Entities;
using MireroTicket.Services.EventCatalog.Models;

namespace MireroTicket.Services.EventCatalog.Mappers
{
    public static class EventMapper
    {
        public static EventDto From(Event e)
        {
            if (e == null) return null;
            
            return new EventDto
            {
                Artist = e.Artist,
                Date = e.Date,
                Description = e.Description,
                Name = e.Name,
                Price = e.Price,
                CategoryId = e.CategoryId,
                CategoryName = e.Category?.Name ?? "{n/a}",
                EventId = e.EventId,
                ImageUrl = e.ImageUrl,
            };
        }
    }
}