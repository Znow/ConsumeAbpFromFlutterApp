using Volo.Abp.Modularity;

namespace ConsumeAbpFromFlutterApp
{
    [DependsOn(
        typeof(ConsumeAbpFromFlutterAppApplicationModule),
        typeof(ConsumeAbpFromFlutterAppDomainTestModule)
        )]
    public class ConsumeAbpFromFlutterAppApplicationTestModule : AbpModule
    {

    }
}