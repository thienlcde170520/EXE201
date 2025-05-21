using Microsoft.AspNetCore.Mvc;

namespace Serenity_Solution.Controllers
{
    public class PodcastController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
