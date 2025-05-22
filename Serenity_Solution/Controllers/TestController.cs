using Microsoft.AspNetCore.Mvc;

namespace Serenity_Solution.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
