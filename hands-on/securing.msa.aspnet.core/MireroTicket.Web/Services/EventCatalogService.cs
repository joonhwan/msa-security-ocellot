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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _accessToken;

        public EventCatalogService(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
            _accessToken = null;
        }

        private async Task EnsureBearerToken()
        {
            // if (string.IsNullOrEmpty(_accessToken))
            // {
            //     var ddr = await _client.GetDiscoveryDocumentAsync("https://localhost:5010");
            //     if (ddr.IsError)
            //     {
            //         throw new Exception(ddr.Error);
            //     }
            //
            //     var tokenResponse = await _client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            //     {
            //         Address = ddr.TokenEndpoint,
            //         ClientId = ClientIds.EventCatalogReader,
            //         ClientSecret = "mireroticket.super.secrets",
            //         Scope = Scopes.EventCatalog.Read,
            //     });
            //     if (tokenResponse.IsError)
            //     {
            //         throw new Exception(tokenResponse.Error);
            //     }
            //
            //     _accessToken = tokenResponse.AccessToken;
            // }
            if (_accessToken == null)
            {
                _accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            }
            _client.SetBearerToken(_accessToken);
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            await EnsureBearerToken();
            
            var response = await _client.GetAsync("api/events");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<IEnumerable<Event>> GetByCategoryId(Guid categoryid)
        {
            await EnsureBearerToken();

            var response = await _client.GetAsync($"api/events/?categoryId={categoryid}");
            return await response.ReadContentAs<List<Event>>();
        }

        public async Task<Event> GetEvent(Guid id)
        {
            await EnsureBearerToken();

            var response = await _client.GetAsync($"api/events/{id}");
            return await response.ReadContentAs<Event>();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            await EnsureBearerToken();

            var response = await _client.GetAsync("api/categories");
            return await response.ReadContentAs<List<Category>>();
        }

    }
}
