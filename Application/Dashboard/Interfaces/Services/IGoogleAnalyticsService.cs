using System;
using System.Threading.Tasks;

namespace Monitor.Application.Dashboard.Interfaces.Services
{
    public interface IGoogleAnalyticsService
    {
        Task<int> GetSessionDataFromGA(DateTime from, DateTime to);
    }
}
