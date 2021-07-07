using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Monitor.Dashboard.Monitoring.Queries;
using Monitor.Persistence.Dashboard;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Application.Dashboard.Models;

namespace Monitor.Dashboard.Monitoring.QueryHandlers
{
    public class GetSalesByDayAndMonthHandler: IRequestHandler<GetSalesByDayAndMonthQuery, SalesByDayAndMonthModel>
    {
        private readonly ISalesByDayAndMonthService _salesByDayAndMonthService;
        private DashboardContext _context;
        private readonly IMapper _mapper;

        public GetSalesByDayAndMonthHandler(ISalesByDayAndMonthService salesByDayService, DashboardContext context, IMapper mapper)
        {
            _salesByDayAndMonthService = salesByDayService ?? throw new ArgumentNullException(nameof(salesByDayService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SalesByDayAndMonthModel> Handle(GetSalesByDayAndMonthQuery query, CancellationToken cancellationToken)
        {
            var result = await _salesByDayAndMonthService.GetSales();            
            var data = await _context.MontlySalesInfo.FirstOrDefaultAsync(o => o.Year == DateTime.Now.Year && o.Month == DateTime.Now.Month);
            result.PlannedSalesSum = (int)data.PlannedSalesSumm;

            return result;
        }
    }
}
