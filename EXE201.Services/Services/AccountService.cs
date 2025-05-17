using EXE201.Commons.Models;
using EXE201.Repository.Interfaces;
using EXE201.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly INotificationService _notificationService;
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository, INotificationService notificationService)
        {
            _accountRepository = accountRepository;
            _notificationService = notificationService;
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _accountRepository.GetUserByIdAsync(userId);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _accountRepository.GetUserByEmailAsync(email);
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _accountRepository.GetAllUsersAsync();
        }
        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _accountRepository.UpdateUserAsync(user);
        }

        public async Task<IdentityResult> DeleteUserAsync(User user)
        {
            return await _accountRepository.DeleteUserAsync(user);
        }

        public async Task<IdentityResult> RegisterAsync(User user, string password)
        {
            return await _accountRepository.RegisterAsync(user, password);
        }

        public async Task<SignInResult> LoginAsync(string email, string password)
        {
            return await _accountRepository.LoginAsync(email, password);
        }

        public async Task LogoutAsync()
        {
            await _accountRepository.LogoutAsync();
        }

        public async Task<string> GetCurrentUserIdAsync()
        {
            return await _accountRepository.GetCurrentUserId();
        }
        public async Task<Customer?> GetCurrentCustomerAsync()
        {
            var userId = await GetCurrentUserIdAsync();
            if (string.IsNullOrEmpty(userId)) return null;

            var user = await GetUserByIdAsync(userId);

            // Check if it's a Customer
            if (user is Customer customer)
            {
                return customer;
            }

            return null;
        }
    }
}
