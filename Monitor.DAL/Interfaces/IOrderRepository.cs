using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monitor.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<Dictionary<object, object>> GetDealCountByOrderStatusId();
        Task<(int, int, int)> GetSalesByDayAndMonth();
        Task<int> GetCountOfSalesByMonth();
        Task<int> GetCountOfReturnedByMonth();
        Task<int> GetCountOfAutoReturnedByMonth();
        Task<int> GetCountOfReturnedAndPartReturnedByMonth();
        Task<Dictionary<int, string>> GetManagers();
    }
}
