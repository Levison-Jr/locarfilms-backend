using LocaFilms.Contexts;
using LocaFilms.Models;
using LocaFilms.Repository;
using LocaFilms.Services;
using LocaFilms.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LocaFilms.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                string connectionString = configuration.GetConnectionString("SQLCONNSTR_MainConnection") ??
                    throw new InvalidOperationException("Connection string 'MainConnection' indefinida.");

                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<IRentalRepository, RentalRepository>();
            services.AddScoped<IRentalService, RentalService>();
    
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<AspNetUserManager<UserModel>>();
            services.AddScoped<SignInManager<UserModel>>();

            services.AddAutoMapper(typeof(Program));
        }
    }
}