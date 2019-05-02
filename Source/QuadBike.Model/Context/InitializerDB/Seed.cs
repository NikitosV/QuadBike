using Microsoft.AspNetCore.Identity;
using QuadBike.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuadBike.Model.Context.Initializer
{
    public static class Seed
    {
        public static async Task Initialize(UserManager<Account> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            string moderEmail = "moder@moder.by";
            string userEmail = "user1@tut.by";
            string providerEmail = "provider1@tut.by";
            string password = "657F660n_";

            if (await _roleManager.FindByNameAsync("moderator") == null)
            {
                await _roleManager.CreateAsync(new IdentityRole("moderator"));
            }
            if (await _roleManager.FindByNameAsync("user") == null)
            {
                await _roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await _roleManager.FindByNameAsync("provider") == null)
            {
                await _roleManager.CreateAsync(new IdentityRole("provider"));
            }
            if (await _userManager.FindByNameAsync(moderEmail) == null)
            {
                Account moder = new Account { Email = moderEmail, UserName = moderEmail };
                IdentityResult result = await _userManager.CreateAsync(moder, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(moder, "moderator");
                }
            }
            if (await _userManager.FindByNameAsync(userEmail) == null)
            {
                Account user = new Account { Email = userEmail, UserName = userEmail };
                IdentityResult result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                }
            }
            if (await _userManager.FindByNameAsync(providerEmail) == null)
            {
                Account provider = new Account { Email = providerEmail, UserName = providerEmail };
                IdentityResult result = await _userManager.CreateAsync(provider, password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(provider, "provider");
                }
            }
        }
    }
}
