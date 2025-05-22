using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class Podcast
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Title { get; set; }
        [StringLength(500, ErrorMessage = "Description can't exceed 500 characters.")]
        public string Description { get; set; }
        public string? audio_url { get; set; }
        public string? thumbnail_url { get; set; }
        
        [Required]
        public string? CreateBy { get; set; }
        /*[Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } = 0;*/
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        [ForeignKey("CreateBy")]
        public virtual User? User { get; set; }
        public virtual ICollection<PodcastRating> PodcastRatings { get; set; } = new List<PodcastRating>();
    }
}
