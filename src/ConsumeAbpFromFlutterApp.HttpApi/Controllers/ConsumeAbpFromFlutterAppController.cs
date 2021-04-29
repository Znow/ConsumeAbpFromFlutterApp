using ConsumeAbpFromFlutterApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ConsumeAbpFromFlutterApp.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ConsumeAbpFromFlutterAppController : AbpController
    {
        protected ConsumeAbpFromFlutterAppController()
        {
            LocalizationResource = typeof(ConsumeAbpFromFlutterAppResource);
        }
    }
}