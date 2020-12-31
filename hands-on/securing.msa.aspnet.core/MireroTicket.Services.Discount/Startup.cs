using System;
using System.Collections.Generic;
using System.Linq;
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
using MireroTicket.Services.Discount.DbContexts;
using MireroTicket.Utilities;

namespace MireroTicket.Services.Discount
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
            services.AddDbContext<DiscountContext>(builder =>
            {
                var connectionString = _configuration.GetSection("ConnectionStrings")?["DefaultConnection"];
                connectionString ??= "Data Source=\"discount.db\"";
                builder.UseSqlite(connectionString);
            });

            services.AddControllers();
            // services.AddControllers(options =>
            // {
            //     var authPolicy = new AuthorizationPolicyBuilder()
            //         .RequireAuthenticatedUser()
            //         .Build();
            //     options.Filters.Add(new AuthorizeFilter(authPolicy));
            // });
            //
            // services
            //     .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //     .AddJwtBearer(options =>
            //     {
            //         options.Authority = "https://localhost:5010"; // identity서비스 url
            //         options.Audience = Audiences.Discount;
            //     })
            //     ;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            // app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}