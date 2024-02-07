using Meeting.Dal.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace Meeting.Dal.Extensions;

public static class DependencyInjection
{
    //public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    //{
    //    //services.AddDbContext<AlpataDbContext>(options =>
    //    //{
    //    //    options.UseSqlServer(configuration.GetConnectionString("AlpataDbContext"),
    //    //        sqlServerOptionsAction: sqlOptions =>
    //    //        {
    //    //            sqlOptions.EnableRetryOnFailure(
    //    //                maxRetryCount: 5,
    //    //                maxRetryDelay: TimeSpan.FromSeconds(30),
    //    //                errorNumbersToAdd: null);
    //    //        })
    //    //        .UseLazyLoadingProxies()
    //    //        .LogTo(Console.WriteLine, LogLevel.Information);
    //    //});

    //    //return services;
    //}
}