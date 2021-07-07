namespace Monitor.Application.Dashboard.Models
{
    public class LostCallRateModel
    {
        public decimal HourRate { get; set; }
        public decimal DayRate { get; set; }
        public decimal MonthRate { get; set; }
        public decimal PreviousMonthRate { get; set; }
    }
}
