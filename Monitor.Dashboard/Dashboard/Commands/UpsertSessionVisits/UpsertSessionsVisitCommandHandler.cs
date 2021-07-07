using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Application.MonitoringChecks.Models;
using Monitor.Persistence.Dashboard;
using Monitor.Persistence.Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Monitor.Dashboard.Dashboard.Commands.UpsertSessionVisits
{
    class UpsertSessionsVisitCommandHandler : IRequestHandler<UpsertSessionsVisitCommand, ApiResponseResult>
    {
        private readonly DashboardContext _context;
        private readonly IMapper _mapper;
        private readonly IGoogleAnalyticsService _googleAnalyticsService;


        public UpsertSessionsVisitCommandHandler
        (
            DashboardContext context,
            IMapper mapper,
            IGoogleAnalyticsService googleAnalyticsService
        )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _googleAnalyticsService = googleAnalyticsService ?? throw new ArgumentNullException(nameof(googleAnalyticsService));

        }

        public async Task<ApiResponseResult> Handle(UpsertSessionsVisitCommand request, CancellationToken cancellationToken)
        {
            int sessionByDay;
            int sessionByMonth;
            var visits = await GetVisitsFromAnalytics();
            bool needUpdateCache = false;

            EFGoogleAnaliticCache cachObj = new EFGoogleAnaliticCache() { SessionByDay = 0, SessionByMonth = 0, MaxSessionCount10Day = 0 };

            try
            {
                if (visits == null || (DateTime.Now.AddMinutes(-10)).CompareTo(visits.LastUpdateByDay) >= 0)
                {
                    sessionByDay = await _googleAnalyticsService.GetSessionDataFromGA(DateTime.Now, DateTime.Now);
                    cachObj.SessionByDay = sessionByDay;
                    cachObj.LastUpdateByDay = DateTime.Now;
                    needUpdateCache = true;
                }
                else
                {
                    sessionByDay = visits.SessionByDay;
                    cachObj.SessionByDay = visits.SessionByDay;
                    cachObj.LastUpdateByDay = visits.LastUpdateByDay;
                }

                if (visits == null || (DateTime.Now.AddHours(-1)).CompareTo(visits.LastUpdateByMonth) >= 0)
                {
                    sessionByMonth = await _googleAnalyticsService.GetSessionDataFromGA(DateTime.Now.AddDays(1 - DateTime.Now.Day), DateTime.Now);
                    cachObj.SessionByMonth = sessionByMonth;
                    cachObj.LastUpdateByMonth = DateTime.Now;
                    needUpdateCache = true;
                }
                else
                {
                    sessionByMonth = visits.SessionByMonth;
                    cachObj.SessionByMonth = visits.SessionByMonth;
                    cachObj.LastUpdateByMonth = visits.LastUpdateByMonth;
                }

                cachObj.SessionByDayWeekAgo = await _googleAnalyticsService.GetSessionDataFromGA(DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-7));

                //old logic for max session count by 10 days
                //var maxSessionCountBy10Days = sessionByDay;
                //for (var i = 1; i < 10; i++)
                //{
                //    var sessionCount = await _googleAnalyticsService.GetSessionDataFromGA(DateTime.Now.AddDays(-i), DateTime.Now.AddDays(-i));
                //    if (sessionCount > maxSessionCountBy10Days)
                //    {
                //        maxSessionCountBy10Days = sessionCount;
                //        cachObj.MaxSessionCount10Day = sessionCount;
                //    }
                //    if (i == 7)
                //    {
                //        cachObj.SessionByDayWeekAgo = sessionCount;
                //    }
                //}

                if (needUpdateCache)
                {
                    await PushCache(cachObj);
                }
                return new ApiResponseResult { Success = true };
            }
            catch (Exception e)
            {
                return new ApiResponseResult { Success = false, Errors = new List<string> { e.Message + " " + e.StackTrace } };
            }
        }

        public async Task PushCache(EFGoogleAnaliticCache visitAnalitic)
        {
            _context.GoogleAnalitCache.Add(visitAnalitic);
            await _context.SaveChangesAsync();
        }

        public async Task<EFGoogleAnaliticCache> GetVisitsFromAnalytics()
        {
            var entity = _context.GoogleAnalitCache;
            var data = await entity.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            return data;
        }
    }

}
