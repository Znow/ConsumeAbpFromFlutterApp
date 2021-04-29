using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ConsumeAbpFromFlutterApp.EntityFrameworkCore
{
    [DependsOn(
        typeof(ConsumeAbpFromFlutterAppEntityFrameworkCoreModule)
        )]
    public class ConsumeAbpFromFlutterAppEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ConsumeAbpFromFlutterAppMigrationsDbContext>();
        }
    }
}
