using Monitor.Application.MonitoringChecks.Models;
using System.Threading.Tasks;

namespace Monitor.Application.Dashboard.Interfaces
{
    public interface IDashboardScheduler
    {
        Task AddToSchedule(CheckSettings settings);
        void RemoveFromSchedule(CheckSettings settings);
        Task ReSchedule(CheckSettings settings);
        Task StopAll();
    }
}
