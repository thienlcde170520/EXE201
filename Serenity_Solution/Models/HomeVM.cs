using EXE201.Commons.Models;

namespace Serenity_Solution.Models
{
    public class HomeVM
    {
        public List<Podcast>? Podcasts { get; set; }
        public Contact? Contact { get; set; }
        public IList<User>? Doctors { get; set; }
        public string? currentUser { get; set; }
    }
}