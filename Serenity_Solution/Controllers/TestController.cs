using Microsoft.AspNetCore.Mvc;
using EXE201.Commons.Data;
using Serenity_Solution.Models;
using Microsoft.AspNetCore.Identity;
using EXE201.Commons.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

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
        public async Task<IActionResult> DASS21(DASSTestModel model, string AnsweredQuestions, int AnsweredCount)
        {
            if (ModelState.IsValid)
            {
                // Chuyển đổi chuỗi JSON thành danh sách bool
                if (!string.IsNullOrEmpty(AnsweredQuestions))
                {
                    model.AnsweredQuestions = JsonSerializer.Deserialize<List<bool>>(AnsweredQuestions);
                }
                
                model.AnsweredCount = AnsweredCount;
                
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
                    stressLevel = model.StressLevel,
                    answeredCount = model.AnsweredCount,
                    answeredQuestions = AnsweredQuestions
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
            string stressLevel,
            int answeredCount,
            string answeredQuestions)
        {
            // Ensure we have values even if they weren't provided
            depression = Math.Max(0, depression);
            anxiety = Math.Max(0, anxiety);
            stress = Math.Max(0, stress);
            
            depressionLevel = string.IsNullOrEmpty(depressionLevel) ? "Bình thường" : depressionLevel;
            anxietyLevel = string.IsNullOrEmpty(anxietyLevel) ? "Bình thường" : anxietyLevel;
            stressLevel = string.IsNullOrEmpty(stressLevel) ? "Bình thường" : stressLevel;
            
            // Set the values in ViewData
            ViewData["DepressionScore"] = depression;
            ViewData["AnxietyScore"] = anxiety;
            ViewData["StressScore"] = stress;
            ViewData["DepressionLevel"] = depressionLevel;
            ViewData["AnxietyLevel"] = anxietyLevel;
            ViewData["StressLevel"] = stressLevel;
            
            // Thêm dữ liệu về câu hỏi đã trả lời
            ViewData["AnsweredCount"] = answeredCount;
            ViewData["AnsweredQuestions"] = answeredQuestions ?? "[]"; // Provide a default if null
            ViewData["TotalQuestions"] = 21;
            
            return View();
        }
    }
} 