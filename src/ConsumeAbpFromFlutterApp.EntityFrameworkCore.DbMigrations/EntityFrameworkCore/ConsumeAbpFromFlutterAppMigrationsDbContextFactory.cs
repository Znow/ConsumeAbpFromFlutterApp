using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ConsumeAbpFromFlutterApp.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class ConsumeAbpFromFlutterAppMigrationsDbContextFactory : IDesignTimeDbContextFactory<ConsumeAbpFromFlutterAppMigrationsDbContext>
    {
        public ConsumeAbpFromFlutterAppMigrationsDbContext CreateDbContext(string[] args)
        {
            ConsumeAbpFromFlutterAppEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ConsumeAbpFromFlutterAppMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new ConsumeAbpFromFlutterAppMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ConsumeAbpFromFlutterApp.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
