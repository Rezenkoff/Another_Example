using MediatR;
using Monitor.Application.Dashboard.Interfaces;
using Monitor.Application.Dashboard.Models.Sales;
using Monitor.Application.MonitoringChecks.Models;

namespace Monitor.Dashboard.Dashboard.Commands
{
    public class SaveSalesTargetCommand : IRequest<ApiResponseResult> , ICommand<ApiResponseResult>
    {
        public MonthlySalesInfoModel Model { get; set; } 
    }
}
