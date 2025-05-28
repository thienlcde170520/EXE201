using EXE201.Commons.Data;
using EXE201.Commons.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serenity_Solution.Models;

namespace Serenity_Solution.Controllers
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public TestController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("DASS21")]
        public IActionResult DASS21()
        {
            var model = new DASSTestModel();
            return View(model);
        }

        [HttpPost]
        [Route("DASS21")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DASS21(DASSTestModel model)
        {
            if (ModelState.IsValid)
            {
                // Tính toán điểm số
                model.CalculateScores();

                // Lưu kết quả nếu người dùng đã đăng nhập
                if (User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.GetUserAsync(User);
                    model.UserId = user.Id;
                    // Lưu vào database nếu cần
                }

                // Chuyển đến trang kết quả
                return RedirectToAction("DASS21Result", new
                {
                    depression = model.DepressionScore,
                    anxiety = model.AnxietyScore,
                    stress = model.StressScore,
                    depressionLevel = model.DepressionLevel,
                    anxietyLevel = model.AnxietyLevel,
                    stressLevel = model.StressLevel
                });
            }

            return View(model);
        }

        [HttpGet]
        [Route("DASS21Result")]
        public IActionResult DASS21Result(
            int depression,
            int anxiety,
            int stress,
            string depressionLevel,
            string anxietyLevel,
            string stressLevel)
        {
            ViewData["DepressionScore"] = depression;
            ViewData["AnxietyScore"] = anxiety;
            ViewData["StressScore"] = stress;
            ViewData["DepressionLevel"] = depressionLevel;
            ViewData["AnxietyLevel"] = anxietyLevel;
            ViewData["StressLevel"] = stressLevel;

            return View();
        }
    }
}
