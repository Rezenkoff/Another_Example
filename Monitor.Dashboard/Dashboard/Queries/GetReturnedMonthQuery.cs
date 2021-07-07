using MediatR;
using Monitor.Application.Dashboard.Interfaces;
using Monitor.Application.Dashboard.Models;


namespace Monitor.Dashboard.Monitoring.Queries
{
    public class GetReturnedMonthQuery : IQuery<ReturnedMonthModel>, IRequest<ReturnedMonthModel>
    {
    }
}
