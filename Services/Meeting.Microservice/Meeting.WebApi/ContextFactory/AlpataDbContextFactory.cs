using Meeting.Dal.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Meeting.WebApi.ContextFactory
{
    public class AlpataDbContextFactory:IDesignTimeDbContextFactory<AlpataDbContext>
    {
        public AlpataDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<AlpataDbContext>()
                .UseSqlServer(configuration.GetConnectionString("AlpataDbContext"), prj => prj.MigrationsAssembly("Meeting.Dal"));
            return new AlpataDbContext(builder.Options);
        }    

    }
}
