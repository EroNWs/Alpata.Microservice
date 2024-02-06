using Microsoft.Extensions.Configuration;
using Meeting.Dal.EF.Repositories;
using Meeting.Dal.EF.Seeds;
using Microsoft.Extensions.DependencyInjection;

namespace Meeting.Dal.EF.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddEFCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMeetingRepository, MeetingRepository>();

        MeetingPlanningSeed.SeedAsync(configuration).GetAwaiter().GetResult();

        return services;
    }




}
