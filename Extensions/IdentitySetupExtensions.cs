using LocaFilms.Models;
using LocaFilms.Services.Identity.Constants;
using Microsoft.AspNetCore.Identity;

namespace LocaFilms.Extensions
{
    public static class IdentitySetupExtensions
    {
        public static async Task CreateRolesAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string[] roles = [Roles.Admin, Roles.Employee, Roles.Customer];

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task CreateDefaultUserAsync(this WebApplication app, IConfiguration configuration)
        {
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<AspNetUserManager<UserModel>>();

                string? email = configuration.GetValue<string>("ADMIN_EMAIL");
                string? password = configuration.GetValue<string>("ADMIN_PASSWORD");

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                    throw new MissingFieldException("Admin Default: Email e/ou Password não configurados como variáveis de ambiente");

                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new UserModel()
                    {
                        Email = email,
                        UserName = email,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                        await userManager.AddToRoleAsync(user, Roles.Admin);
                }
                
            }
        }
    }
}
