using Monitor.Application.Dashboard.Models;
using System;
using System.Threading.Tasks;

namespace Monitor.Application.Dashboard.Interfaces.Services
{
    public interface ILostCallRateService
    {
        Task<int> GetLostCallRateByPeriod(DateTime dateFrom, DateTime dateTo, int callFailedCode = 0);
        decimal GetLostCallRateFromDB(short year, short month);
        Task UpdateLostCallRate(short year, short month, decimal value);
    }
}
