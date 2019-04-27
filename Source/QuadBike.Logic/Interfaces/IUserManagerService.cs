using Microsoft.AspNetCore.Identity;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.AccountViewModels;
using QuadBike.Model.ViewModel.ModerViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuadBike.Logic.Interfaces
{
    public interface IUserManagerService
    {
        Task<IdentityResult> CreateAccount(RegisterViewModel model);
        Task<SignInResult> LogInAccount(LoginViewModel model);
        Task LogOffAccount();

        IList<IdentityRole> ShowListOfRoles();
        //Task<IList<IdentityRole>> ShowListOfRoles();
        Task<IdentityResult> CreateRole(string name);
        Task<IdentityRole> FindByIdRole(string id);
        Task<Account> GetUserByName(string userName);
        Task<IdentityResult> DeleteRole(IdentityRole role);
        List<Account> ShowListUsers();

        Task<Account> GetUserById(string userId);
        ChangeRoleViewModel Edit(string userId);
        Task<IList<string>> GetRolesByAccount(string userId);
        Task<IdentityResult> AddToRole(string userId, IEnumerable<string> rol);
        Task<IdentityResult> RemovedFromRoles(string userId, IEnumerable<string> remRol);
        Task<IdentityResult> UpdateAccount(Account account);
        IEnumerable<Account> ShowUserInfoById(string accountId);
    }
}
