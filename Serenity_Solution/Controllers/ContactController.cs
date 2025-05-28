using CloudinaryDotNet;
using EXE201.Commons.Data;
using EXE201.Commons.Models;
using EXE201.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serenity_Solution.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Serenity_Solution.Controllers
{
    public class ContactController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;
        public ContactController(UserManager<User> userManager, IAccountService accountService, IEmailService emailService, SignInManager<User> signInManager,
            ApplicationDbContext context)
        {
            _accountService = accountService;
            _userManager = userManager;
            _emailService = emailService;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> AllRequest(int page = 1, int pageSize = 5)
        {
            var ListRequest = await _context.Contacts
                .Include(c => c.User)
                .ToListAsync();

            if (ListRequest.Count == 0)
            {
                TempData["NoWSDetail"] = true;
                return RedirectToAction("Index", "Manager");
            }

            var model = ListRequest
                .Select(s => new ContactViewModel
                {
                    UserId = s.UserId,
                    Name = s.Name,
                    Email = s.Email,
                    Content = s.Content,
                })
                .ToList();
            int totalUsers = model.Count();
            var pagedUsers = model.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalUsers / pageSize);
            ViewBag.CurrentPage = page;

            return View(pagedUsers);
        }
        [HttpGet]
        public async Task<IActionResult> Resolve(string UserId)
        {
            var ListRequest = await _context.Contacts
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.UserId == UserId);
            return View(ListRequest);


        }
    }
}
