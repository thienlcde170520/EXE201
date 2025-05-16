using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class BookRating
    {
        [Key]
        public int Id { get; set; }
        public string UserID { get; set; }
        public int BookID { get; set; }
        [Range(1, 5)]
        public int score { get; set; }

        //Relation
        [ForeignKey("UserID")]
        public virtual User? User { get; set; }
        [ForeignKey("BookID")]
        public virtual Book? Book { get; set; }
    }
}
