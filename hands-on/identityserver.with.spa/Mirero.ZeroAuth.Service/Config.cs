// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Mirero.ZeroAuth.Service
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256())},

                    AllowedScopes = {"scope1"}
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = {new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256())},

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = {"https://localhost:44300/signin-oidc"},
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = {"https://localhost:44300/signout-callback-oidc"},

                    AllowOfflineAccess = true,
                    AllowedScopes = {"openid", "profile", "scope2"}
                },
                
                // SPA 를 위한 Implicit Flow 라고 했는데.. 나중에 보니까 아니네. 
                new Client()
                {
                    ClientId = "mirero.secured.app",
                
                    // 원래 client secret 이 있으면 좋지만, SPA의 경우, javascript 코드에 
                    // 박힐 수 밖에 읍다. 따라서 여기에서는 그냥 client secret 없이 하는 거 같다. ?
                    // --> 말이 되나?  
                    // ClientSecrets = { new Secret("very_secret_key_of_web_app".ToSha256()) },
                    RequireClientSecret = false,
                
                    AllowedGrantTypes = GrantTypes.Implicit,
                    // 인증서버가 로그인을 역으로 알려줄 수 있는 웹앱의 사이트주소(잠깐동안 스쳐가는 페이지.)
                    RedirectUris = {"https://localhost:7000/signin"},
                    AllowedScopes =
                    {
                        // see @Scope.Names 참고
                        "openid",
                        "profile"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://localhost:7000"
                    },
                
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    //AccessTokenLifetime = 5, // 테스트를 위해 30초만. (디폴트는 3600초=1시간)
                },
                // 
                new Client {
                    ClientId = "mirero.secured.spa",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,

                    RedirectUris = { "http://localhost:4200" },
                    PostLogoutRedirectUris = { "http://localhost:4200" },
                    AllowedCorsOrigins = { "http://localhost:4200" },

                    AllowedScopes = { "openid", "profile" },

                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                }
            };
    }
}