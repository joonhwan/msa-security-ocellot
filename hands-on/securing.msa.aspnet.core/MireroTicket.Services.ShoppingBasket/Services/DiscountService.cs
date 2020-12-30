using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using MireroTicket.Services.Common;
using MireroTicket.Services.ShoppingBasket.Models;
using MireroTicket.Utilities;

namespace MireroTicket.Services.ShoppingBasket.Services
{
    public class DiscountService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string _accessToken;

        public DiscountService(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
            _accessToken = null;
        }

        public async Task<Coupon> GetCouponAsync(string userId)
        {
            await EnsureBearerToken();
            
            var response = await _client.GetAsync($"/api/discount/user/{userId}");
            
            // Coupon 이 없다고 오류는 아님. 없을 수도 있음. 
            //  --> ReadContentAs<T>() 는 잘못된 response에 대해서 throw하기 때문에, 여기서 오류처리.
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(response.ReasonPhrase);
            }
            
            return await response.ReadContentAs<Coupon>();
        }

        private async Task EnsureBearerToken()
        {
            if (string.IsNullOrEmpty(_accessToken))
            {
                var ddr = await _client.GetDiscoveryDocumentAsync("https://localhost:5010");
                if (ddr.IsError)
                {
                    throw new ApplicationException(ddr.Error);
                }

                var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
                var scopes = string.Join(" ", new[]
                {
                    Scopes.OpenId,
                    Scopes.Profile,
                    Scopes.Discount.All
                });
                var tokenExchangeParams = new Dictionary<string, string>
                {
                    {"subject_token_type", "urn:ietf:params:oauth:token-type:access_token"},
                    {"subject_token", accessToken},
                    {"scope", scopes}
                };

                var tokenResponse = await _client.RequestTokenAsync(new TokenRequest()
                {
                    Address = ddr.TokenEndpoint,
                    GrantType = "urn:ietf:params:oauth:grant-type:token-exchange",
                    Parameters = tokenExchangeParams,
                    ClientId = ClientIds.ShoppingBasketToDiscount,
                    ClientSecret = "i am going to use discount!!!",
                });

                if (tokenResponse.IsError)
                {
                    throw new ApplicationException(tokenResponse.Error);
                }

                _accessToken = tokenResponse.AccessToken;
            }
            _client.SetBearerToken(_accessToken);
        }
    }
}