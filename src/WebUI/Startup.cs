using GlassZebra.Application;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Infrastructure;
using GlassZebra.Infrastructure.Persistence;
using GlassZebra.WebUI.Filters;
using GlassZebra.WebUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;
using System.Reflection;
using GlassZebra.WebUI.Hubs;
using Microsoft.AspNetCore.Cors.Infrastructure;
using MediatR;

namespace GlassZebra.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();

            services.AddControllersWithViews(options => 
                options.Filters.Add(new ApiExceptionFilter()));

            services.AddRazorPages();
            services.AddSignalR(c =>
            {
                
            });

            services.AddCors(cors =>
            {
	            cors.AddPolicy("AllowMyOrigin",
		            builder => builder
			            //.AllowAnyOrigin()
                        .WithOrigins("http://localhost:8080")
                        .AllowAnyMethod()
			            .AllowAnyHeader()
			            .AllowCredentials()
		            );
            });

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/dist";
            //});

            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "GlassZebra API";
                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                //app.UseSpaStaticFiles();
            }

            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
                settings.DocumentPath = "/api/specification.json";
            });

            app.UseRouting();

            app.UseCors("AllowMyOrigin");
            //app.UseCors(c => c
	           // .AllowAnyOrigin()
	           // //.WithOrigins("http://localhost:8081")
	           // .AllowAnyMethod());

            
            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<GameHub>("/gameHub", c =>
                {
                    
                });
            });

            //app.UseSpa(spa =>
            //{
	           // spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
	           //     //spa.UseVueDevelopmentServer();
            //    }
            //});
        }
    }
}
