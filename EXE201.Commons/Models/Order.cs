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

        public string? AdminId { get; set; } // Nhân viên xử lý đơn hàng (nullable)

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending"; // Pending, Completed, Canceled

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("AdminId")]
        public virtual Admin? Admin { get; set; }

        public virtual ICollection<OrderPodcastDetail> OrderPodcastDetails { get; set; } = new List<OrderPodcastDetail>();
        public virtual ICollection<OrderBookDetail> OrderBookDetails { get; set; } = new List<OrderBookDetail>();

        public virtual Payment? Payment { get; set; }

        public string GetInfo()
        {
            return $"Order {Id} - {Status} - ${TotalAmount}";
        }
    }
}
