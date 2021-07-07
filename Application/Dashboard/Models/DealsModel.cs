namespace Monitor.Application.Dashboard.Models
{
    public class DealsModel
    {
        public int NewDealsCount { get; set; }
        public int InWorkDealsCount { get; set; }
        public int AwaitingPaymentDealsCount { get; set; }
        public int PreparingToShipDealsCount { get; set; }
        public int InTransitDealsCount { get; set; }
        public int ReadyForExtraditionDealsCount { get; set; }
        public int IssuedDealsCount { get; set; }
        public int RequestReturnCount { get; set; }
        public int Total { get; set; }
    }
}
