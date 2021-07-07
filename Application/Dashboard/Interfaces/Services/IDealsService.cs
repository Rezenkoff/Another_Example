using Monitor.Application.Dashboard.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Monitor.Application.Dashboard.Interfaces.Services
{
    public interface IDealsService
    {
        Task<DealsModel> GetDeals();
        Task<ConversionModel> GetConversion();
        Task<SuccessfullDealsModel> SuccessfullDeals();
        Task<ReturnedMonthModel> GetReturnedMonth(bool recount = false);
    }
}
