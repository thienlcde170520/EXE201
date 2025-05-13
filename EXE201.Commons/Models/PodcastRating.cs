using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class PodcastRating
    {
        [Key]
        public int Id { get; set; }
        public string UserID { get; set; }
        public int PodcastID { get; set; }
        [Range(1, 5)]
        public int score { get; set; }

        //Relation
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("PodcastID")]
        public Podcast Podcast { get; set; }

    }
}
