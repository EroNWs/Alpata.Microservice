using Meeting.Business.Interfaces.Services;
using Meeting.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Meeting.Business.Extensions;

public static class DependencyInjection
{

    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IMeetingService, MeetingService>();

        return services;
    }



}
