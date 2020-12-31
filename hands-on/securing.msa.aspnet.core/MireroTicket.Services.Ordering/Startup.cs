using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MireroTicket.Messages;
using MireroTicket.ServiceBus;
using MireroTicket.ServiceBus.RabbitMQ;
using MireroTicket.Services.Ordering.DbContexts;
using MireroTicket.Services.Ordering.MessageHandlers;
using MireroTicket.Services.Ordering.Messages;
using MireroTicket.Utilities;

namespace MireroTicket.Services.Ordering
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
            services.AddDbContext<OrderingDbContext>(builder =>
            {
                builder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
            });
            //services.AddTransient<IMediator, OrderingMediator>();
            services
                .AddScoped<IRequestHandler<BasketCheckoutMessage>, BasketCheckoutMessageHandler>()
                .AddMediatR(new[]
                {
                    typeof(Startup).Assembly,
                    typeof(CommandMessage).Assembly,
                })
                ;

            services.Configure<ServiceBusOptions>(_configuration.GetSection("ServiceBus"));
            services.AddRabbitServiceBus(builder =>
            {
                builder.AddConsumerService<BasketCheckoutMessage>();
            });
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            
            //app.UseMiddleware<RequestResponseLoggingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}