using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using QuadBike.DataProvider.Interfaces;
using QuadBike.Model.Context;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuadBike.DataProvider.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private UserManager<Account> _userManager;
        private SignInManager<Account> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private IQuadBikeContext _db;

        public AccountRepository(UserManager<Account> userManager, SignInManager<Account> signInManager, RoleManager<IdentityRole> roleManager, QuadBikeContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _db = db;
        }

        public async Task<IdentityResult> CreateAccount(Account model, string password)                   // create account
        {
            var res = await _userManager.CreateAsync(model, password);
            if (res.Succeeded)
            {
                //await _signInManager.SignInAsync(model, false);
                await _userManager.AddToRoleAsync(model, "user");
                return res;
            }
            else
            {
                return new IdentityResult();
            }
        }

        public Task<SignInResult> LogInAccount(string email, string password, bool check)                  // log in
        {
            var res = _signInManager.PasswordSignInAsync(email, password, check, false);
            return res;
        }

        public Task LogOffAccount()                                             // log off
        {
            var res = _signInManager.SignOutAsync();
            return res;
        }

        public IList<IdentityRole> ShowListOfRoles()                            // list of roles
        {
            var res = _roleManager.Roles.ToList();
            return res;
        }

        public Task<IdentityResult> CreateRole(string name)                        // create role
        {
            if (!string.IsNullOrEmpty(name))
            {
                var res = _roleManager.CreateAsync(new IdentityRole(name));
                return res;
            }
            return null;
        }

        public Task<IdentityRole> FindByIdRole(string id)                  // find id role
        {
            var res = _roleManager.FindByIdAsync(id);
            return res;
        }

        public Task<IdentityResult> DeleteRole(IdentityRole role)        // delete by role
        {
            if (role != null)
            {
                var result = _roleManager.DeleteAsync(role);
                return result;
            }
            return null;
        }

        public Task<IdentityResult> DeleteAccount(Account account)        // delete by role
        {
            if (account != null)
            {
                var result = _userManager.DeleteAsync(account);
                return result;
            }
            return null;
        }

        public IEnumerable<Account> ShowListUsers()                             // list of users
        {
            return _db.Accounts;
        }

        public IEnumerable<Account> ShowUserInfoById(string accountId)                             // list of users
        {
            var res = _userManager.Users.ToList().Where(x => x.Id == accountId);
            return res;
        }

        public Task<Account> GetUserById(string userId)                     // get user by id
        {
            var account = _userManager.FindByIdAsync(userId);
            return account;
        }

        public Task<IList<string>> GetRolesOfUser(Account account)           // get roles of user
        {
            var res = _userManager.GetRolesAsync(account);
            return res;
        }

        public Task<IList<string>> GetRolesByAccount(string userId)       // get roles of user by Account
        {
            var account = _userManager.FindByIdAsync(userId);
            // получем список ролей пользователя
            var res = _userManager.GetRolesAsync(account.Result);
            return res;
        }

        public Task<IdentityResult> AddToRole(string userId, IEnumerable<string> rol)
        {
            var account = _userManager.FindByIdAsync(userId);
            var res = _userManager.AddToRolesAsync(account.Result, rol);
            return res;
        }

        public Task<IdentityResult> RemovedFromRoles(string userId, IEnumerable<string> remRol)
        {
            var account = _userManager.FindByIdAsync(userId);
            var res = _userManager.RemoveFromRolesAsync(account.Result, remRol);
            return res;
        }

        public Task<Account> GetUserByName(string userName)                     // get user by name
        {
            var account = _userManager.FindByEmailAsync(userName);
            return account;
        }

        public Task<IdentityResult> UpdateAccount(Account account)
        {
            var res = _userManager.UpdateAsync(account);
            return res;
        }

        public IdentityRole GetRoleProvider()
        {
            var res = _roleManager.FindByNameAsync("provider").Result;
            return res;
        }

        public List<Account> AllProviderByRoleName(string roleName)
        {
            var res = _userManager.GetUsersInRoleAsync(roleName);
            return res.Result.ToList();
        }

        public List<Account> GetProviderOfBike(string bikeId)
        {
            var res = _db.Accounts.Where(a => a.Id.Equals(bikeId)).ToList();
            return res;
        }

        public List<Account> GetProviderOfTrip(string tripId)
        {
            var res = _db.Accounts.Where(a => a.Id.Equals(tripId)).ToList();
            return res;
        }

        public Task<string> GenerateEmailConfirmationTokenAsync(Account model)
        {
            return _userManager.GenerateEmailConfirmationTokenAsync(model);
        }

        public Task<IdentityResult> ConfirmEmailAsync(Account account, string code)
        {
            return _userManager.ConfirmEmailAsync(account, code);
        }

        public Task<bool> IsEmailConfirmedAsync(Account account)
        {
            return _userManager.IsEmailConfirmedAsync(account);
        }
    }
}