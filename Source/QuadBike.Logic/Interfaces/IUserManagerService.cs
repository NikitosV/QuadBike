using Microsoft.AspNetCore.Identity;
using QuadBike.Model.Entities;
using QuadBike.Model.ViewModel.AccountViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuadBike.Logic.Interfaces
{
    public interface IUserManagerService
    {
        Task<IdentityResult> CreateAccount(RegisterViewModel model, string password);
        Task<SignInResult> LogInAccount(string email, string password, bool check);
        Task LogOffAccount();
    }
}
