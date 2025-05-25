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
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Rewrite;

namespace Serenity_Solution.Controllers
{
    public class AccountController : Controller
    {
        private readonly Cloudinary _cloudinary;
        private readonly IAccountService _accountService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;

        private readonly IEmailService _emailService;
        public AccountController(UserManager<User> userManager, IAccountService accountService, IEmailService emailService, SignInManager<User> signInManager,
            ApplicationDbContext context, Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
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

            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
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
                /*
                var roleResult = await _userManager.AddToRoleAsync(user, "Customer");
                if (!roleResult.Succeeded)
                {
                    // Nếu thất bại, xoá user vừa tạo để tránh user không có role
                    await _userManager.DeleteAsync(user);
                    foreach (var error in roleResult.Errors)
                    {
                        ModelState.AddModelError("", "Role assignment failed: " + error.Description);
                    }
                    return View(model);
                }
                */
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
                    var user = await _userManager.FindByEmailAsync(viewModel.Email.Trim());
                    if (user.Name == "System Admin")
                    {
                        return RedirectToAction("Index", "Manager");
                    }
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

        public async Task<IActionResult> EditPsychologist(string id)
        {
            var user = await _accountService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            var psychologist = user;  // Ép kiểu về Psychologist

            var viewModel = new PsychologistViewModel
            {
                Id = psychologist.Id,
                Name = psychologist.Name,
                Email = psychologist.Email,
                Phone = psychologist.PhoneNumber,
                Address = psychologist.Address,
                Description = psychologist.Description,
                Experience = psychologist.Experience,
                Price = psychologist.Price,
                ProfilePictureUrl = psychologist.ProfilePictureUrl,
                Major = psychologist.Major
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPsychologist(string id, PsychologistViewModel  model)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            if (!ModelState.IsValid) return View(model);

            var doctor = await _userManager.Users
                .OfType<User>() // Lọc User chỉ lấy Staff
                .FirstOrDefaultAsync(u => u.Id == id);

            if (doctor == null) return NotFound();

            doctor.Name = model.Name;
            doctor.Email = model.Email;
            doctor.PhoneNumber = model.Phone;
            doctor.Address = model.Address;
            doctor.Description = model.Description;
            doctor.Experience = model.Experience; // Giả sử Degree là URL của chứng chỉ
            doctor.Price = model.Price;
            doctor.Major = model.Major;


            if (model.ProfilePictureFile != null && model.ProfilePictureFile.Length > 0)
            {
                using var stream = model.ProfilePictureFile.OpenReadStream();

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(model.ProfilePictureFile.FileName, stream),
                    PublicId = $"profile_pictures/customer_{id}_{DateTime.UtcNow.Ticks}",
                    Folder = "profile_pictures"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    doctor.ProfilePictureUrl = uploadResult.SecureUrl.ToString();
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi khi tải ảnh đại diện lên Cloudinary.");
                    return View(model);
                }
            }
            var updateResult = await _userManager.UpdateAsync(doctor);

            if (updateResult.Succeeded)
            {
                return RedirectToAction(nameof(PsychologistProfile));
            }

            // Nếu có lỗi
            foreach (var error in updateResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);

        }

        // Edit user - Get (Load user data into form)
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _accountService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            var customer = user;  // Ép kiểu về Customer

            var viewModel = new EditCustomerViewModel
            {
                Id = customer.Id,
                FullName = customer.Name,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.PhoneNumber,
                Address = customer.Address,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender,
                ProfilePictureUrl = customer.ProfilePictureUrl
            };

            return View(viewModel);
        }

        // Edit user - Post (Save changes)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditCustomerViewModel model)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            if (!ModelState.IsValid) return View(model);

            var customer = await _userManager.Users
                .OfType<User>() // Lọc User chỉ lấy Staff
                .FirstOrDefaultAsync(u => u.Id == id);

            if (customer == null) return NotFound();

            customer.Name = model.FullName;
            customer.Email = model.Email;
            customer.PhoneNumber = model.Phone;
            customer.Address = model.Address;
            customer.DateOfBirth = model.DateOfBirth;
            customer.Gender = model.Gender;
            //customer.ProfilePictureUrl = model.ProfilePictureUrl;
            // Xử lý upload ảnh lên Cloudinary

            
            if (model.ProfilePictureFile != null && model.ProfilePictureFile.Length > 0)
            {
                using var stream = model.ProfilePictureFile.OpenReadStream();

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(model.ProfilePictureFile.FileName, stream),
                    PublicId = $"profile_pictures/customer_{id}_{DateTime.UtcNow.Ticks}",
                    Folder = "profile_pictures"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    customer.ProfilePictureUrl = uploadResult.SecureUrl.ToString();
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi khi tải ảnh đại diện lên Cloudinary.");
                    return View(model);
                }
            }
            


            var updateResult = await _userManager.UpdateAsync(customer);

            if (updateResult.Succeeded)
            {
                return RedirectToAction(nameof(CustomerProfile));
            }

            // Nếu có lỗi
            foreach (var error in updateResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
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
            var user = await _userManager.GetUserAsync(User) ; // Ép kiểu về Customer
            if (user == null) return NotFound();

            var customerViewModel = new CustomerViewModel
            {
                Id = user.Id,
                FullName = user.Name,
                Email = user.Email,
                Phone = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Address = user.Address,
                ProfilePictureUrl = user.ProfilePictureUrl,  
                CertificateUrl = user.CertificateUrl
            };

            return View(customerViewModel);
        }

        [Authorize(Roles = "Psychologist")]
        public async Task<IActionResult> PsychologistProfile()
        {
            var user = await _userManager.GetUserAsync(User) ;

            if (!await _userManager.IsInRoleAsync(user, "Psychologist"))
            {
                return RedirectToAction("Index", "Home");
            }

            var psychologist = await _context.ApplicationUsers
                .Include(p => p.Appointments)
                .FirstOrDefaultAsync(p => p.Id == user.Id);


            if (psychologist == null)
                {
                    return RedirectToAction("Index", "Home");
                }

            // map dữ liệu vào view model...


            var model = new PsychologistViewModel
            {
                Id = psychologist.Id,
                Name = psychologist.Name,
                Email = psychologist.Email,
                Degree = psychologist.CertificateUrl,
                Description = psychologist.Description,
                Address = user.Address,
                Experience = psychologist.Experience,
                Price = psychologist.Price,
                ProfilePictureUrl = psychologist.ProfilePictureUrl,
                Major = psychologist.Major,
                BaBalance = psychologist.BaBalance,
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

        [HttpGet]
        public IActionResult UpdateLevel(string id)
        {
            var model = new CertificateUploadViewModel
            {
                CustomerId = id
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLevel(CertificateUploadViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var customer = await _context.Customers.FindAsync(model.CustomerId);
            var user = await _accountService.GetUserByIdAsync(model.CustomerId);
            var customer = user ; // Ép kiểu về Customer 
            if (customer == null)
            {
                return NotFound();
            }

            if (model.CertificateFile != null && model.CertificateFile.Length > 0)
            {
                using var stream = model.CertificateFile.OpenReadStream();

                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(model.CertificateFile.FileName, stream),
                    PublicId = $"certificates/customer_{model.CustomerId}_{DateTime.UtcNow.Ticks}",
                    Folder = "certificates"
                };

                var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    ModelState.AddModelError("", $"Lỗi khi tải chứng chỉ lên Cloudinary: {uploadResult.Error?.Message}");
                }


                if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    customer.CertificateUrl = uploadResult.SecureUrl.ToString();
                    _context.Update(customer);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Chứng chỉ đã được tải lên thành công.";
                    return RedirectToAction("CustomerProfile", new { id = model.CustomerId });
                }

                ModelState.AddModelError("", "Lỗi khi tải chứng chỉ lên Cloudinary.");
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng chọn tệp chứng chỉ để tải lên.");
            }

            return View(model);
        }
    }
}
