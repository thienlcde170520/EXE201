using EXE201.Commons.Models;
using EXE201.Services.Hubs;
using EXE201.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Services.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly UserManager<User> _userManager;

        private static Dictionary<string, Notification> _notificationsCache = new Dictionary<string, Notification>();

        public NotificationService(IHubContext<NotificationHub> hubContext, UserManager<User> userManager)
        {
            _hubContext = hubContext;
            _userManager = userManager;
        }

        public async Task SendNotificationToUser(string userId, string title, string content, string url)
        {
            var notification = new Notification(title, content, url);

            _notificationsCache[notification.Title] = notification;

            await _hubContext.Clients.User(userId).SendAsync("ReceiveMessage", notification);
        }

        public async Task SendNotificationToAll(string title, string content, string url)
        {
            var notification = new Notification(title, content, url);

            _notificationsCache[notification.Title] = notification;

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", notification);
        }

        public async Task SendNotificationToAdmin(string title, string content, string url)
        {
            var notification = new Notification(title, content, url);

            _notificationsCache[notification.Title] = notification;

            await _hubContext.Clients.Group("Admin").SendAsync("ReceiveMessage", notification);
        }

        public async Task SendNotificationToStaff(string title, string content, string url)
        {
            var notification = new Notification(title, content, url);

            _notificationsCache[notification.Title] = notification;

            await _hubContext.Clients.Group("Staff").SendAsync("ReceiveMessage", notification);

            // Send updated count
            await _hubContext.Clients.Group("Staff").SendAsync("UpdateNotificationCount", _notificationsCache.Count);
        }

        public async Task UpdateNotificationStatus(string userId, string notificationTitle)
        {
            if (_notificationsCache.ContainsKey(notificationTitle))
            {
                var notification = _notificationsCache[notificationTitle];

                notification.Status = "Seen";

                await _hubContext.Clients.User(userId).SendAsync("UpdateNotificationStatus", notificationTitle, "Seen");
            }
        }
    }
}
