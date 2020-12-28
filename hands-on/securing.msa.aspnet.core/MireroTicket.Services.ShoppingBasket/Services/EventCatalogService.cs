using System.Net.Http;
using System.Threading.Tasks;
using MireroTicket.Services.Common;
using MireroTicket.Services.ShoppingBasket.Entities;

namespace MireroTicket.Services.ShoppingBasket.Services
{
    public class EventCatalogService
    {
        private readonly HttpClient _client;

        public EventCatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Event> GetEvent(string eventId)
        {
            var response = await _client.GetAsync($"/api/events/{eventId}");
            var eventResponse = await response.ReadContentAs<EventResponse>();
            return new Event
            {
                Date = eventResponse.Date,
                Id = eventResponse.EventId,
                Name = eventResponse.Name,
            };
        }

        private class EventResponse
        {
            public string EventId { get; set; }
            public string Name { get; set; }
            public string Date { get; set; }
        }
    }
    
}