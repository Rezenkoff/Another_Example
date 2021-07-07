using Microsoft.Extensions.DependencyInjection;
using Monitor.Application.Interfaces;
using Monitor.DAL.Interfaces;
using Monitor.DAL.Repositories;

namespace Monitor.Dashboard.Config
{
    public static class DIConfig
    {
        public static IServiceCollection AddDashboardDalDIConfig(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IFeedRepository, FeedRepository>();
            services.AddScoped<ISeoPagesTagsRepository, SeoPagesTagsRepository>();

            return services;
        }
    }
}
