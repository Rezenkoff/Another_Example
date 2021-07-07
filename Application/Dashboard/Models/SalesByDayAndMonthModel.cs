namespace Monitor.Application.Dashboard.Models
{
    public class SalesByDayAndMonthModel
    {
        public int CountSalesByToday18_Yesterday18 { get; set; }
        public int SumSalesByToday18_Yesterday18 { get; set; }
        public int PlannedSalesSum { get; set; }
        public int SumSalesByMonth { get; set; }
        public int CountSalesByMonth { get; set; }
    }
}
