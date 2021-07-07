using Microsoft.EntityFrameworkCore;
using Monitor.Application.Dashboard.Interfaces.Provides;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Persistence.Dashboard;
using Monitor.Persistence.Dashboard.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Monitor.Dashboard.Dashboard.Services
{
    public class LostCallRateService : ILostCallRateService
    {
        private readonly IBitrixProvider _bitrixProvider;
        private readonly DashboardContext _dashboardContext;

        public LostCallRateService(IBitrixProvider bitrixProvider, DashboardContext dashboardContext)
        {
            _bitrixProvider = bitrixProvider ?? throw new ArgumentNullException(nameof(bitrixProvider));
            _dashboardContext = dashboardContext ?? throw new ArgumentNullException(nameof(dashboardContext));
        }

        public async Task<int> GetLostCallRateByPeriod(DateTime dateFrom, DateTime dateTo, int callFailedCode = 0)
        {
            int minCallDuration = 5;
            var stringDateFrom = dateFrom.ToString("dd.MM.yyyy HH:mm:ss");
            var stringDateTo = dateTo.ToString("dd.MM.yyyy 23:59:59");
            var telephonyCount = await _bitrixProvider.GetTelephony(stringDateFrom, stringDateTo, callFailedCode, minCallDuration);
            return telephonyCount;
        }

        public decimal GetLostCallRateFromDB(short year, short month)
        {
            var result = _dashboardContext.LostCallRate.FirstOrDefault(x => x.Year == year && x.Month == month);
            return result.LostCallRate;
        }

        public async Task UpdateLostCallRate(short year, short month, decimal value)
        {
            var result = _dashboardContext.LostCallRate.FirstOrDefault(x => x.Year == year && x.Month == month);
            if (result == null)
            {
                _dashboardContext.LostCallRate.Add(new EFLostCallRateModel { Year = year, Month = month, LostCallRate = value });
            }
            else
            {
                result.LostCallRate = value;
            }
            _dashboardContext.Entry(result).State = EntityState.Modified;
            await _dashboardContext.SaveChangesAsync();
        }
    }
}
