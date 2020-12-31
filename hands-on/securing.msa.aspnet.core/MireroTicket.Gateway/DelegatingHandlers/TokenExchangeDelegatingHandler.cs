using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using MireroTicket.Utilities;

namespace MireroTicket.Gateway.DelegatingHandlers
{
    public class TokenExchangeDelegatingHandler : DelegatingHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IClientAccessTokenCache _tokenCache;

        public TokenExchangeDelegatingHandler(IHttpClientFactory httpClientFactory, IClientAccessTokenCache tokenCache)
        {
            _httpClientFactory = httpClientFactory;
            _tokenCache = tokenCache;
        }
        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // 현재 토큰을 꺼내온다음 
            var incomingAccessToken = request.Headers.Authorization.Parameter;
            
            // --> Cache된게 없거나 기존토큰이 expire되면 새로운 토큰을 발급. 
            var ensuredAccessToken = await EnsureGetAccessTokenAsync(incomingAccessToken);
            
            // 현재 토큰을 새 토큰으로 교체.
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ensuredAccessToken);
             
            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<string> EnsureGetAccessTokenAsync(string incomingToken)
        {
            var clientAccessToken = await _tokenCache.GetAsync(ClientIds.GatewayDownstreamTokenExchanger);
            if (clientAccessToken != null)
            {
                return clientAccessToken.AccessToken;
            }
            
            // 현재 expire되지 않은 유효한 토큰이 없다. 새로 발급받아야 한다. 
            
            var tokenResponse = await ExchangeToken(incomingToken);

            await _tokenCache.SetAsync(
                ClientIds.GatewayDownstreamTokenExchanger,
                tokenResponse.AccessToken,
                tokenResponse.ExpiresIn
            );

            return tokenResponse.AccessToken;
        }

        private async Task<TokenResponse> ExchangeToken(string incomingToken)
        {
            var client = _httpClientFactory.CreateClient();
            
            var ddr = await client.GetDiscoveryDocumentAsync("https://localhost:5010");
            if (ddr.IsError)
            {
                throw new ApplicationException(ddr.Error);
            }

            var accessToken = incomingToken;
            var scopes = string.Join(" ", new[]
            {
                Scopes.OpenId,
                Scopes.Profile,
                Scopes.EventCatalog.Read,
                Scopes.EventCatalog.Write,
            });
            var tokenExchangeParams = new Dictionary<string, string>
            {
                {"subject_token_type", "urn:ietf:params:oauth:token-type:access_token"},
                {"subject_token", accessToken},
                {"scope", scopes}
            };
            
            var tokenResponse = await client.RequestTokenAsync(new TokenRequest()
            {
                Address = ddr.TokenEndpoint,
                GrantType = "urn:ietf:params:oauth:grant-type:token-exchange",
                Parameters = tokenExchangeParams,
                ClientId = ClientIds.GatewayDownstreamTokenExchanger,
                ClientSecret = "i am a gateway. give me new token!!!",
            });
            
            if (tokenResponse.IsError)
            {
                throw new ApplicationException(tokenResponse.Error);
            }
            
            return tokenResponse;
        }
    }
}