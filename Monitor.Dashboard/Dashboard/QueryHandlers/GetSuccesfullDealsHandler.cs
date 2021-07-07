using MediatR;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Application.Dashboard.Models;
using Monitor.Dashboard.Monitoring.Queries;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor.Dashboard.Monitoring.QueryHandlers
{
    public class GetSuccesfullDeals : IRequestHandler<GetSuccesfullDealsQuery, SuccessfullDealsModel>
    {
        private readonly IDealsService _dealsService;

        public GetSuccesfullDeals(IDealsService dealsService)
        {
            _dealsService = dealsService ?? throw new ArgumentNullException(nameof(dealsService));
        }

        public async Task<SuccessfullDealsModel> Handle(GetSuccesfullDealsQuery query, CancellationToken cancellationToken)
        {
            return await _dealsService.SuccessfullDeals();
        }
    }
}