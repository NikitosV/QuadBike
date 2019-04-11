using Microsoft.AspNetCore.Identity;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.AccountViewModels;
using QuadBike.Model.ViewModel.ModerViewModels;
using System;
using System.Collections.Generic;
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

        public IList<IdentityRole> ShowListOfRoles()
        {
            var res = _accountRepository.ShowListOfRoles();
            return res;
        }

        public Task<IdentityResult> CreateRole(string name)
        {
            var res = _accountRepository.CreateRole(name);
            return res;
        }

        public Task<IdentityRole> FindByIdRole(string id)
        {
            var res = _accountRepository.FindByIdRole(id);
            return res;
        }

        public Task<IdentityResult> DeleteRole(IdentityRole role)
        {
           var res = _accountRepository.DeleteRole(role);
           return res;
        }

        public List<Account> ShowListUsers()
        {
            var res = _accountRepository.ShowListUsers();
            return res;
        }

        public Task<Account> GetUserById(string userId)
        {
            var res = _accountRepository.GetUserById(userId);
            return res;
        }

        public ChangeRoleViewModel Edit(string userId)
        {
            var account = _accountRepository.GetUserById(userId);
            if (account != null)
            {
                var userRoles = _accountRepository.GetRolesOfUser(account.Result);
                var allRoles = _accountRepository.ShowListOfRoles();

                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = account.Result.Id,
                    UserEmail = account.Result.Email,
                    UserRoles = userRoles.Result,
                    AllRoles = allRoles
                };
                return model;
            }
            return null;
        }

        public Task<IList<string>> GetRolesByAccount(string userId)
        {
            var res = _accountRepository.GetRolesByAccount(userId);
            return res;
        }

        public Task<IdentityResult> AddToRole(string userId, IEnumerable<string> rol)
        {
            var res = _accountRepository.AddToRole(userId, rol);
            return res;
        }

        public Task<IdentityResult> RemovedFromRoles(string userId, IEnumerable<string> remRol)
        {
            var res = _accountRepository.RemovedFromRoles(userId, remRol);
            return res;
        }
    }
}