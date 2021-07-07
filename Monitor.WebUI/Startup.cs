using MediatR;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monitor.Application.Interfaces;
using Monitor.Application.MonitoringChecks.Decorators;
using Monitor.Infrastructure.Http;
using Monitor.Infrastructure.Scheduler;
using Monitor.Infrastructure.Selenium;
using Monitor.Infrastructure.SignalR;
using Monitor.Infrastructure.Processors;
using Monitor.Persistence.Repository;
using System.Reflection;
using Monitor.Infrastructure.Registrator;
using Monitor.Infrastructure.Logger;
using Monitor.Infrastructure.Telegram;
using Monitor.Application.MonitoringChecks.ResultsHandlingLogic;
using Monitor.Infrastructure.Settings;
using System;
using AutoMapper;
using Monitor.Infrastructure.Mappings;
using Monitor.Infrastructure.ExternalUnitTests;
using Monitor.Infrastructure.Notifications;
using Monitor.Application.MonitoringChecks.Commands;
using Monitor.Dashboard.Monitoring.QueryHandlers;
using Monitor.Dashboard.Config;
using Monitor.WebUI.Extentions;
using Microsoft.AspNetCore.Identity;
using Monitor.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using IdentityServer4.AccessTokenValidation;
using Monitor.Dashboard.Settings;
using Monitor.Persistence.Dashboard;
using Monitor.Dashboard.Mappings;
using Monitor.Dashboard.Dashboard.Decorators;
using FluentValidation.AspNetCore;
using Monitor.Dashboard.Dashboard.Commands.SaveSalesTarget;
using Monitor.Dashboard.Scheduling.Config;
using FluentScheduler;
using Monitor.Dashboard.Scheduling;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Dashboard.Dashboard.Services;

namespace Monitor.WebUI
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
            CurrentEnvironment = env;
        }

        public IConfiguration Configuration { get; }
        public Microsoft.Extensions.Hosting.IHostingEnvironment CurrentEnvironment { get; private set; }


        //TODO: configure Lamar "WithDefaultConventions" to remove unneeded registrations 
        public void ConfigureContainer(ServiceRegistry services)
        {
            services.AddSignalR();
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SaveSalesTargetValidator>());

            services.Scan(s =>
            {
                //s.TheCallingAssembly();
                //s.WithDefaultConventions();
                s.AssemblyContainingType(typeof(HomePageCheckHandler));
                s.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                s.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
            });

            services.AddSingleton<ICommandsProcessor, CommandsProcessor>();
            services.AddSingleton<ISchedulerService, SchedulerService>();
            services.AddSingleton<IChecksRepository, MemoryCheckRepository>();
            services.AddSingleton<IScheduleRepository, MemoryScheduleRepository>();
            services.AddSingleton<IHostedService, CheckRegistrator>();
            services.AddSingleton<ILoggerService, TextLoggerService>();
            services.AddSingleton<ILogStashService, LogStashService>();
            services.AddSingleton<IHttpRequestService, HttpRequestService>();
            services.AddSingleton<INotificationsService, NotificationsService>();

            services.AddTransient<ISignalRNotificationsService, SignalRNotificationsService>();
            services.AddTransient<IResultHandlingService, ResultHandlingService>();
            services.AddTransient<IUnitTestsProcessorService, UnitTestsProcessorService>();
            services.AddTransient<IWebDriversFactory, SeleniumDriversFactory>();
            services.AddTransient<ITelegramNotificationService, TelegramService>();
            services.AddTransient<ILostCallRateService, LostCallRateService>();

            services.AddMediatR(typeof(HomePageCheckHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetSessionVisitQueryHandler).GetTypeInfo().Assembly);

            services.AddSingleton<IFeedService, FeedService>();
            //Monitor Pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggerDecorator<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandResultHandleDecorator<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(SignalRDecorator<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(NotificationsDecorator<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(DataStoreDecorator<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandExceptionsDecorator<,>));

            //Dashboard Pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationDecorator<,>));

            services.Configure<TelegramNotificationSettings>(Configuration.GetSection("TelegramNotificationSettings"));
            services.Configure<LoggerSettings>(Configuration.GetSection("LoggerSettings"));
            services.Configure<BitrixSettings>(Configuration.GetSection("BitrixSettings"));

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddAutoMapper(typeof(ChecksMappingProfile), typeof(DashboardMappingProfile));
            services.AddDashboardDalDIConfig();
            services.AddDashboardDIConfig();
            services.AddDashboardSchedulingDIConfig();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Monitor.DAL")), ServiceLifetime.Scoped);

            var connectionString = Configuration.GetConnectionString("MonitorConnection");
            services.AddDbContext<DashboardContext>(options => options
                .UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddAutodocIdentity().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddSession(options => { options.IdleTimeout = TimeSpan.FromHours(24); });


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

                    ValidateIssuer = false,
                    IssuerSigningKey = new X509SecurityKey(new X509Certificate2(Path.Combine(this.CurrentEnvironment.ContentRootPath, "AutodocAuth.cer"), "Autodoc1!"))
                };
            });
        }

        public void Configure(IApplicationBuilder app, Microsoft.Extensions.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseSpaStaticFiles();

            app.UseSignalR(routes =>
            {
                routes.MapHub<MonitoringHub>("/notify");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            if (!env.IsDevelopment())
            {
                JobManager.Initialize(new DashboardRegistry(app.ApplicationServices));
            }

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
