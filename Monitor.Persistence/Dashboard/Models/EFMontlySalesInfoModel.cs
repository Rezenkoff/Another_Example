using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Monitor.Persistence.Dashboard.Models
{
    [Table("MontlySalesInfo")]
    public class EFMontlySalesInfoModel
    {
        public int Id { get; set; }
        public short Year { get; set; }
        public short Month { get; set; }
        public decimal PlannedSalesSumm { get; set; }
        public decimal ActualSalesSumm { get; set; }
    }
}