using Microsoft.AspNetCore.Identity;
using QuadBike.Logic.Interfaces;
using QuadBike.Model.Context;/////
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Logic.Services
{
    public class UserManagerService : IUserManagerService
    {
        UserManager<Account> _userManager;

        public UserManagerService(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }

        public void testcreate()
        {
            //TODO:_userManager.CreateAsync(); - it only test that its work
        }
    }
}