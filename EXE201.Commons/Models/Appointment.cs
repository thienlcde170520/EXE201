using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public string? Client_ID { get; set; }
        public string? Psychologist_ID { get; set; }
        [Required]
        public DateTime Scheduled_time { get; set; }
        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Booked"; // Booked, confirmed, Canceled
        public string? Notes { get; set; }
        [Required]
        public DateTime Created_at { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; } = 0;

        [ForeignKey("Client_ID")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("Psychologist_ID")]
        public virtual Psychologist? Psychologist { get; set; }

    }
}
