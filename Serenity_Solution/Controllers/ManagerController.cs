using CloudinaryDotNet;
using EXE201.Commons.Data;
using EXE201.Commons.Models;
using EXE201.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Serenity_Solution.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        private readonly Cloudinary _cloudinary;
        private readonly IAccountService _accountService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;
        public ManagerController(UserManager<User> userManager, IAccountService accountService, IEmailService emailService, SignInManager<User> signInManager,
            ApplicationDbContext context, Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
            _accountService = accountService;
            _userManager = userManager;
            _emailService = emailService;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
