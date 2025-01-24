using LocaFilms.Extensions;
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

            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddRateLimiterServices();

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

            app.UseRateLimiter();

            app.MapControllers();

            await app.CreateRolesAsync();
            await app.CreateDefaultUserAsync(builder.Configuration);

            app.Run();
        }
    }
}
