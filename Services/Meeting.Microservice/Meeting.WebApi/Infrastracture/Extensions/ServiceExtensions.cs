using Meeting.Dal.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Meeting.WebApi.Infrastracture.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration) => 
            services.AddDbContext<AlpataDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AlpataDbContext")));
    }
}
