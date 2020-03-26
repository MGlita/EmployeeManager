using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Roles
{
    public static class RolesCommandHandler
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        
            if(!await roleManager.RoleExistsAsync(Roles.HR))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.HR));
            }
            if (!await roleManager.RoleExistsAsync(Roles.Marketing))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Marketing));
            }
            if (!await roleManager.RoleExistsAsync(Roles.Sales))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Sales));
            }
            if (!await roleManager.RoleExistsAsync(Roles.TopManagement))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.TopManagement));
            }
            if (!await roleManager.RoleExistsAsync(Roles.IT))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.IT));
            }
            if (!await roleManager.RoleExistsAsync(Roles.CustomerService))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.CustomerService));
            }
        }
    }
}
