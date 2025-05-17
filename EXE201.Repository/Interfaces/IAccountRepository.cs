using EXE201.Commons.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Repository.Interfaces
{
    public interface IAccountRepository : IGenericRepository<User>
    {
        Task<User> GetUserByIdAsync(string userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<User>> GetAllUsersAsync();
        Task<IdentityResult> UpdateUserAsync(User user);
        Task<IdentityResult> DeleteUserAsync(User user);
        Task<IdentityResult> RegisterAsync(User user, string password);
        Task<SignInResult> LoginAsync(string email, string password);
        Task LogoutAsync();
        Task<string> GetCurrentUserId();
    }
}
