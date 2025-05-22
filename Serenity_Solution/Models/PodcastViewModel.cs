namespace Serenity_Solution.Models
{
    public class PodcastViewModel
    {
        private int id {  get; set; }
        private string title { get; set; }
        private string description { get; set; }
        private string audio_url { get; set; }
        public string? thumbnail_url { get; set; }
    }
}
