using Microsoft.Extensions.DependencyInjection;
using Monitor.Dashboard.Scheduling.Jobs;
using Monitor.Dashboard.Scheduling.Processors;

namespace Monitor.Dashboard.Scheduling.Config
{
    public static class DIConfig
    {
        public static IServiceCollection AddDashboardSchedulingDIConfig(this IServiceCollection services)
        {
            //Scheduled Processors
            services.AddTransient<SendAnalyticsReportProcessor>();

            //Scheduled Jobs
            services.AddTransient<SendDailyAnalyticsReportJob>();
            services.AddTransient<SendLiteAnalyticsReportJob>();
            return services;
        }
    }
}
