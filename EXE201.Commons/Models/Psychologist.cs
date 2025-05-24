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
        //[Required]
        
        //public string? ProfilePictureUrl { get; set; } = string.Empty;
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
