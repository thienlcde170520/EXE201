using System.ComponentModel.DataAnnotations;

namespace Serenity_Solution.Models
{
    public class CertificateUploadViewModel
    {
        public string CustomerId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn tệp chứng chỉ.")]
        [Display(Name = "Chứng chỉ")]
        public IFormFile CertificateFile { get; set; }
    }

}
