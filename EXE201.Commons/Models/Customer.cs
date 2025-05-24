using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class Customer 
    {
        
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
        
       
    }
}
