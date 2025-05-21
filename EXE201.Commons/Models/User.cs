using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        //public string Email {  get; set; } = string.Empty;

        public string Phone {  get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string? ProfilePicture { get; set; } 

        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; } = new List<IdentityUserRole<string>>();
        public virtual ICollection<PodcastRating> PodcastRatings { get; set; } = new List<PodcastRating>();
        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

        public virtual string GetInfo() => $"{Name} ({Email})";
    }
}
