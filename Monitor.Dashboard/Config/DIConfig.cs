using Microsoft.Extensions.DependencyInjection;
using Monitor.Application.Dashboard.Interfaces.Provides;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Dashboard.Dashboard.Services;
using Monitor.Dashboard.Monitoring.Providers;
using Monitor.Dashboard.Monitoring.UnitOfWork;

namespace Monitor.Dashboard.Config
{
    public static class DIConfig
    {
        public static IServiceCollection AddDashboardDIConfig(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddSingleton<IGoogleAnalyticsService, GoogleAnalyticsService>();
            services.AddScoped<ILoggingService, LoggingService>();
            services.AddScoped<IDealsService, DealsService>();
            services.AddScoped<ISalesByDayAndMonthService, SalesByDayAndMonthServices>();
            services.AddScoped<IBitrixProvider, BitrixProvider>();
            services.AddScoped<IFeedService, FeedService>();

            return services;
        }
    }
}
