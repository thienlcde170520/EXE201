using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class Customer : User
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; } = "Unspecified"; // Male, Female, Other
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public int LoyaltyPoints { get; set; } = 0;
        public string MembershipType
        {
            get
            {
                if (LoyaltyPoints >= 1000) return "Platinum";
                if (LoyaltyPoints >= 500) return "Gold";
                if (LoyaltyPoints >= 100) return "Silver";
                return "Bronze";
            }
        }
        public DateTime JoinDate { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<UserTestResult> UserTestResults { get; set; } = new List<UserTestResult>();
       
    }
}
