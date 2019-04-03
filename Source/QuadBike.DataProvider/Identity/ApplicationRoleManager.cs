using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store) : base(store)
        {

        }
    }
}
