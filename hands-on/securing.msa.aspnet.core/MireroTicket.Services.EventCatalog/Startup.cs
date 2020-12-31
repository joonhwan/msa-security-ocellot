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
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MireroTicket.Services.EventCatalog.DbContexts;
using MireroTicket.Utilities;

namespace MireroTicket.Services.EventCatalog
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EventCatalogContext>(builder =>
            {
                var connectionString = _config.GetSection("ConnectionString")?["DefaultConnection"];
                connectionString ??= "Data Source=\"event.catalog.db\"";
                builder.UseSqlite(connectionString);
            });

            // services.AddControllers();
            // // NOT services.AddControllersWithViews()
            services.AddControllers(options =>
            {
                var authPolicy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build()
                    ;
                options.Filters.Add(new AuthorizeFilter(authPolicy));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanRead", builder =>
                {
                    builder.RequireClaim("scope", new []{
                        Scopes.EventCatalog.Read, 
                    });
                });
                options.AddPolicy("CanWrite", builder =>
                {
                    builder.RequireClaim("scope", new[]
                    {
                        Scopes.EventCatalog.Write,
                    });
                });
            });
            
            services
                // @WebApiAuth
                //
                // Web API 서비스가 M2M(Client Credential Flow)를 사용하여 Access Token을 스스로 얻어올 예정이므로,
                // Authentication 이 필요해진다. 
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://localhost:5010"; // identity서비스 url
                    options.Audience = Audiences.EventCatalog;
                })
                ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //  Routing -> Authentication -> Authorziation 의 순서가 중요하다.
            app.UseRouting();
            app.UseAuthentication(); // see @WebApiAuth
            app.UseAuthorization();
            
            //app.UseMiddleware<RequestResponseLoggingMiddleware>();
            
            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
                endpoints.MapControllers();
            });
        }
    }
}