﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.DataProvider.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual SimpleUser SimpleUser { get; set; }
        public virtual Provider Provider { get; set; }
    }
}