using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Monitor.Application.Dashboard.Models.Sales;
using Monitor.Application.MonitoringChecks.Models;
using Monitor.Dashboard.Dashboard.Commands;
using Monitor.Persistence.Dashboard;
using Monitor.Persistence.Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor.Dashboard.Dashboard.CommandHandlers
{
    public class SaveSalesTargetCommandHandler : IRequestHandler<SaveSalesTargetCommand, ApiResponseResult>
    {
        private readonly DashboardContext _context;
        private readonly IMapper _mapper;

        public SaveSalesTargetCommandHandler
        (
            DashboardContext context,
            IMapper mapper
        )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ApiResponseResult> Handle(SaveSalesTargetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                EFMontlySalesInfoModel entity;

                if (request.Model.Id != 0)
                {
                    entity = await _context.MontlySalesInfo.FindAsync(request.Model.Id);
                    entity.PlannedSalesSumm = request.Model.PlannedSalesSumm;
                    _context.MontlySalesInfo.Update(entity);
                    await _context.SaveChangesAsync(cancellationToken);

                    return new ApiResponseResult { Success = true };
                }

                entity = await _context.MontlySalesInfo
                    .Where(x => x.Year == request.Model.Year && x.Month == request.Model.Month)
                    .FirstOrDefaultAsync();

                if (entity != null)
                {
                    entity.PlannedSalesSumm = request.Model.PlannedSalesSumm;
                    _context.MontlySalesInfo.Update(entity);
                }
                else
                {
                    entity = _mapper.Map<MonthlySalesInfoModel, EFMontlySalesInfoModel>(request.Model);
                    _context.MontlySalesInfo.Add(entity);
                }
                               
                await _context.SaveChangesAsync(cancellationToken);

                return new ApiResponseResult { Success = true };
            }
            catch(Exception e)
            {
                return new ApiResponseResult
                {
                    Success = false,
                    Errors = new List<string> { e.Message + " " + e.StackTrace }
                };
            }

            throw new NotImplementedException();
        }
    }
}
