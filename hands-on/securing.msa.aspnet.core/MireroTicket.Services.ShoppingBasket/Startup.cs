using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MireroTicket.ServiceBus;
using MireroTicket.Services.ShoppingBasket.DbContexts;
using MireroTicket.Services.ShoppingBasket.Messages;
using MireroTicket.Services.ShoppingBasket.Services;
using MireroTicket.Utilities;
using Polly;
using Polly.Extensions.Http;

namespace MireroTicket.Services.ShoppingBasket
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            
            services.AddDbContext<ShoppingBasketDbContext>(builder =>
            {
                builder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
            });

            services.Configure<ServiceBusOptions>(_configuration.GetSection("ServiceBus"));
            services
                .AddRabbitServiceBus(builder =>
                {
                    builder.AddProducer<BasketCheckoutMessage>();
                });

            services
                .AddHttpClient<EventCatalogService>(c =>
                    c.BaseAddress = new Uri(_configuration["ApiConfigs:EventCatalog:Uri"]))
                ;
                
            services
                .AddHttpClient<DiscountService>(client =>
                    client.BaseAddress = new Uri(_configuration["ApiConfigs:Discount:Uri"]))
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy())
                ;

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://localhost:5010";
                    options.Audience = Audiences.ShoppingBasket;
                })
                ;

            services.AddControllers(options =>
            {
                var authPolicy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build()
                    ;
                options.Filters.Add(new AuthorizeFilter(authPolicy));
            });
        }

        private IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .WaitAndRetryAsync(
                        5,
                        retry => TimeSpan.FromMilliseconds(Math.Pow(1.5, retry) * 1000),
                        (_, waitingTime) => { Console.WriteLine("Retrying due to Polly retry policy"); })
                ;
        }

        private IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                    .HandleTransientHttpError()
                    .CircuitBreakerAsync(
                        3,
                        TimeSpan.FromSeconds(15)
                    )
                ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}