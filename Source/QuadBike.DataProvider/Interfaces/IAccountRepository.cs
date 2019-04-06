using Microsoft.AspNetCore.Identity;
using QuadBike.Model.Entities;
using System.Threading.Tasks;

namespace QuadBike.DataProvider.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateAccount(Account model, string password);
        Task<SignInResult> LogInAccount(string email, string password, bool check);
        Task LogOffAccount();
    }
}