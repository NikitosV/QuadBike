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
                await _signInManager.SignInAsync(model, false);
                await _userManager.AddToRoleAsync(model, "user");
                return res;
            }
            else
            {
                return null;
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

        public List<Account> ShowListUsers()                             // list of users
        {
           var res = _userManager.Users.ToList();
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
    }
}
