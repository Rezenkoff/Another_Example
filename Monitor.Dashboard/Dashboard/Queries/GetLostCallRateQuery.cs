using MediatR;
using Monitor.Application.Dashboard.Interfaces;
using Monitor.Application.Dashboard.Models;

namespace Monitor.Dashboard.Dashboard.Queries
{
    public class GetLostCallRateQuery : IQuery<LostCallRateModel>, IRequest<LostCallRateModel>
    {
    }
}
