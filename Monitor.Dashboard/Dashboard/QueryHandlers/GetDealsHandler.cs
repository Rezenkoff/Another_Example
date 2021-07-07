using MediatR;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Application.Dashboard.Models;
using Monitor.Dashboard.Monitoring.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor.Dashboard.Monitoring.QueryHandlers
{
    public class GetDealsHandler : IRequestHandler<GetDealsQuery, DealsModel>
    {
        private readonly IDealsService _dealsService;

        public GetDealsHandler(IDealsService dealsService)
        {
            _dealsService = dealsService?? throw new ArgumentNullException(nameof(dealsService));
        }

        public async Task<DealsModel> Handle(GetDealsQuery query, CancellationToken cancellationToken)
        {
            var result = await _dealsService.GetDeals();
            return result;
        }
    }
}
