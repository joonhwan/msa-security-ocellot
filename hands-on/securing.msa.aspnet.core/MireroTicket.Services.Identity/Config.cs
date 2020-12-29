// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

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
                new ApiResource("mireroticket.aud.any", "MireroTicket API Audience")
                {
                    Scopes = {"mireroticket.scope.all" }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("mireroticket.scope.all", "MireroTicket Full Access Scope")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                {
                    ClientName = "MireroTicket M2M Client",
                    ClientId = "mireroticket.client.internal",
                    ClientSecrets =
                    {
                        new Secret(
                            "mireroticket.super.secrets".Sha256()
                        )
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials, // M2M 
                    AllowedScopes = {"mireroticket.scope.all"}
                },
                new Client()
                {
                    ClientName = "MireroTicket UI Client",
                    ClientId = "mireroticket.client.ui",
                    ClientSecrets =
                    {
                        new Secret(
                            "mireroticket.super.secrets".Sha256()
                        )
                    },
                    AllowedGrantTypes = GrantTypes.Code,
                    // Web Client 의 URL + "/signin-oidc"
                    // --> path는 Middleware(Microsoft.AspNetCore.Authentication.OpenIdConnect) 구현에 따름. 
                    RedirectUris = { "https://localhost:5000/signin-oidc" },
                    // Web Client 의 URL + "/signout-callback-oidc"
                    // --> path는 Middleware(Microsoft.AspNetCore.Authentication.OpenIdConnect) 구현에 따름.
                    PostLogoutRedirectUris = { "https://localhost:5000/signout-callback-oidc" },
                    AllowedScopes =
                    {
                        // 표준 scope
                        "openid",
                        "profile",
                        // 우리가 정의한 scope
                        "mireroticket.scope.all"
                    }
                },
                
            };
    }
}