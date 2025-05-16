using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string? CustomerId { get; set; } // ID khách hàng đặt hàng
        public int? PodcastID { get; set; } // ID podcast đã đặt hàng
        public DateTime OrderDate { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("PodcastID")]
        public virtual Podcast? Podcast { get; set; }

    }
}
