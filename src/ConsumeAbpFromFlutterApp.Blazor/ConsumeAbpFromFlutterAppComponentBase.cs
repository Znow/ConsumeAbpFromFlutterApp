using ConsumeAbpFromFlutterApp.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ConsumeAbpFromFlutterApp.Blazor
{
    public abstract class ConsumeAbpFromFlutterAppComponentBase : AbpComponentBase
    {
        protected ConsumeAbpFromFlutterAppComponentBase()
        {
            LocalizationResource = typeof(ConsumeAbpFromFlutterAppResource);
        }
    }
}
