namespace Monitor.Application.Dashboard.Models.Sales
{
    public class MonthlySalesInfoModel
    {
        public int Id { get; set; }
        public short Year { get; set; }
        public short Month { get; set; }
        public decimal PlannedSalesSumm { get; set; }
        public decimal ActualSalesSumm { get; set; }
    }
}
