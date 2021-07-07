using Autodoc.SeoAdmin.API.Filters;
using Autodoc.SeoAdmin.Application;
using Autodoc.SeoAdmin.Infrastructure;
using FluentValidation.AspNetCore;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Autodoc.SeoAdmin.API
{
    public class Startup
    {
        public Startup (IWebHostEnvironment environment, IConfiguration configuration)
        {
            Configuration = configuration;
            CurrentEnvironment = environment;
        }

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment CurrentEnvironment { get; set; }

        public void ConfigureServices (IServiceCollection services)
        {
            services.AddCors();

            services.AddApplication();
            services.AddInfrastructure(Configuration);
            ConfigureAuthentication(services);

            services.AddControllersWithViews(options => options.Filters.Add<ApiExceptionFilterAttribute>()).AddFluentValidation();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseStaticFiles();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureAuthentication (IServiceCollection services)
        {
            services.AddAuthentication(
            o =>
            {
                o.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
            {
                option.Audience = this.Configuration.GetSection("AppSettings").GetValue<string>("ApiName");
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidIssuer = this.Configuration.GetSection("AppSettings").GetValue<string>("AuthorityUrl"),
                    IssuerSigningKey = new X509SecurityKey(new X509Certificate2(Path.Combine(this.CurrentEnvironment.ContentRootPath, "AutodocAuth.cer"), "Autodoc1!")),
                };
            }
            );
        }
    }
}
