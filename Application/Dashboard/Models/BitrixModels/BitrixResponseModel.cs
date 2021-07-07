using System.Collections.Generic;

namespace Monitor.Application.Dashboard.Models.BitrixModels
{
    public class BitrixResponseModel
    {
        public List<DealModel> Result { get; set; }
        public int Total { get; set; }
        public BitrixResponseTimeModel Time { get; set; }
    }

    public class BitrixResponseModelNext
    {
        public List<DealModel> Result { get; set; }
        public int Total { get; set; }
        public int? Next { get; set; }
        public BitrixResponseTimeModel Time { get; set; }
    }
}
