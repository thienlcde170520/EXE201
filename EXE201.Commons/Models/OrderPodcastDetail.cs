using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class OrderPodcastDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int PodcastID { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }

        // Navigation Properties
        [ForeignKey("OrderID")]
        public virtual Order? Order { get; set; }

        [ForeignKey("PodcastID")]
        public virtual Podcast? Podcast { get; set; }
    }
}
