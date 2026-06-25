using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ZenBlog.Persistence.Context
{
    // Design-time only: lets `dotnet ef` create/run migrations with the
    // Persistence project as startup, so the running API does not need to be stopped.
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(
                "server=ZIYABURAKYAYLA\\SQLEXPRESS;database=ZenBlogDb;integrated security=true;trustServerCertificate=true");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
