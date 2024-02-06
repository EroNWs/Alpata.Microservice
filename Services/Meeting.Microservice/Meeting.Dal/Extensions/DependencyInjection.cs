using Meeting.Dal.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meeting.Dal.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AlpataDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("AlpataDbContext.Meeting"),
                options => options.EnableRetryOnFailure(
                    10,
                    TimeSpan.FromSeconds(10),
                    null));
            options.UseLazyLoadingProxies();
        });

        return services;
    }
}
