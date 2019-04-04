using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Model.Entities
{
    public class Account : IdentityUser
    {
        public virtual MyUser MyUser { get; set; }
        public virtual Provider Provider { get; set; }
    }
}
