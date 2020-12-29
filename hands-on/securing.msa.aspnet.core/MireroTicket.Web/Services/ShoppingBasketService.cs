using MireroTicket.Web.Extensions;
using MireroTicket.Web.Models;
using MireroTicket.Web.Models.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MireroTicket.Utilities;

namespace MireroTicket.Web.Services
{
    public class ShoppingBasketService : IShoppingBasketService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContext;

        public ShoppingBasketService(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContext = httpContextAccessor;
        }

        public async Task<BasketLine> AddToBasket(Guid basketId, BasketLineForCreation basketLine)
        {
            if (basketId == Guid.Empty)
            {
                _httpContext.HttpContext.User.TryGetClaim(ClaimTypes.NameIdentifier, out Guid userId);
                var basketResponse = await _client.PostAsJson("/api/baskets", new BasketForCreation { UserId = userId });
                var basket = await basketResponse.ReadContentAs<Basket>();
                basketId = basket.BasketId;
            }

            var response = await _client.PostAsJson($"api/baskets/{basketId}/basketlines", basketLine);
            return await response.ReadContentAs<BasketLine>();
        }

        public async Task<Basket> GetBasket(Guid basketId)
        {
            if (basketId == Guid.Empty)
                return null;
            var response = await _client.GetAsync($"/api/baskets/{basketId}");
            return await response.ReadContentAs<Basket>();
        }

        public async Task<IEnumerable<BasketLine>> GetLinesForBasket(Guid basketId)
        {
            if (basketId == Guid.Empty)
                return new BasketLine[0];
            var response = await _client.GetAsync($"/api/baskets/{basketId}/basketLines");
            return await response.ReadContentAs<BasketLine[]>();

        }

        public async Task UpdateLine(Guid basketId, BasketLineForUpdate basketLineForUpdate)
        {
            await _client.PutAsJson($"/api/baskets/{basketId}/basketLines/{basketLineForUpdate.LineId}", basketLineForUpdate);
        }

        public async Task RemoveLine(Guid basketId, Guid lineId)
        {
            await _client.DeleteAsync($"/api/baskets/{basketId}/basketLines/{lineId}");
        }

        public async Task<BasketForCheckout> Checkout(Guid basketId, BasketForCheckout basketForCheckout)
        {
            var response = await _client.PostAsJson($"api/baskets/checkout", basketForCheckout);
            if(response.IsSuccessStatusCode)
                return await response.ReadContentAs<BasketForCheckout>();
            else
            {
                throw new Exception("Something went wrong placing your order. Please try again.");
            }
        }
    }
}
