using Monitor.Application.Dashboard.Models.BitrixModels;
using System.Threading.Tasks;

namespace Monitor.Application.Interfaces
{
    public interface ISignalRNotificationsService : INotificationsService
    {
        Task DashboardNotify(OnCrmNewDealModel model);
    }
}
