using EXE201.Commons.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Services.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;


        public NotificationHub(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public async Task SendNotification(string title, string content, string? url = null)
        {
            var notification = new Notification
            {
                Title = title,
                Content = content,
                Url = url,
                Status = "Unseen",
                CreatedAt = DateTime.UtcNow
            };

            await Clients.Group("Admin").SendAsync("ReceiveMessage", notification);
        }

        public async Task AddUserToAdminGroup(string userId)
        {
            if (await IsUserAdmin(userId)) // Now calling the async method
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Admin");
            }
        }

        public async Task AddUserToStaffGroup(string userId)
        {
            if (await IsUserStaff(userId)) // Now calling the async method
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Psychologist");
            }
        }

        private async Task<bool> IsUserAdmin(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false; // If user doesn't exist, return false
            }

            var roles = await _userManager.GetRolesAsync(user);
            return roles.Contains("Admin");
        }

        private async Task<bool> IsUserStaff(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false; // If user doesn't exist, return false
            }

            var roles = await _userManager.GetRolesAsync(user);
            return roles.Contains("Psychologist");
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier;

            await AddUserToAdminGroup(userId);

            await AddUserToStaffGroup(userId);

            await base.OnConnectedAsync();
        }
    }
}
