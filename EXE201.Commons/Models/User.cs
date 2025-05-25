using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string? ProfilePictureUrl { get; set; }

        //customer
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; } = "Unspecified"; // Male, Female, Other
        public string? CertificateUrl { get; set; }
        [NotMapped]
        public bool? DoctorCertificateUrl { get; set; } = false; // Indicates if the user has a doctor certificate

        //psychologist
        public string? Degree { get; set; }
        public string? Description { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public string? Major { get; set; } = string.Empty; // Major in psychology or related field

        public double BaBalance { get; set; } = 0; // Balance for in-app purchases or services

        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; } = new List<IdentityUserRole<string>>();
        public virtual ICollection<PodcastRating> PodcastRatings { get; set; } = new List<PodcastRating>();
        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

        //customer
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<UserTestResult> UserTestResults { get; set; } = new List<UserTestResult>();

        //psychologist

    }
}
