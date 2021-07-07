using MediatR;
using Monitor.Dashboard.Monitoring.Queries;
using Monitor.Persistence.Dashboard;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;
using Monitor.Persistence.Dashboard.Models;
using System.Collections.Generic;
using Monitor.Application.Dashboard.Models.Sales;

namespace Monitor.Dashboard.Dashboard.QueryHandlers
{
    class GetAllSalesStatisticsQueryHandler : IRequestHandler<GetAllSalesStatisticsQuery, IEnumerable<MonthlySalesInfoModel>>
    {
        private DashboardContext _context;
        private IMapper _mapper;

        public GetAllSalesStatisticsQueryHandler(DashboardContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<MonthlySalesInfoModel>> Handle(GetAllSalesStatisticsQuery request, CancellationToken cancellationToken)
        {
            using (_context)
            {
                var entity = await _context.MontlySalesInfo.ToListAsync();

                if (entity == null)
                {
                    return null;
                }

                return _mapper.Map<IEnumerable<EFMontlySalesInfoModel>, IEnumerable<MonthlySalesInfoModel>>(entity);
            }                        
        }
    }
}
