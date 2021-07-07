using MediatR;
using Monitor.Application.Dashboard.Models.Sales;
using Monitor.Application.Interfaces;
using System.Collections.Generic;

namespace Monitor.Dashboard.Monitoring.Queries
{
    public class GetAllSalesStatisticsQuery : IQuery<IEnumerable<MonthlySalesInfoModel>>, IRequest<IEnumerable<MonthlySalesInfoModel>>
    {
    }
}
