using System;
using System.Threading.Tasks;

namespace Monitor.Application.Dashboard.Interfaces.Services
{
    public interface ILoggingService
    {
        Task<int> GetOrderCount(DateTime from, DateTime to, int mode);
        Task<long> GetReturnedOrderSumm(DateTime from, DateTime to);
    }
}
