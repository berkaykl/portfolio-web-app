using Microsoft.AspNetCore.Identity;

namespace Core_Portfolio.Data
{
    public static class SeedData
    {
        public static async Task SeedRoles(RoleManager<IdentityRole<int>> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole<int>("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole<int>("User"));
            }
        }
    }
}
