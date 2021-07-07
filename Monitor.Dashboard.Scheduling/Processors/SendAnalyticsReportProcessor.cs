using Monitor.Application.Dashboard.Interfaces.Provides;
using Monitor.Application.Dashboard.Interfaces.Services;
using Monitor.Application.Interfaces;
using Monitor.DAL.Interfaces;
using System;
using System.Globalization;

namespace Monitor.Dashboard.Scheduling.Processors
{
    public class SendAnalyticsReportProcessor
    {
        private readonly ITelegramNotificationService _notificationsService;
        private readonly IGoogleAnalyticsService _googleAnalyticsService;
        private readonly IOrderRepository _orderRepository;
        private readonly IBitrixProvider _bitrixProvider;
        private readonly ISalesByDayAndMonthService _salesByDayAndMonthService;
        private readonly IDealsService _dealService;

        public SendAnalyticsReportProcessor(ITelegramNotificationService notificationsService, IGoogleAnalyticsService googleAnalyticsService,
            IOrderRepository orderRepository, IBitrixProvider bitrixProvider, ISalesByDayAndMonthService salesByDayAndMonthService, IDealsService dealService)
        {
            _notificationsService = notificationsService ?? throw new ArgumentNullException(nameof(notificationsService));
            _googleAnalyticsService = googleAnalyticsService ?? throw new ArgumentNullException(nameof(googleAnalyticsService));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _dealService = dealService ?? throw new ArgumentNullException(nameof(dealService));
            _bitrixProvider = bitrixProvider;
            _salesByDayAndMonthService = salesByDayAndMonthService ?? throw new ArgumentNullException(nameof(salesByDayAndMonthService));
        }

        public async void SendDailyAnalitics()
        {
            var sessionByDay = _googleAnalyticsService.GetSessionDataFromGA(DateTime.Now, DateTime.Now).Result;
            var sessionByMonth = _googleAnalyticsService.GetSessionDataFromGA(DateTime.Now.AddDays(1 - DateTime.Now.Day), DateTime.Now).Result;
            (int, int, int) sales = _orderRepository.GetSalesByDayAndMonth().Result;
            var salesCountByMonth = _orderRepository.GetCountOfSalesByMonth().Result;
            int callCallcentreDay = _bitrixProvider.GetTelephony((DateTime.Today).ToString("dd.MM.yyyy HH:mm:ss")).Result;
            int callCallcentreMonth = _bitrixProvider.GetTelephony((DateTime.Today.AddDays(-DateTime.Today.Day + 1)).ToString("dd.MM.yyyy HH:mm:ss")).Result;

            int leadsDay = _bitrixProvider.GetLeads((DateTime.Today).ToString("dd.MM.yyyy HH:mm:ss"), "").Result;
            int leadsMonth = _bitrixProvider.GetLeads((DateTime.Today.AddDays(-DateTime.Today.Day + 1)).ToString("dd.MM.yyyy HH:mm:ss"), "").Result;

            var salesByDayAndMonth = _salesByDayAndMonthService.GetSales().Result;

            var returnedMonth = await _dealService.GetReturnedMonth(true);


            var culture = new CultureInfo("ru-RU");
            var text = $"#monitor_stat\n"

                     + $"день:"
                     + $"\n\U0001F6D2 Заказов: {sales.Item1.ToString("#,#", culture)} шт."
                     + $"\n\U0001F4B5 ВД: {sales.Item2.ToString("#,#", culture)} грн.\n"

                     + $"\nмесяц:"
                     + $"\n\U0001F6D2 Заказов: {salesCountByMonth.ToString("#,#", culture)} шт."
                     + $"\n\U0001F4B5 ВД: {sales.Item3.ToString("#,#", culture)} грн.\n"

                     + $"\nВизиты д.: {sessionByDay.ToString("#,#", culture)} шт."
                     + $"\nВизиты м.: {sessionByMonth.ToString("#,#", culture)} шт.\n"

                     + $"\nВходящих д.: {callCallcentreDay.ToString("#,#", culture)} \U0001F4DE"
                     + $"\nВходящих м.: {callCallcentreMonth.ToString("#,#", culture)} \U0001F4DE\n"

                     + $"\nЛиды д.: {leadsDay.ToString("#,#", culture)} шт."
                     + $"\nЛиды м.: {leadsMonth.ToString("#,#", culture)} шт.\n"

                     + $"\nСредний чек д.: {salesByDayAndMonth.SumSalesByToday18_Yesterday18 / salesByDayAndMonth.CountSalesByToday18_Yesterday18}грн"
                     + $"\nСредний чек м.: {salesByDayAndMonth.SumSalesByMonth / salesByDayAndMonth.CountSalesByMonth}грн\n"

                     
                     + $"\nВозвраты от ВД: {string.Format("{0:F2}", (returnedMonth.VDReturned / returnedMonth.VDSuccess) * 100)}%"
                     + $"\nВозвраты: {string.Format("{0:F2}", ((double)returnedMonth.orderReturned / (double)returnedMonth.orderSuccess) * 100)}%"
                     + $"\nАвтовозвраты: {string.Format("{0:F2}", (returnedMonth.AutoReturned_RetPartRet == 0 ? 0 : (returnedMonth.AutoReturned / returnedMonth.AutoReturned_RetPartRet)) * 100)}%\n"
                     

                     + $"\nhttps://monitor.autodoc.ua/dashboard";

            var message1 = _notificationsService.SendMessageFromSeoWorker(text);
            message1.Wait();
        }

        public void SendLiteAnalytics()
        {
            var sessionByDay = _googleAnalyticsService.GetSessionDataFromGA(DateTime.Now, DateTime.Now).Result;
            (int, int, int) sales = _orderRepository.GetSalesByDayAndMonth().Result;
            int callCallcentre = _bitrixProvider.GetTelephony((DateTime.Today).ToString("dd.MM.yyyy HH:mm:ss")).Result;
            int leadsDay = _bitrixProvider.GetLeads((DateTime.Today).ToString("dd.MM.yyyy HH:mm:ss"), "").Result;

            var culture = new CultureInfo("ru-RU");
            var text = $"#monitor_lite_stat"

                     + $"\nВД: {sales.Item2.ToString("#,#", culture)} грн."
                     + $"\nСделок: {sales.Item1.ToString("#,#", culture)} шт.\n"

                     + $"\nВизиты: {sessionByDay.ToString("#,#", culture)}"
                     + $"\nВходящие: {callCallcentre.ToString("#,#", culture)} шт.\n"

                     + $"\nЛиды: {leadsDay.ToString("#,#", culture)} шт.\n"

                     + $"\nhttps://monitor.autodoc.ua/dashboard";

            if (DateTime.Now.Hour != 18)
            {
                var message1 = _notificationsService.SendMessageFromSeoWorker(text);
                message1.Wait();
            }

            var message2 = _notificationsService.SendMessageToMdpChat(text);
            message2.Wait();
        }
    }
}
