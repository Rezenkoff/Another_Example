using MediatR;
using Monitor.Application.Dashboard.Models.Sales;
using Monitor.Application.Interfaces;

namespace Monitor.Dashboard.Monitoring.Queries
{
    public class GetSalesStatisticsQuery : IQuery<MonthlySalesInfoModel>, IRequest<MonthlySalesInfoModel>
    {
    }
}
