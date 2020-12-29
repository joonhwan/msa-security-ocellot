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
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiResource> ApiResources
            => new ApiResource[]
            {
                // audience들 ?!
                new ApiResource("mireroticket.aud.all", "MireroTicket API Audience")
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
                    AllowedScopes = { "mireroticket.scope.all" }
                },
            };
    }
}