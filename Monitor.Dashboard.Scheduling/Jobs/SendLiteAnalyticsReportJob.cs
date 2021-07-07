using FluentScheduler;
using Monitor.Dashboard.Scheduling.Processors;

namespace Monitor.Dashboard.Scheduling.Jobs
{
    public class SendLiteAnalyticsReportJob : IJob
    {
        private readonly SendAnalyticsReportProcessor _sendDailyAnalyticsReportProcessor;

        public SendLiteAnalyticsReportJob(SendAnalyticsReportProcessor sendDailyAnalyticsReportProcessor)
        {
            _sendDailyAnalyticsReportProcessor = sendDailyAnalyticsReportProcessor;
        }

        public void Execute()
        {
            _sendDailyAnalyticsReportProcessor.SendLiteAnalytics();
        }
    }
}
