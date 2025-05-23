using Microsoft.AspNetCore.Mvc;

namespace Serenity_Solution.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
