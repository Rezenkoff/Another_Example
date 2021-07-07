using MediatR;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Application.Dashboard.Models;
using Monitor.Dashboard.Monitoring.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor.Dashboard.Dashboard.QueryHandlers
{
    public class GetReturnedMonthHandler : IRequestHandler<GetReturnedMonthQuery, ReturnedMonthModel>
    {
        private readonly IDealsService _dealsService;

        public GetReturnedMonthHandler(IDealsService dealsService)
        {
            _dealsService = dealsService ?? throw new ArgumentNullException(nameof(dealsService));
        }

        public async Task<ReturnedMonthModel> Handle(GetReturnedMonthQuery query, CancellationToken cancellationToken)
        {
            return await _dealsService.GetReturnedMonth();
        }
    }
}
