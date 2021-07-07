using Monitor.Application.Dashboard.Models;
using System.Threading.Tasks;

namespace Monitor.Application.Dashboard.Interfaces.Services
{
    public interface ISalesByDayAndMonthService
    {
        Task<SalesByDayAndMonthModel> GetSales();
    }
}
