using MediatR;
using Monitor.Application.Dashboard.Models;
using Monitor.Application.Interfaces;

namespace Monitor.Dashboard.Monitoring.Queries
{
    public class GetSalesByDayAndMonthQuery : IQuery<SalesByDayAndMonthModel>, IRequest<SalesByDayAndMonthModel>
    {
    }
}
