using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class PsychTest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime created_at { get; set; } = DateTime.UtcNow;
        public virtual ICollection<UserTestResult> UserTestResults { get; set; } = new List<UserTestResult>();
        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
