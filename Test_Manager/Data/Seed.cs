using Microsoft.AspNetCore.Identity;
using Test_Manager.Models;

namespace Test_Manager.Data;
public static class SeedRoles
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        string[] roleNames = { "Administrateur", "Gestionnaire", "User" };

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var adminUser = await userManager.FindByEmailAsync("admin@mail.com");
        if (adminUser != null)
        {
            await userManager.AddToRoleAsync(adminUser, "Administrateur");
        }
    }
}
