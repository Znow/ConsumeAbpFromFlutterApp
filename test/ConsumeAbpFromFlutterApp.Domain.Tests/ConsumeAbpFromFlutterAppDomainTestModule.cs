using ConsumeAbpFromFlutterApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ConsumeAbpFromFlutterApp
{
    [DependsOn(
        typeof(ConsumeAbpFromFlutterAppEntityFrameworkCoreTestModule)
        )]
    public class ConsumeAbpFromFlutterAppDomainTestModule : AbpModule
    {

    }
}