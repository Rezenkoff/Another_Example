using System;

namespace Monitor.Application.Dashboard.Models
{
    public class SessionVisitModel
    {
        public int SessionByDay { get; set; }
        public int SessionByMonth { get; set; }
        public int SessionByDayWeekAgo { get; set; }


        public Exception ExceptionInfo { get; set; }
    }
}
