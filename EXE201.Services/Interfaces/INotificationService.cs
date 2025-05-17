using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Services.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationToUser(string userId, string title, string content, string url);
        Task SendNotificationToAll(string title, string content, string url);
        Task SendNotificationToAdmin(string title, string content, string url);
        Task SendNotificationToStaff(string title, string content, string url);
        Task UpdateNotificationStatus(string userId, string notificationTitle);
    }
}
