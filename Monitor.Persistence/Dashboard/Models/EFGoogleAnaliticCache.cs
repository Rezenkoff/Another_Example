using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monitor.Persistence.Dashboard.Models
{
    [Table("GoogleAnalitCache")]
    public class EFGoogleAnaliticCache
    {
        public int Id { get; set; }
        public int SessionByDay { get; set; }
        public int SessionByMonth { get; set; }
        public int MaxSessionCount10Day { get; set; }
        public DateTime LastUpdateByDay { get; set; }
        public DateTime LastUpdateByMonth { get; set; }
        public int SessionByDayWeekAgo { get; set; }
    }
}
