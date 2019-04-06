using Microsoft.AspNetCore.Identity;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuadBike.DataProvider.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private UserManager<Account> _userManager;
        private SignInManager<Account> _signInManager;

        public AccountRepository(QuadBikeContext context, UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<IdentityResult> CreateAccount(Account model, string password)
        {
            var res = _userManager.CreateAsync(model, password);
            if (res.Result.Succeeded)
            {
                _signInManager.SignInAsync(model, false);
                return res;
            }
            else
            {
                return null;
            }
        }

        public Task<SignInResult> LogInAccount(string email, string password, bool check)
        {
            var res = _signInManager.PasswordSignInAsync(email, password, check, false);
            return res;
        }

        public Task LogOffAccount()
        {
            var res = _signInManager.SignOutAsync();
            return res;
        }
    }
}
