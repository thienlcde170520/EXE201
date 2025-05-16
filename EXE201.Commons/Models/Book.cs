using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Title { get; set; }
        [StringLength(500, ErrorMessage = "Description can't exceed 500 characters.")]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(0.01, 99999.99, ErrorMessage = "Price must be between 0.01 and 99,999.99.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }
        [Required]
        public int stock_quantity { get; set; }
        [Required]
        public string cover_image_url { get; set; }
        [Required]
        public int category_id { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public virtual ICollection<BookRating> BookRatings { get; set; } = new List<BookRating>();
    }
}
