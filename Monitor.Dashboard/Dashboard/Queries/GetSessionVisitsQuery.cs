using MediatR;
using Monitor.Application.Dashboard.Interfaces;
using Monitor.Application.Dashboard.Models;

namespace Monitor.Dashboard.Monitoring.Queries
{
    public class GetSessionVisitsQuery : IQuery<SessionVisitModel>, IRequest<SessionVisitModel>
    {
        
    }
}
