using System.Text;
using LocaFilms.Contexts;
using LocaFilms.Models;
using LocaFilms.Services.Identity.Configurations;
using LocaFilms.Services.Identity.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace LocaFilms.Extensions
{
    public static class IdentitySetupExtensions
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<UserModel>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<CustomIdentityErrorDescriber>();

            var securityKeySettings = configuration.GetSection("JwtOptions:SecurityKey").Value;

            if (string.IsNullOrEmpty(securityKeySettings))
            {
                throw new SecurityTokenException("JWT Security Key desconfigurada.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKeySettings));

            services.Configure<JwtOptions>(options =>
            {
                configuration.GetSection(nameof(JwtOptions)).Bind(options);
                options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetSection("JwtOptions:Issuer").Value,

                    ValidateAudience = true,
                    ValidAudience = configuration.GetSection("JwtOptions:Audience").Value,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,

                    RequireExpirationTime = true,
                    ValidateLifetime = true,

                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.isEmployee, policy => 
                    policy.RequireRole(Roles.Admin, Roles.Employee));
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // User settings.
                options.User.RequireUniqueEmail = true;
            });
        }
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
