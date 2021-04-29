using ConsumeAbpFromFlutterApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ConsumeAbpFromFlutterApp.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ConsumeAbpFromFlutterAppEntityFrameworkCoreDbMigrationsModule),
        typeof(ConsumeAbpFromFlutterAppApplicationContractsModule)
        )]
    public class ConsumeAbpFromFlutterAppDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
