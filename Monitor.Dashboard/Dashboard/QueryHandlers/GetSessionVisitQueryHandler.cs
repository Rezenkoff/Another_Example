using MediatR;
using Monitor.Dashboard.Monitoring.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;
using Monitor.Persistence.Dashboard;
using Monitor.Persistence.Dashboard.Models;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monitor.Application.Dashboard.Models;
using Monitor.Application.Dashboard.Interfaces.Services;

namespace Monitor.Dashboard.Monitoring.QueryHandlers
{
    public class GetSessionVisitQueryHandler : IRequestHandler<GetSessionVisitsQuery, SessionVisitModel>
    {
        private readonly IGoogleAnalyticsService _googleAnalyticsService;
        private DashboardContext _context;
        private readonly IMapper _mapper;

        public GetSessionVisitQueryHandler(IGoogleAnalyticsService googleAnalyticsService, DashboardContext context, IMapper mapper)
        {
            _googleAnalyticsService = googleAnalyticsService ?? throw new ArgumentNullException(nameof(googleAnalyticsService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SessionVisitModel> Handle(GetSessionVisitsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var visits = await GetVisitsFromAnalytics();

                return _mapper.Map<EFGoogleAnaliticCache, SessionVisitModel>(visits);            
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<EFGoogleAnaliticCache> GetVisitsFromAnalytics()
        {
            var entity = _context.GoogleAnalitCache;
            var data = await entity.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            return data;
        }
    }
}
