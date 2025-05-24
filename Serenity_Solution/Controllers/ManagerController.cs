using CloudinaryDotNet;
using EXE201.Commons.Data;
using EXE201.Commons.Models;
using EXE201.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serenity_Solution.Models;

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
            bool noDetails = TempData["NoWSDetail"] as bool? ?? false;
            ViewBag.NoWSDetail = noDetails;
            return View();
        }
        public async Task<IActionResult> UpgradeRequest(int page = 1, int pageSize = 5)
        {
            var users = await _userManager.GetUsersInRoleAsync("Customer");

            var customers = users.OfType<User>() // Lọc ra danh sách Customer
                .Where(c => c.CertificateUrl != null) // Lọc ra những người có yêu cầu nâng cấp
                .ToList();

            if(customers.Count == 0)
            {
                TempData["NoWSDetail"] = true;
                return RedirectToAction("Index");
            }

            var CustomerList = customers
                 .Select(s => new CustomerViewModel
                 {
                     Id = s.Id,
                     FullName = s.Name,
                     Email = s.Email,
                     CertificateUrl = s.CertificateUrl
                 })
                 .ToList();
            int totalUsers = CustomerList.Count();
            var pagedUsers = CustomerList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalUsers / pageSize);
            ViewBag.CurrentPage = page;
            // Gửi danh sách Staff kèm ID (dùng ViewBag nếu cần)
            ViewBag.StaffIds = customers.ToDictionary(s => s.Email, s => s.Id);

            return View(pagedUsers);

        }
        [HttpPost]
        public async Task<IActionResult> ApproveUpgrade(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                TempData["ErrorMessage"] = "Email không được để trống.";
                return RedirectToAction("UpgradeRequest");
            }

            // Tìm user theo email
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy user.";
                return RedirectToAction("UpgradeRequest");
            }

            // Kiểm tra user có đang ở role Customer không
            var isInCustomerRole = await _userManager.IsInRoleAsync(user, "Customer");
            if (!isInCustomerRole)
            {
                TempData["ErrorMessage"] = "User không phải là Customer hoặc đã được nâng cấp.";
                return RedirectToAction("UpgradeRequest");
            }

            // Remove role Customer
            var removeResult = await _userManager.RemoveFromRoleAsync(user, "Customer");
            if (!removeResult.Succeeded)
            {
                TempData["ErrorMessage"] = "Xóa role Customer thất bại.";
                return RedirectToAction("UpgradeRequest");
            }

            // Add role Psychologist
            var addResult = await _userManager.AddToRoleAsync(user, "Psychologist");
            if (!addResult.Succeeded)
            {
                TempData["ErrorMessage"] = "Thêm role Psychologist thất bại.";
                return RedirectToAction("UpgradeRequest");
            }

            TempData["SuccessMessage"] = $"Nâng cấp user {email} thành công.";
            await _emailService.SendEmailAsync(user.Email, "Nâng cấp thành công", "Bạn đã trở thành nhà tâm lý học của hệ thống chúng tôi!");

            return RedirectToAction("UpgradeRequest");
        }




        /*
        public async Task<IActionResult> ApproveUpgrade(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return NotFound();

            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Contains("Psychologist"))
            {
                TempData["Message"] = "Người dùng đã là Psychologist.";
                return RedirectToAction("UpgradeRequest");
            }

            // Remove old roles
            await _userManager.RemoveFromRolesAsync(user, roles);

            // Add new role
            await _userManager.AddToRoleAsync(user, "Psychologist");

            // Lấy Customer để lấy CertificateUrl chuyển cho Degree của PsychologistProfile
            var customer = await _context.Set<Customer>().FindAsync(user.Id);

            if (customer == null)
                return BadRequest("User không phải Customer.");

            // Tạo PsychologistProfile riêng
            var psychologistProfile = new Psychologist
            {
                Id = user.Id,
                Degree = customer.CertificateUrl ?? "Chưa có chứng chỉ"
            };

            await _userManager.UpdateAsync(psychologistProfile);
            await _context.SaveChangesAsync();

            await _emailService.SendEmailAsync(user.Email, "Nâng cấp thành công", "Bạn đã trở thành nhà tâm lý học của hệ thống chúng tôi!");

            return RedirectToAction("UpgradeRequest");
        }

        */




        [HttpPost]
        public async Task<IActionResult> RejectUpgrade(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                // Cập nhật trạng thái của người dùng
                var customer = user ;
                if (customer != null)
                {
                    customer.CertificateUrl = null;
                    await _userManager.UpdateAsync(user);
                }
                // Gửi email thông báo
                var subject = "Yêu cầu nâng cấp tài khoản đã bị từ chối";
                var message = "Rất tiếc, yêu cầu nâng cấp tài khoản của bạn đã bị từ chối.";
                await _emailService.SendEmailAsync(user.Email, subject, message);
                return RedirectToAction("UpgradeRequest");
            }
            return NotFound();
        }

        /*
        [HttpPost]
        public async Task<IActionResult> ApproveUpgrade(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var customers = await _userManager.FindByEmailAsync(email) as Customer;
            if (user != null)
            {
                // Cập nhật vai trò cho người dùng
                await _userManager.AddToRoleAsync(user, "Psychologist");
                await _userManager.RemoveFromRoleAsync(user, "Customer");
                // Cập nhật trạng thái của người dùng
                user.CertificateUrl = null;
                await _userManager.UpdateAsync(user);
                // Gửi email thông báo
                var subject = "Yêu cầu nâng cấp tài khoản đã được phê duyệt";
                var message = "Chúc mừng bạn đã trở thành một nhà tâm lý học!";
                await _emailService.SendEmailAsync(user.Email, subject, message);
                return RedirectToAction("UpgradeRequest");
            }
            return NotFound();
        }
        */


    }
}
