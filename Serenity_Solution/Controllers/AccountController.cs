using EXE201.Commons.Data;
using EXE201.Commons.Models;
using EXE201.Services.Interfaces;
using Humanizer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Serenity_Solution.Models;
using System.Security.Claims;

namespace Serenity_Solution.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;

        private readonly IEmailService _emailService;
        public AccountController(UserManager<User> userManager, IAccountService accountService, IEmailService emailService, SignInManager<User> signInManager,
            ApplicationDbContext context)
        {
            _accountService = accountService;
            _userManager = userManager;
            _emailService = emailService;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Random rnd = new Random();
            var NameDefault = "user_" + rnd.Next(1, 1000001);

            var user = new Customer
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = NameDefault,
                Name = NameDefault,
                PhoneNumber = model.Phone,
                DateOfBirth = DateTime.Now,
                Gender = model.Gender,
                Address = model.Address,
                ProfilePictureUrl = model.ProfilePictureUrl
            };

            var result = await _accountService.RegisterAsync(user, model.Password);

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Registration successful! Please login.";
                return RedirectToAction("Login");
            }

            // Hiển thị lỗi nếu đăng ký thất bại
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Demo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //var result = await _accountService.LoginAsync(viewModel.Email.Trim(), viewModel.Password.Trim());
                
                var result = await _accountService.LoginAsync(
                    viewModel.Email.Trim(),
                    viewModel.Password.Trim(),
                    viewModel.RememberMe
                );
                if (result.Succeeded)
                {                   
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Login");
        }
        // Display all users
        public async Task<IActionResult> Index()
        {
            var users = await _accountService.GetAllUsersAsync();
            return View(users);
        }

        // Display user details
        public async Task<IActionResult> Details(string id)
        {
            var id1 = await _accountService.GetCurrentUserIdAsync();
            var user = await _accountService.GetUserByIdAsync(id1);
            if (user == null) return NotFound();
            return View(user);
        }

        // Edit user - Get (Load user data into form)
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _accountService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // Edit user - Post (Save changes)
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            if (!ModelState.IsValid) return View(user);

            var result = await _accountService.UpdateUserAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // Delete user - Get confirmation page
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _accountService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // Delete user - Post (Confirm delete)
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _accountService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            var result = await _accountService.DeleteUserAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View("Error");
        }
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CustomerProfile()
        {
            var user = await _userManager.GetUserAsync(User) as Customer; // Ép kiểu về Customer
            if (user == null) return NotFound();

            var customerViewModel = new CustomerViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Address = user.Address,
                ProfilePictureUrl = user.ProfilePictureUrl,
                LoyaltyPoints = user.LoyaltyPoints,
                MembershipType = user.MembershipType,
                JoinDate = user.JoinDate,
            };

            return View(customerViewModel);
        }

        [Authorize(Roles = "Psychologist")]
        public async Task<IActionResult> PsychologistProfile()
        {
            var user = await _userManager.GetUserAsync(User) as Psychologist;
            if (user == null)
                return RedirectToAction("Login", "Account");


            // Lấy lương gần nhất của nhân viên dựa theo tháng mới nhất
            //var salary = await _context.Salaries
            //    .Where(s => s.StaffId == user.Id)
            //    .OrderByDescending(s => s.PayDate)
            //    .FirstOrDefaultAsync();


            var model = new PsychologistViewModel
            {
                Name = user.Name,
                Email = user.Email,
                
            };

            return View(model);
        }
        public async Task<IActionResult> SendTestEmail()
        {
            await _emailService.SendEmailAsync("mylpdde180283@fpt.edu.vn", "Test Email", "<h1>Hello from ASP.NET</h1>");
            return Content("Email Sent Successfully!");
        }

        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

            await _signInManager.RefreshSignInAsync(user); // Keep user logged in
            TempData["SuccessMessage"] = "Password changed successfully!";
            if (await _userManager.IsInRoleAsync(user, "Customer"))
            {
                return RedirectToAction("CustomerProfile", "Account"); // Redirect to profile page
            }
            return RedirectToAction("StaffProfile", "Account"); // Redirect to profile page

        }

        public async Task<IActionResult> Forgot()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Forgot(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["ErrorMessage"] = "No account found with this email.";
                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

            await _emailService.SendEmailAsync(user.Email, "Reset Password", $"Click here to reset your password: <a href='{resetLink}'>Reset Password</a>");

            TempData["SuccessMessage"] = "Password reset link has been sent to your email.";
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            {
                TempData["ErrorMessage"] = "Invalid password reset request.";
                return RedirectToAction("Login");
            }

            var model = new ResetPasswordViewModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["ErrorMessage"] = "No account found with this email.";
                return RedirectToAction("Forgot");
            }

            var resetResult = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (!resetResult.Succeeded)
            {
                foreach (var error in resetResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(model);
            }

            TempData["SuccessMessage"] = "Password has been reset successfully! You can now log in.";
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> ProfileTest()
        {
            var userId = await _accountService.GetCurrentUserIdAsync();
            var user = await _accountService.GetUserByIdAsync(userId);
            if (user == null) return NotFound();
            return View(user);
        }
    }
}
