using System;

namespace Monitor.Application.Dashboard.Models.BitrixModels
{
    public class BitrixResponseTimeModel
    {
        public double Start { get; set; }
        public double Finish { get; set; }
        public double Duration { get; set; }
        public double Processing { get; set; }
        public DateTime Date_start { get; set; }
        public DateTime Date_finish { get; set; }
    }
}
