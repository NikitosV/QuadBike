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
        Task<IdentityResult> CreateAccount(RegisterViewModel model);
        Task<SignInResult> LogInAccount(LoginViewModel model);
        Task LogOffAccount();
    }
}
