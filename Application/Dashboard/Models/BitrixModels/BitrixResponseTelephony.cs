using System;
using System.Collections.Generic;
using System.Text;

namespace Monitor.Application.Dashboard.Models.BitrixModels
{
    public class BitrixResponseTelephony
    {
        public List<TelephonyModel> Result { get; set; }
        public int Total { get; set; }
        public BitrixResponseTimeModel Time { get; set; }
    }
}
