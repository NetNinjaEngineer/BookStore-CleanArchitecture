using BookStore.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Identity.Services;
public sealed class SeedRoleService(RoleManager<IdentityRole> roleManager)
{
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    public async Task SeedRoles()
    {
        await SeedRoles([Roles.Admin, Roles.User]);
    }

    private async Task SeedRoles(IEnumerable<string> roles)
    {
        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var identityRole = new IdentityRole { Name = role };
                await _roleManager.CreateAsync(identityRole);
            }
        }
    }
}
