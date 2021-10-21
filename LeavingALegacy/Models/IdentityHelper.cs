using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace LeavingALegacy.Models
{
    public static class IdentityHelper
    {
        public const string Admin = "Admin";
        public const string Member = "Member";

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetService<RoleManager<IdentityRole>>();

            foreach (string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task CreateDefaultUser(IServiceProvider provider, string role)
        {
            var userManager = provider.GetService<UserManager<IdentityUser>>();

            // if no users are present, make the default user
            int numUsers = (await userManager.GetUsersInRoleAsync(role)).Count;
            if (numUsers == 0) // If no users are in the specified role
            {
                var defaultUser = new IdentityUser()
                {
                    Email = "manager@website.org",
                    UserName = "Admin"
                };

                await userManager.CreateAsync(defaultUser, "Programmer11!");

                await userManager.AddToRoleAsync(defaultUser, role);
            }
        }
    }
}