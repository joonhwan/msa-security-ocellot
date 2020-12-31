// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using MireroTicket.Utilities;

namespace MireroTicket.Services.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(), // "openid"
                new IdentityResources.Profile(), // "profile"
            };

        public static IEnumerable<ApiResource> ApiResources
            => new ApiResource[]
            {
                // audience들 ?!
                // new ApiResource("mireroticket.aud.any", "MireroTicket API Audience")
                // {
                //     Scopes = {"mireroticket.scope.all" }
                // },
                new ApiResource(Audiences.EventCatalog, "MireroTicket EventCatalog API")
                {
                    Scopes =
                    {
                        Scopes.EventCatalog.Read,
                        Scopes.EventCatalog.Write,
                    }
                },
                new ApiResource(Audiences.ShoppingBasket, "MireroTicket ShoppingCatalog API")
                {
                    Scopes =
                    {
                        Scopes.ShoppingBasket.All,
                    }
                },
                new ApiResource(Audiences.Discount, "MireroTicket Discount API")
                {
                    Scopes =
                    {
                        Scopes.Discount.All,
                    }
                },
                new ApiResource(Audiences.Gateway, "MireroTicket Gateway API")
                {
                    Scopes =
                    {
                        Scopes.Gateway.All,
                    }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                // all 같은 것은 있으면 오히려 불편.... 
                //new ApiScope("mireroticket.scope.all", "MireroTicket Full Access Scope"),

                // event-catalog.all 같은건 필요없음. read/write 조합으로 가능. 있으면 오히려 불편(AuthorizationPolicy 구성시 괜히 1개 더 추가해야 함)
                new ApiScope(Scopes.EventCatalog.Read),
                new ApiScope(Scopes.EventCatalog.Write),
                // read/write 으로 쪼갤 필요가 없는것들은 그냥 하나로 퉁 치면 됨. 
                new ApiScope(Scopes.ShoppingBasket.All),
                new ApiScope(Scopes.Discount.All),
                new ApiScope(Scopes.Gateway.All)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                {
                    ClientName = "MireroTicket Event Catalog Reader Client",
                    ClientId = ClientIds.EventCatalogReader,
                    ClientSecrets =
                    {
                        new Secret(
                            "mireroticket.super.secrets".Sha256()
                        )
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials, // M2M 
                    AllowedScopes =
                    {
                        Scopes.EventCatalog.Read,
                    }
                },
                new Client()
                {
                    ClientName = "MireroTicket UI Client",
                    ClientId = ClientIds.MvcClient,
                    ClientSecrets =
                    {
                        new Secret(
                            "mireroticket.super.secrets".Sha256()
                        )
                    },
                    AllowedGrantTypes = GrantTypes.Code,
                    // Web Client 의 URL + "/signin-oidc"
                    // --> path는 Middleware(Microsoft.AspNetCore.Authentication.OpenIdConnect) 구현에 따름. 
                    RedirectUris = {"https://localhost:5000/signin-oidc"},
                    // Web Client 의 URL + "/signout-callback-oidc"
                    // --> path는 Middleware(Microsoft.AspNetCore.Authentication.OpenIdConnect) 구현에 따름.
                    PostLogoutRedirectUris = {"https://localhost:5000/signout-callback-oidc"},
                    AllowedScopes =
                    {
                        // 표준 scope
                        Scopes.OpenId,
                        Scopes.Profile,
                        // 우리가 정의한 scope
                        Scopes.ShoppingBasket.All,
                        // Scopes.EventCatalog.Read,
                        // Scopes.EventCatalog.Write
                        
                    },
                },
                new Client()
                {
                    ClientName = "MireroTicket General Client",
                    ClientId = ClientIds.GeneralClient,
                    ClientSecrets =
                    {
                        new Secret(
                            "mireroticket.super.secrets".Sha256()
                        )
                    },
                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    RedirectUris = {"https://localhost:5000/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:5000/signout-callback-oidc"},
                    AllowedScopes =
                    {
                        Scopes.OpenId,
                        Scopes.Profile,
                        Scopes.ShoppingBasket.All,
                        // Scopes.EventCatalog.Read,
                        // Scopes.EventCatalog.Write,
                        Scopes.Gateway.All,
                        // 클라이언트 임의로 할인쿠폰을 막 발행할 수 는 없다!!!
                        // Scopes.Discount.All, 
                    },
                    RequireConsent = false, // false가 기본값
                },
                
                new Client()
                {
                    ClientName = "MireroTicket `DiscountService` in ShoppingBasket Service",
                    ClientId = ClientIds.ShoppingBasketToDiscount,
                    ClientSecrets = { new Secret("i am going to use discount!!!".Sha256()) } ,
                    AllowedGrantTypes =  new[] { "urn:ietf:params:oauth:grant-type:token-exchange" },
                    AllowedScopes =
                    {
                        Scopes.OpenId, 
                        Scopes.Profile, 
                        Scopes.Discount.All
                    }
                },
                // Gateway 의  Upstream에서 수신한 Token으로 Downstream쪽에 대한 Token으로 변환하는 서비스를 위함. 
                new Client()
                {
                    ClientName = "MireroTicket TokenExchanger Service for API Gateway",
                    ClientId = ClientIds.GatewayDownstreamTokenExchanger,
                    ClientSecrets ={ new Secret("i am a gateway. give me new token!!!".Sha256()) },
                    AllowedGrantTypes =  new[] { "urn:ietf:params:oauth:grant-type:token-exchange" },
                    AllowedScopes =
                    {
                        Scopes.OpenId,
                        Scopes.Profile,
                        Scopes.EventCatalog.Read,
                        Scopes.EventCatalog.Write,
                    }
                }
            };

    }

}