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

        List<IdentityRole> ShowListOfRoles();
        Task<IdentityResult> CreateRole(string name);
        Task<IdentityRole> FindByIdRole(string id);
        Task<IdentityResult> DeleteRole(IdentityRole role);
        List<Account> ShowListUsers();

        Task<Account> GetUserById(string userId);
        Task<IList<string>> GetRolesOfUser(Account account);
        Task<IList<string>> GetRolesByAccount(string userId);
        Task<IdentityResult> AddToRole(string userId, IEnumerable<string> rol);
        Task<IdentityResult> RemovedFromRoles(string userId, IEnumerable<string> remRol);
    }
}