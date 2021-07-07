using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monitor.Application.Dashboard.Models;
using Monitor.Application.Dashboard.Models.Sales;
using Monitor.Application.MonitoringChecks.Models;
using Monitor.Dashboard.Dashboard.Commands;
using Monitor.Dashboard.Dashboard.Commands.UpsertSessionVisits;
using Monitor.Dashboard.Dashboard.Queries;
using Monitor.Dashboard.Monitoring.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monitor.WebUI.Controllers
{
    [Authorize(Roles = "Admin, SEO")]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController
    {
        private IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("get-visits")]
        [HttpGet]
        public async Task<SessionVisitModel> GetVisits()
        {
            await _mediator.Send(new UpsertSessionsVisitCommand());
            var visits = await _mediator.Send(new GetSessionVisitsQuery());
            return visits;
        }

        [Route("get-deals")]
        [HttpGet]
        public async Task<DealsModel> GetDeals()
        {
            return await _mediator.Send(new GetDealsQuery());
        }

        [Route("get-conversion")]
        [HttpGet]
        public async Task<ConversionModel> GetConversion()
        {
            return await _mediator.Send(new GetConversionQuery());
        }

        [Route("get-succesful-deals")]
        [HttpGet]
        public async Task<SuccessfullDealsModel> GetSuccessfulDeals()
        {
            return await _mediator.Send(new GetSuccesfullDealsQuery());
        }

        [Route("get-sales-byday")]
        [HttpGet]
        public async Task<SalesByDayAndMonthModel> GetSalesByDay()
        {
            return await _mediator.Send(new GetSalesByDayAndMonthQuery());
        }


        [Route("get-sales-info")]
        [HttpGet]
        public async Task<MonthlySalesInfoModel> GetSalesInfo()
        {
            return await _mediator.Send(new GetSalesStatisticsQuery());
        }

        [Route("get-all-sales-info")]
        [HttpGet]
        public async Task<IEnumerable<MonthlySalesInfoModel>> GetAllSalesInfo()
        {
            return await _mediator.Send(new GetAllSalesStatisticsQuery());
        }

        [Route("save-sales-target")]
        public async Task<ApiResponseResult> SaveSalesTarget(MonthlySalesInfoModel model)
        {
            return await _mediator.Send(new SaveSalesTargetCommand { Model = model });
        }

        [Route("lost-call-rate")]
        [HttpGet]
        public async Task<LostCallRateModel> GetLostCallRate()
        {
            return await _mediator.Send(new GetLostCallRateQuery());
        }

        [Route("get-returnedmonth")]
        [HttpGet]
        public async Task<ReturnedMonthModel> GetReturnedMonth()
        {
            return await _mediator.Send(new GetReturnedMonthQuery());
        }
    }
}
