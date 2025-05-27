using EXE201.Commons.Models;

namespace Serenity_Solution.Models
{
    public class DoctorDetailVM
    {
        public Contact? Contact { get; set; }
        public List<PsychologistViewModel>? DoctorVM { get; set; }
    }
}
