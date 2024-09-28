using LocaFilms.Contexts;
using LocaFilms.Extensions;
using LocaFilms.Models;
using LocaFilms.Repository;
using LocaFilms.Services;
using LocaFilms.Services.Identity;
using LocaFilms.Services.Identity.Configurations;
using LocaFilms.Services.Identity.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace LocaFilms
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

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

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IMovieService, MovieService>();

            builder.Services.AddScoped<IRentalRepository, RentalRepository>();
            builder.Services.AddScoped<IRentalService, RentalService>();

            builder.Services.AddScoped<IIdentityService, IdentityService>();
            builder.Services.AddScoped<AspNetUserManager<UserModel>>();
            builder.Services.AddScoped<SignInManager<UserModel>>();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddDefaultIdentity<UserModel>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            var securityKeySettings = builder.Configuration.GetSection("JwtOptions:SecurityKey").Value;
            var jwtOptionsSettings = builder.Configuration.GetSection(nameof(JwtOptions));

            if (string.IsNullOrEmpty(securityKeySettings))
            {
                throw new SecurityTokenException("A JWT Security Key não está configurada.");
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

                    // Distorção/Atraso do timer/relógio utilizado na validação de horários
                    // Ex.: Validação do tempo de expiração de tokens
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
