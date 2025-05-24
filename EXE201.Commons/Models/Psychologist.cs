using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class Psychologist : User
    {
        [Required]
        public string Degree { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public string? ProfilePictureUrl { get; set; } = string.Empty;
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
