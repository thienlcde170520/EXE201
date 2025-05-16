using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class Comment
    {
        [Key]
        public int CommetId { get; set; }
        public string? CommentContent { get; set; }
        public DateTime DateComment { get; set; }



        //Foregin key
        public int? PodcastID { get; set; }
        public string? UserId { get; set; }
        public int? ParentCommentId { get; set; }

        //Relation
        [ForeignKey("PodcastID")]
        public virtual Podcast? Podcast { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        [ForeignKey("ParentCommentId")]

        public Comment? ParentComment { get; set; }
        // Navigation property
        public virtual ICollection<Comment> Replies { get; set; } = new List<Comment>();
    }
}
