using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int PsychTestId { get; set; }
        [ForeignKey("PsychTestId")]
        public virtual PsychTest? PsychTest { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;
    }
}
