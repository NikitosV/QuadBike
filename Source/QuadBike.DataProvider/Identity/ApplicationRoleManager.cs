using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuadBike.DataProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        //public ApplicationRoleManager(IRoleStore<ApplicationRole> store) : base(store)
        //{

        //}
        public ApplicationRoleManager(IRoleStore<ApplicationRole> store, IEnumerable<IRoleValidator<ApplicationRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<ApplicationRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
