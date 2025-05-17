using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Models
{
    public class Notification
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? Url { get; set; }

        public string Status { get; set; }

        public Notification() { }
        public Notification(string title, string content, string url = null)
        {
            Title = title;
            Content = content;
            CreatedAt = DateTime.Now;
            Url = url;
            Status = "Unseen";
        }

        public override string ToString()
        {
            return $"Title: {Title}\nContent: {Content}\nCreated At: {CreatedAt}\nUrl: {Url}\nStatus: {Status}";
        }
    }
}
