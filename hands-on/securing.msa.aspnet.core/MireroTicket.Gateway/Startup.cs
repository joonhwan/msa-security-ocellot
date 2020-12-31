using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MireroTicket.Gateway.DelegatingHandlers;
using MireroTicket.Utilities;
using Ocelot.Authorisation;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace MireroTicket.Gateway
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // sub <= http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); 
            
            var authenticationScheme = "mireroticket.gateway.authentication.scheme";
            services
                .AddAuthentication()
                .AddJwtBearer(authenticationScheme, options =>
                {
                    options.Authority = "https://localhost:5010";
                    options.Audience = Audiences.Gateway;
                })
                ;
            
            services.AddHttpClient();
            services.AddScoped<TokenExchangeDelegatingHandler>(); // 강의에서는 이걸 했는데...   :-( 

            services
                .AddOcelot()
                .AddDelegatingHandler<TokenExchangeDelegatingHandler>()
                ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMiddleware<RequestResponseLoggingMiddleware>();
            
            app.UseOcelot().Wait();
        }
    }
}