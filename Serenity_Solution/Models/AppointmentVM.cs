using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Serenity_Solution.Models
{
    public class AppointmentVM
    {
        public int Id { get; set; }
        public string? Client_ID { get; set; }
        public string? Psychologist_ID { get; set; }
        public DateTime Scheduled_time { get; set; }
        [StringLength(50)]
        public string? Status { get; set; } // Booked, confirmed, Canceled
        public string? Notes { get; set; }
        public DateTime Created_at { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; } = 0;
    }
}
