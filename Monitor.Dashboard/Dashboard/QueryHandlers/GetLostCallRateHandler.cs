using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Application.Dashboard.Models;
using Monitor.Dashboard.Dashboard.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor.Dashboard.Dashboard.QueryHandlers
{
    public class GetLostCallRateHandler : IRequestHandler<GetLostCallRateQuery, LostCallRateModel>
    {
        private readonly ILostCallRateService _lostCallRateService;
        private readonly IMemoryCache _cache;

        private readonly string _isUpdateTodayCacheString = "CallRateCache";
        public GetLostCallRateHandler(ILostCallRateService lostCallRateService, IMemoryCache cache)
        {
            _lostCallRateService = lostCallRateService ?? throw new ArgumentNullException(nameof(lostCallRateService));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<LostCallRateModel> Handle(GetLostCallRateQuery request, CancellationToken cancellationToken)
        {
            var result = new LostCallRateModel
            {
                HourRate = await GetRate(DateTime.Now.AddHours(-1), DateTime.Now),
                DayRate = await GetRate(DateTime.Today, DateTime.Now)
            };

            var isUpdateToday = _cache.Get(_isUpdateTodayCacheString);
            if (isUpdateToday == null)
            {
                var currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                var rateByMonth = await GetRate(currentMonth, DateTime.Now);
                result.MonthRate = rateByMonth;
                await _lostCallRateService.UpdateLostCallRate((short)currentMonth.Year, (short)currentMonth.Month, rateByMonth);

                var prevMonth = currentMonth.AddMonths(-1);
                var lastDayOfPreMonth = currentMonth.AddDays(-1);
                var rateByPrevMonth = await GetRate(prevMonth, lastDayOfPreMonth);
                result.PreviousMonthRate = rateByPrevMonth;
                await _lostCallRateService.UpdateLostCallRate((short)prevMonth.Year, (short)prevMonth.Month, rateByPrevMonth);

                _cache.Set(_isUpdateTodayCacheString, new object { }, TimeSpan.FromDays(1));
            }
            else
            {
                var currentMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                var rateByMonth = _lostCallRateService.GetLostCallRateFromDB((short)currentMonth.Year, (short)currentMonth.Month);
                result.MonthRate = rateByMonth;

                var prevMonth = currentMonth.AddMonths(-1);
                var rateByPrevMonth = _lostCallRateService.GetLostCallRateFromDB((short)prevMonth.Year, (short)prevMonth.Month);
                result.PreviousMonthRate = rateByPrevMonth;
            }

            return result;
        }

        private async Task<decimal> GetRate(DateTime dateFrom, DateTime dateTo)
        {
            var callFailedCode = 304;
            var allCallsCount = await _lostCallRateService.GetLostCallRateByPeriod(dateFrom, dateTo);
            var failedCallCount = await _lostCallRateService.GetLostCallRateByPeriod(dateFrom, dateTo, callFailedCode);
            return Decimal.Round(((decimal)100 / allCallsCount) * failedCallCount, 2);
        }
    }
}
