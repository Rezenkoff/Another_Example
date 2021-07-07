using System.ComponentModel.DataAnnotations.Schema;

namespace Monitor.Persistence.Dashboard.Models
{
    [Table("LostCallRate")]
    public class EFLostCallRateModel
    {
        public int Id { get; set; }
        public short Year { get; set; }
        public short Month { get; set; }
        public decimal LostCallRate { get; set; }
    }
}
