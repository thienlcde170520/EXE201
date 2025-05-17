using System.ComponentModel.DataAnnotations;

namespace Serenity_Solution.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
