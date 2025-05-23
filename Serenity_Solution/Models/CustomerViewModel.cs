namespace Serenity_Solution.Models
{
    public class CustomerViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? CertificateUrl { get; set; }

    }
}
