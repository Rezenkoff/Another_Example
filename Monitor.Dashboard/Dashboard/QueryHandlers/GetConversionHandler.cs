using MediatR;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Application.Dashboard.Models;
using Monitor.Dashboard.Monitoring.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor.Dashboard.Monitoring.QueryHandlers
{
    public class GetConversionHandler : IRequestHandler<GetConversionQuery, ConversionModel>
    {
        private readonly IDealsService _dealsService;

        public GetConversionHandler(IDealsService dealsService)
        {
            _dealsService = dealsService ?? throw new ArgumentNullException(nameof(dealsService));
        }

        public async Task<ConversionModel> Handle(GetConversionQuery query, CancellationToken cancellationToken)
        {
            return await _dealsService.GetConversion();
        }
    }
}
