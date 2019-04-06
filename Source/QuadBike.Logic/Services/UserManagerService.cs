using Microsoft.AspNetCore.Identity;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuadBike.Logic.Services
{
    public class UserManagerService : IUserManagerService
    {
        UserManager<Account> _userManager;
        SignInManager<Account> _signInManager;
        IQuadBikeContext _quadBikeContext;

        public UserManagerService(UserManager<Account> userManager, SignInManager<Account> signInManager, IQuadBikeContext quadBikeContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _quadBikeContext = quadBikeContext;
        }

        public Task<IdentityResult> CreateAccount(RegisterViewModel model, string password)
        {
            Account user = new Account { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber };
            var res = _userManager.CreateAsync(user, password = model.Password);
            if (res.Result.Succeeded)
            {
                _signInManager.SignInAsync(user, false);
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