using LocaFilms.Contexts;
using LocaFilms.Extensions;
using LocaFilms.Models;
using LocaFilms.Services.Identity.Configurations;
using LocaFilms.Services.Identity.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LocaFilms
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddCors(options => 
            {
                options.AddPolicy(name: "DevMode",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection"));
            });

            builder.Services.AddApplicationServices(builder.Configuration);

            builder.Services.AddDefaultIdentity<UserModel>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<CustomIdentityErrorDescriber>();

            var securityKeySettings = builder.Configuration.GetSection("JwtOptions:SecurityKey").Value;
            var jwtOptionsSettings = builder.Configuration.GetSection(nameof(JwtOptions));

            if (string.IsNullOrEmpty(securityKeySettings))
            {
                throw new SecurityTokenException("A JWT Security Key n�o est� configurada.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKeySettings));

            builder.Services.Configure<JwtOptions>(options =>
            {
                options.Issuer = jwtOptionsSettings[nameof(JwtOptions.Issuer)] ?? "invalidIssuer";
                options.Audience = jwtOptionsSettings[nameof(JwtOptions.Audience)] ?? "invalidAudience";
                options.AccessTokenExpiration = int.Parse(jwtOptionsSettings[nameof(JwtOptions.AccessTokenExpiration)] ?? "0");
                options.RefreshTokenExpiration = int.Parse(jwtOptionsSettings[nameof(JwtOptions.RefreshTokenExpiration)] ?? "0");
                options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            });

            builder.Services.AddAuthentication(options =>
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
                    ValidIssuer = builder.Configuration.GetSection("JwtOptions:Issuer").Value,

                    ValidateAudience = true,
                    ValidAudience = builder.Configuration.GetSection("JwtOptions:Audience").Value,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,

                    RequireExpirationTime = true,
                    ValidateLifetime = true,

                    // Distor��o/Atraso do timer/rel�gio utilizado na valida��o de hor�rios
                    // Ex.: Valida��o do tempo de expira��o de tokens
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.isEmployee, policy => 
                    policy.RequireRole(Roles.Admin, Roles.Employee));
            });

            builder.Services.Configure<IdentityOptions>(options =>
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

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("DevMode");

            app.UseExceptionHandler("/error");
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            await app.CreateRolesAsync();
            await app.CreateDefaultUserAsync(builder.Configuration);

            app.Run();
        }
    }
}
