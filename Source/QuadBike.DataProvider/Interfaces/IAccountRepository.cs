using Microsoft.AspNetCore.Identity;
using QuadBike.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuadBike.DataProvider.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateAccount(Account model, string password);
        Task<SignInResult> LogInAccount(string email, string password, bool check);
        Task LogOffAccount();

        IList<IdentityRole> ShowListOfRoles();
        Task<IdentityResult> CreateRole(string name);
        Task<IdentityRole> FindByIdRole(string id);
        Task<Account> GetUserByName(string userName);
        Task<IdentityResult> DeleteRole(IdentityRole role);
        IEnumerable<Account> ShowListUsers();

        Task<Account> GetUserById(string userId);
        Task<IList<string>> GetRolesOfUser(Account account);
        Task<IList<string>> GetRolesByAccount(string userId);
        Task<IdentityResult> AddToRole(string userId, IEnumerable<string> rol);
        Task<IdentityResult> RemovedFromRoles(string userId, IEnumerable<string> remRol);
        Task<IdentityResult> UpdateAccount(Account account);
        IEnumerable<Account> ShowUserInfoById(string accountId);
        Task<IdentityResult> DeleteAccount(Account account);

        IdentityRole GetRoleProvider();
        List<Account> AllProviderByRoleName(string roleName);
        List<Account> GetProviderOfBike(string bikeId);
        List<Account> GetProviderOfTrip(string tripId);

        Task<string> GenerateEmailConfirmationTokenAsync(Account model);
        Task<IdentityResult> ConfirmEmailAsync(Account account, string code);
        Task<bool> IsEmailConfirmedAsync(Account account);
    }
}