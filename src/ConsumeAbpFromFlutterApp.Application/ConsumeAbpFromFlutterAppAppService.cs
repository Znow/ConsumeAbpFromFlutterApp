using System;
using System.Collections.Generic;
using System.Text;
using ConsumeAbpFromFlutterApp.Localization;
using Volo.Abp.Application.Services;

namespace ConsumeAbpFromFlutterApp
{
    /* Inherit your application services from this class.
     */
    public abstract class ConsumeAbpFromFlutterAppAppService : ApplicationService
    {
        protected ConsumeAbpFromFlutterAppAppService()
        {
            LocalizationResource = typeof(ConsumeAbpFromFlutterAppResource);
        }
    }
}
