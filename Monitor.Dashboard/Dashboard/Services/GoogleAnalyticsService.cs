using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.AnalyticsReporting.v4.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Monitor.Application.Dashboard.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Monitor.Dashboard.Dashboard.Services
{
    public class GoogleAnalyticsService : IGoogleAnalyticsService
    {
        private GoogleCredential _credentials;
        private AnalyticsReportingService _reportingService;
        private readonly string _viewId = "161230165"; // your view id (GA -> Настройки представления -> Идентификатор представления)
        private readonly string _credantilPath = Path.Combine("Credentials", "GA_credentials.json");  // path to the json file for the Service account

        public GoogleAnalyticsService()
        {
            Initialize();
        }

        public async Task<int> GetSessionDataFromGA(DateTime from, DateTime to)
        {
            var result = 0;
            var dateFormat = "yyyy-MM-dd";
            var dateRange = new DateRange
            {
                StartDate = from.ToString(dateFormat),
                EndDate = to.ToString(dateFormat),
            };
            var sessions = new Metric
            {
                Expression = "ga:sessions",
                Alias = "Sessions"
            };
            var date = new Dimension { Name = "ga:date" };

            var reportRequest = new ReportRequest
            {
                DateRanges = new List<DateRange> { dateRange },
                Dimensions = new List<Dimension> { date },
                Metrics = new List<Metric> { sessions },
                ViewId = _viewId
            };

            var getReportsRequest = new GetReportsRequest
            {
                ReportRequests = new List<ReportRequest> { reportRequest }
            };
            var batchRequest = _reportingService.Reports.BatchGet(getReportsRequest);
            var response = await batchRequest.ExecuteAsync();
            foreach (var row in response.Reports.First().Data.Rows)
            {
                result += Convert.ToInt32(row.Metrics.First().Values.First());
            }
            return result;
        }

        private void Initialize()
        {
            var filepath = _credantilPath;
            using (var stream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                string[] scopes = { AnalyticsReportingService.Scope.AnalyticsReadonly };
                var googleCredential = GoogleCredential.FromStream(stream);
                _credentials = googleCredential.CreateScoped(scopes);
            }

            _reportingService = new AnalyticsReportingService(
            new BaseClientService.Initializer
            {
                HttpClientInitializer = _credentials
            });
        }
    }
}
