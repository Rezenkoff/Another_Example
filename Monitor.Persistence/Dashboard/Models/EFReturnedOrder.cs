using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Monitor.Persistence.Dashboard.Models
{
    [Table("ReturnedOrder")]
    public class EFReturnedOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Sum_Opportunity { get; set; }
        public double Sum_Opportunity_Tail { get; set; }
        public int Last_Next { get; set; }
        public int Total { get; set; }
        public int Category { get; set; }
        public DateTime DateQuery { get; set; }
    }
}
