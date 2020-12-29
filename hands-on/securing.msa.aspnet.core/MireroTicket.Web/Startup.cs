using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MireroTicket.Web.Models;
using MireroTicket.Web.Services;

namespace MireroTicket.Web
{
    public class Startup
    {
        private readonly IHostEnvironment environment;
        private readonly IConfiguration config;

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            config = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {   
            var authPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    //.RequireClaim("role", "admin", "poweruser")
                    .Build()
                ;

            var builder = services.AddControllersWithViews(options =>
            {
                // [Authorize] globally.
                options.Filters.Add(new AuthorizeFilter(authPolicy));
            });

            if (environment.IsDevelopment())
                builder.AddRazorRuntimeCompilation();

            services.AddHttpContextAccessor();
            services.AddHttpClient<IEventCatalogService, EventCatalogService>(c => 
                c.BaseAddress = new Uri(config["ApiConfigs:EventCatalog:Uri"]));
            services.AddHttpClient<IShoppingBasketService, ShoppingBasketService>(c => 
                c.BaseAddress = new Uri(config["ApiConfigs:ShoppingBasket:Uri"]));
            services.AddHttpClient<IOrderService, OrderService>(c =>
                c.BaseAddress = new Uri(config["ApiConfigs:Order:Uri"]));
        
            services.AddSingleton<Settings>();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; // "Cookies"
                    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme; // "OpenIdConnect" 
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.Authority = "https://localhost:5010";
                    options.ClientId = "mireroticket.client.ui";
                    options.ClientSecret = "mireroticket.super.secrets";
                    options.ResponseType = "code";
                    options.SaveTokens = true;
                    // 아래를 true로 활성화하면 id_token 을 수신한 다음,
                    //    https://.../user 주소로 가서 추가 claim 들을 가져온다.
                    options.GetClaimsFromUserInfoEndpoint = true; 
                    // 기본 "openid", "profile" 말고, 추가로 필요한 scope들
                    // -->  MVC Web Client 가 Auth정보로 각 개별 서비스에 직접 접근할 수 있게 하기 위함
                    options.Scope.Add("mireroticket.scope.all");
                })
                ;
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=EventCatalog}/{action=Index}/{id?}");
            });
        }
    }
}