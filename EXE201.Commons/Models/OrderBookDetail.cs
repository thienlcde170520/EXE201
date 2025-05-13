using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class OrderBookDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderID { get; set; }
        [Required]
        public int BookID { get; set; }
        [Required]
        [Range(1, 10)]
        public int quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }

        // Navigation Properties
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }

        [ForeignKey("BookId")]
        public virtual Book? Book { get; set; }
    }
}
