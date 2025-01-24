using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Primitives;
using System.Threading.RateLimiting;

namespace LocaFilms.Extensions
{
    public static class RateLimiterExtensions
    {
        public static void AddRateLimiterServices(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                {
                    var accessToken = httpContext.Features.Get<IAuthenticateResultFeature>()?
                                .AuthenticateResult?.Properties?
                                .GetTokenValue("access_token")?.ToString()
                                ?? string.Empty;

                    if (!StringValues.IsNullOrEmpty(accessToken))
                    {
                        return RateLimitPartition.GetFixedWindowLimiter(
                            partitionKey: accessToken,
                            factory: _ => new FixedWindowRateLimiterOptions
                            {
                                AutoReplenishment = true,
                                PermitLimit = 500,
                                QueueLimit = 0,
                                Window = TimeSpan.FromMinutes(10)
                            });
                    }

                    return RateLimitPartition.GetFixedWindowLimiter(
                            partitionKey: "Anonnymous",
                            factory: _ => new FixedWindowRateLimiterOptions
                            {
                                AutoReplenishment = true,
                                PermitLimit = 200,
                                QueueLimit = 0,
                                Window = TimeSpan.FromMinutes(10)
                            });
                });                
            });
        }
    }
}
