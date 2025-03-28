using LocaFilms.Contexts;
using LocaFilms.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

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
                options.AddPolicy(name: "dev",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .WithExposedHeaders(HeaderNames.WWWAuthenticate);
                    });

                options.AddPolicy(name: "Production",
                    policy =>
                    {
                        policy.WithOrigins("https://*.levisonjr-app.site")
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .WithMethods("GET", "POST", "PUT", "DELETE")
                            .WithHeaders(HeaderNames.ContentType, HeaderNames.Accept, HeaderNames.Authorization)
                            .WithExposedHeaders(HeaderNames.WWWAuthenticate);
                    });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddRateLimiterServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("dev");
            }
            else
            {
                app.UseCors("Production");
            }

            app.UseExceptionHandler("/error");
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRateLimiter();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();

                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        await context.Database.MigrateAsync();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao aplicar migrations. Tentativa {i + 1}: {ex.Message}");
                        await Task.Delay(5000);
                    }
                }
            }


            await app.CreateRolesAsync();
            await app.CreateDefaultUserAsync(builder.Configuration);

            app.Run();
        }
    }
}
