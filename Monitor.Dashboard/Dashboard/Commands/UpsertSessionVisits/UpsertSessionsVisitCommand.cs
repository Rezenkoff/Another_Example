using MediatR;
using Monitor.Application.Dashboard.Interfaces;
using Monitor.Application.MonitoringChecks.Models;
using Monitor.Persistence.Dashboard.Models;

namespace Monitor.Dashboard.Dashboard.Commands.UpsertSessionVisits
{
    public class UpsertSessionsVisitCommand : IRequest<ApiResponseResult>, ICommand<ApiResponseResult>
    {
        public EFGoogleAnaliticCache Model { get; set; }

    }
}
