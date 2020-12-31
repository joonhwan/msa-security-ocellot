using MireroTicket.Web.Extensions;
using MireroTicket.Web.Models.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using MireroTicket.Utilities;

namespace MireroTicket.Web.Services
{
    public class EventCatalogService : IEventCatalogService
    {
        private readonly HttpClient _client;
        
        public EventCatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            var response = await _client.GetAsync("api/events");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<IEnumerable<Event>> GetByCategoryId(Guid categoryid)
        {
            var response = await _client.GetAsync($"api/events/?categoryId={categoryid}");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<Event> GetEvent(Guid id)
        {
            var response = await _client.GetAsync($"api/events/{id}");
            return await response.ReadContentAs<Event>();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var response = await _client.GetAsync("api/categories");
            return await response.ReadContentAs<List<Category>>();
        }

    }
}
