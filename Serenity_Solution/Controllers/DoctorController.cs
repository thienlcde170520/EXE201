using CloudinaryDotNet;
using EXE201.Commons.Data;
using EXE201.Commons.Models;
using EXE201.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Serenity_Solution.Controllers
{
    public class DoctorController : Controller
    {
        private readonly Cloudinary _cloudinary;
        private readonly IAccountService _accountService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;
        public DoctorController(UserManager<User> userManager, IAccountService accountService, IEmailService emailService, SignInManager<User> signInManager,
            ApplicationDbContext context, Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
            _accountService = accountService;
            _userManager = userManager;
            _emailService = emailService;
            _signInManager = signInManager;
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 3)
        {
            var users = await _userManager.GetUsersInRoleAsync("Psychologist");

            var doctors = users.OfType<User>() // Lọc ra danh sách Customer
                .Where(c => c.CertificateUrl != null) // Lọc ra những người có yêu cầu nâng cấp
                .ToList();

            if (doctors.Count == 0)
            {
                TempData["NoWSDetail"] = true;
                return RedirectToAction("Index","Home");
            }

            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
