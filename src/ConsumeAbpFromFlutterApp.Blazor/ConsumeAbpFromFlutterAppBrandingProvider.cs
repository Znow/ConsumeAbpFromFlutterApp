using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ConsumeAbpFromFlutterApp.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class ConsumeAbpFromFlutterAppBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ConsumeAbpFromFlutterApp";
    }
}
