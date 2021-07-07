using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Application.Dashboard.Models;
using Monitor.DAL.Interfaces;
using System.Threading.Tasks;

namespace Monitor.Dashboard.Dashboard.Services
{
    public class SalesByDayAndMonthServices : ISalesByDayAndMonthService
    {
        private readonly IOrderRepository _orderRepository;
        public SalesByDayAndMonthServices(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<SalesByDayAndMonthModel> GetSales()
        {
            (int, int, int) salesDayMonth = await _orderRepository.GetSalesByDayAndMonth();
            int countSalesByMonth = await _orderRepository.GetCountOfSalesByMonth();
            return new SalesByDayAndMonthModel() { CountSalesByToday18_Yesterday18 = salesDayMonth.Item1, SumSalesByToday18_Yesterday18 = salesDayMonth.Item2, SumSalesByMonth = salesDayMonth.Item3, CountSalesByMonth = countSalesByMonth};
        }
    }
}
