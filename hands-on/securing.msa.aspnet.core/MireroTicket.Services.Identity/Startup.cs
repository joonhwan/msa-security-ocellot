// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MireroTicket.Services.Identity.Services;
using MireroTicket.Utilities;

namespace MireroTicket.Services.Identity
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var builder = services
                    .AddIdentityServer(options =>
                    {
                        options.Events.RaiseErrorEvents = true;
                        options.Events.RaiseInformationEvents = true;
                        options.Events.RaiseFailureEvents = true;
                        options.Events.RaiseSuccessEvents = true;

                        // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                        options.EmitStaticAudienceClaim = true;
                    })
                    // in-memory, code config
                    .AddInMemoryIdentityResources(Config.IdentityResources)
                    .AddInMemoryApiResources(Config.ApiResources)
                    .AddInMemoryApiScopes(Config.ApiScopes)
                    .AddInMemoryClients(Config.Clients)
                    // Identity에 기본으로 없지만, 필요에 의해서 새로 추가한 Grant 처리 (ex: Token Exchange)
                    // --> 물론, 이것은 표준안으로 잡혀있는거면 좋겠지.
                    .AddExtensionGrantValidator<TokenExchangeExtensionGrantValidator>()
                    // 사용자 정보를 어떻게 가져올 것인가.
                    // IProfileService 에 대한 DI.
                    .AddTestUsers(TestUsers.Users)  // IdentityServer4 가 편이를 위해 제공하는 개발전용 In-memory User Store.
                ;

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential(); // 'tempkey.jwk' 파일을 가지고..signing
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            
            //app.UseMiddleware<RequestResponseLoggingMiddleware>();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}