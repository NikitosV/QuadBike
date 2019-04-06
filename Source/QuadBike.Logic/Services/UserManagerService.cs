using Microsoft.AspNetCore.Identity;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.AccountViewModels;
using System;
using System.Threading.Tasks;

namespace QuadBike.Logic.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly IAccountRepository _accountRepository;

        public UserManagerService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IdentityResult> CreateAccount(RegisterViewModel model)
        {
            var res = await _accountRepository.CreateAccount(new Account { Email = model.Email, UserName = model.Email, PhoneNumber = model.PhoneNumber }, model.Password);
            if (res != null)
                return res;
            return new IdentityResult();
        }

        public async Task<SignInResult> LogInAccount(LoginViewModel model)
        {
            var res = await _accountRepository.LogInAccount(model.Email, model.Password, model.RememberMe);
            return res;
        }

        public async Task LogOffAccount()
        {
            await _accountRepository.LogOffAccount();
        }
    }
}