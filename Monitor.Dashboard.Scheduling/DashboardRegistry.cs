using FluentScheduler;
using Microsoft.Extensions.DependencyInjection;
using Monitor.Dashboard.Scheduling.Jobs;
using System;

namespace Monitor.Dashboard.Scheduling
{
    public class DashboardRegistry : Registry
    {
        public DashboardRegistry(IServiceProvider sp)
        {
            Schedule(() => sp.CreateScope().ServiceProvider.GetRequiredService<SendDailyAnalyticsReportJob>()).ToRunEvery(0).Days().At(18, 00);

            Schedule(() => sp.CreateScope().ServiceProvider.GetRequiredService<SendLiteAnalyticsReportJob>()).ToRunEvery(0).Days().At(9, 00);
            Schedule(() => sp.CreateScope().ServiceProvider.GetRequiredService<SendLiteAnalyticsReportJob>()).ToRunEvery(0).Days().At(12, 00);
            Schedule(() => sp.CreateScope().ServiceProvider.GetRequiredService<SendLiteAnalyticsReportJob>()).ToRunEvery(0).Days().At(15, 00);
            Schedule(() => sp.CreateScope().ServiceProvider.GetRequiredService<SendLiteAnalyticsReportJob>()).ToRunEvery(0).Days().At(18, 00);
        }
    }
}
