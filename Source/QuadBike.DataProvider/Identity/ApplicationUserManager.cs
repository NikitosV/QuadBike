using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QuadBike.DataProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        //public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        //{
        //}
        public ApplicationUserManager(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }
}
