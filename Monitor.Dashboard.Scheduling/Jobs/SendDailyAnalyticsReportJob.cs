using FluentScheduler;
using Monitor.Dashboard.Scheduling.Processors;

namespace Monitor.Dashboard.Scheduling.Jobs
{
    public class SendDailyAnalyticsReportJob : IJob
    {
        private readonly SendAnalyticsReportProcessor _sendDailyAnalyticsReportProcessor;

        public SendDailyAnalyticsReportJob(SendAnalyticsReportProcessor sendDailyAnalyticsReportProcessor)
        {
            _sendDailyAnalyticsReportProcessor = sendDailyAnalyticsReportProcessor;
        }

        public void Execute()
        {
            _sendDailyAnalyticsReportProcessor.SendDailyAnalitics();
        }
    }
}
