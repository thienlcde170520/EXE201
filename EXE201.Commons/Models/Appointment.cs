using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Client_ID { get; set; }
        [Required]
        public string? Psychologist_ID { get; set; }
        [Required]
        public DateTime Scheduled_time { get; set; }
        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Booked"; // Booked, confirmed, Canceled
        public string Notes { get; set; }
        [Required]
        public DateTime Created_at { get; set; }

    }
}
