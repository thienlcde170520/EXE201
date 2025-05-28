using Microsoft.AspNetCore.Mvc;
using Serenity_Solution.Models;

namespace Serenity_Solution.Controllers
{
    public class PodcastController : Controller
    {
        private static List<PodcastViewModel> _podcasts = new List<PodcastViewModel>
        {
            new PodcastViewModel
            {
                Id = 1,
                Title = "Viết chữa lành",
                Description = "Viết là một hình thức chữa lành tuyệt vời, giúp bạn giải tỏa cảm xúc và suy nghĩ của mình. Hãy cùng chúng tôi khám phá cách viết có thể trở thành liệu pháp tâm lý hiệu quả.",
                ImageUrl = "/image/podcast/Chua_Lanh.jfif",
                AudioUrl = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-1.mp3",
                Author = "TS. Nguyễn Văn A",
                Duration = "25:30",
                Category = "Thiền & Chánh niệm",
                Rating = 4.8,
                RatingCount = 125
            },
            new PodcastViewModel
            {
                Id = 2,
                Title = "Giải pháp A không thể giải quyết vấn đề B",
                Description = "Trong cuộc sống, chúng ta thường tìm kiếm những giải pháp đơn giản cho những vấn đề phức tạp. Podcast này sẽ giúp bạn hiểu tại sao một số giải pháp không hiệu quả và làm thế nào để tìm ra phương pháp phù hợp.",
                ImageUrl = "/image/podcast/solution.jfif",
                AudioUrl = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-2.mp3",
                Author = "ThS. Trần Thị B",
                Duration = "32:15",
                Category = "Tâm lý & Cảm xúc",
                Rating = 4.5,
                RatingCount = 98
            },
            new PodcastViewModel
            {
                Id = 3,
                Title = "Những dấu hiệu cho thấy bạn đang vượt qua khó khăn",
                Description = "Mỗi người đều có những giai đoạn khó khăn trong cuộc sống. Podcast này sẽ giúp bạn nhận ra những dấu hiệu cho thấy bạn đang tiến bộ và vượt qua những thử thách của mình.",
                ImageUrl = "/image/podcast/be_tac.jfif",
                AudioUrl = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-3.mp3",
                Author = "PGS.TS. Lê Văn C",
                Duration = "28:45",
                Category = "Trò chuyện chữa lành",
                Rating = 4.7,
                RatingCount = 142
            },
            new PodcastViewModel
            {
                Id = 4,
                Title = "Tìm đến chữa lành nhưng vẫn bế tắc",
                Description = "Có những lúc chúng ta tìm đến các phương pháp chữa lành tâm lý nhưng vẫn cảm thấy bế tắc. Podcast này sẽ phân tích lý do tại sao điều này xảy ra và cách vượt qua.",
                ImageUrl = "/image/podcast/Chua_Lanh.jfif",
                AudioUrl = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-4.mp3",
                Author = "TS. Hoàng Minh D",
                Duration = "35:10",
                Category = "Tâm lý & Cảm xúc",
                Rating = 4.9,
                RatingCount = 205
            },
            new PodcastViewModel
            {
                Id = 5,
                Title = "Những lời minh triết cuộc sống",
                Description = "Khám phá những lời minh triết về cuộc sống từ các triết gia và nhà tâm lý học nổi tiếng, giúp bạn có cái nhìn sâu sắc hơn về cuộc sống.",
                ImageUrl = "/image/podcast/live_ur_way.jfif",
                AudioUrl = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-5.mp3",
                Author = "ThS. Trương Văn E",
                Duration = "22:40",
                Category = "Phát triển bản thân",
                Rating = 4.6,
                RatingCount = 168
            },
            new PodcastViewModel
            {
                Id = 6,
                Title = "Sống một cuộc đời không hối tiếc",
                Description = "Làm thế nào để sống một cuộc đời không có sự hối tiếc? Podcast này sẽ chia sẻ những nguyên tắc và bài học quý giá để bạn có thể sống trọn vẹn mỗi ngày.",
                ImageUrl = "/image/podcast/no-regrets-life.jpg",
                AudioUrl = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-6.mp3",
                Author = "TS. Nguyễn Thị F",
                Duration = "29:55",
                Category = "Phát triển bản thân",
                Rating = 4.8,
                RatingCount = 183
            },
            new PodcastViewModel
            {
                Id = 7,
                Title = "Hãy đồng hành cùng người mình thương",
                Description = "Tình yêu không chỉ là cảm xúc, mà còn là sự đồng hành và hỗ trợ. Podcast này sẽ giúp bạn hiểu cách để thực sự đồng hành cùng người mình thương trong những lúc khó khăn.",
                ImageUrl = "/image/podcast/support-loved-ones.jfif",
                AudioUrl = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-7.mp3",
                Author = "PGS. Trần Văn G",
                Duration = "31:20",
                Category = "Yêu thương & Kết nối",
                Rating = 4.7,
                RatingCount = 156
            },
            new PodcastViewModel
            {
                Id = 8,
                Title = "Thay vì bằng khoán thì hãy thử làm điều mới",
                Description = "Đôi khi, chúng ta cần thay đổi góc nhìn và thử những điều mới mẻ để tìm ra giải pháp cho vấn đề của mình. Podcast này sẽ khám phá tầm quan trọng của sự đổi mới trong cuộc sống.",
                ImageUrl = "/image/podcast/try-new-things.jpg",
                AudioUrl = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-8.mp3",
                Author = "TS. Phạm Văn H",
                Duration = "27:15",
                Category = "Phát triển bản thân",
                Rating = 4.5,
                RatingCount = 132
            },
            new PodcastViewModel
            {
                Id = 9,
                Title = "Những hướng dẫn cuộc đời",
                Description = "Cuộc đời không có sẵn hướng dẫn, nhưng chúng ta có thể học hỏi từ kinh nghiệm của người khác. Podcast này tập hợp những lời khuyên và hướng dẫn quý giá cho cuộc sống.",
                ImageUrl = "/image/podcast/life-guidance.jpg",
                AudioUrl = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-9.mp3",
                Author = "ThS. Lê Thị I",
                Duration = "33:40",
                Category = "Phát triển bản thân",
                Rating = 4.6,
                RatingCount = 175
            },
            new PodcastViewModel
            {
                Id = 10,
                Title = "All The Light We Cannot See",
                Description = "Một podcast sâu sắc về những điều tích cực mà chúng ta không nhìn thấy trong cuộc sống hàng ngày. Hãy học cách nhận ra và trân trọng những điều nhỏ bé nhưng ý nghĩa.",
                ImageUrl = "/image/podcast/unseen-light.jpg",
                AudioUrl = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-10.mp3",
                Author = "PGS.TS. Nguyễn Văn J",
                Duration = "26:50",
                Category = "Thiền & Chánh niệm",
                Rating = 4.9,
                RatingCount = 210
            },
            new PodcastViewModel
            {
                Id = 11,
                Title = "Hãy trồng theo cách mình muốn",
                Description = "Podcast này so sánh cuộc sống với việc trồng cây. Bạn sẽ gặt hái được những gì bạn gieo trồng. Hãy cùng khám phá cách 'trồng' cuộc sống theo cách bạn mong muốn.",
                ImageUrl = "/image/podcast/plant-your-life.jfif",
                AudioUrl = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-11.mp3",
                Author = "TS. Trần Văn K",
                Duration = "30:25",
                Category = "Phát triển bản thân",
                Rating = 4.7,
                RatingCount = 158
            },
            new PodcastViewModel
            {
                Id = 12,
                Title = "Những hướng dẫn của bạn",
                Description = "Mỗi người đều có những hướng dẫn riêng trong cuộc sống. Podcast này sẽ giúp bạn khám phá và lắng nghe tiếng nói bên trong bản thân để tìm ra con đường phù hợp nhất.",
                ImageUrl = "/image/podcast/loi_mon_life.jfif",
                AudioUrl = "https://www.soundhelix.com/examples/mp3/SoundHelix-Song-12.mp3",
                Author = "ThS. Phạm Thị L",
                Duration = "28:30",
                Category = "Thiền & Chánh niệm",
                Rating = 4.8,
                RatingCount = 187
            }
        };

        public IActionResult Index(string category = null, int page = 1, string search = null)
        {
            int pageSize = 8;
            var query = _podcasts.AsQueryable();

            // Filter by category if provided
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
            }

            // Filter by search term if provided
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p =>
                    p.Title.Contains(search, System.StringComparison.OrdinalIgnoreCase) ||
                    p.Description.Contains(search, System.StringComparison.OrdinalIgnoreCase) ||
                    p.Author.Contains(search, System.StringComparison.OrdinalIgnoreCase));
            }

            // Get distinct categories for filter tags
            ViewBag.Categories = _podcasts.Select(p => p.Category).Distinct().ToList();

            // Get total count for pagination
            int totalItems = query.Count();
            int totalPages = (int)System.Math.Ceiling(totalItems / (double)pageSize);

            // Apply pagination
            var podcasts = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Pagination data for view
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentCategory = category;
            ViewBag.CurrentSearch = search;

            return View(podcasts);
        }

        public IActionResult Detail(int id = 1)
        {
            var podcast = _podcasts.FirstOrDefault(p => p.Id == id) ?? _podcasts.First();

            // Get related podcasts (same category but different ID)
            var relatedPodcasts = _podcasts
                .Where(p => p.Id != podcast.Id && p.Category == podcast.Category)
                .Take(4)
                .ToList();

            // If not enough related podcasts in the same category, add some from other categories
            if (relatedPodcasts.Count < 4)
            {
                var additionalPodcasts = _podcasts
                    .Where(p => p.Id != podcast.Id && p.Category != podcast.Category)
                    .Take(4 - relatedPodcasts.Count)
                    .ToList();

                relatedPodcasts.AddRange(additionalPodcasts);
            }

            ViewBag.RelatedPodcasts = relatedPodcasts;

            return View(podcast);
        }
    }
}
