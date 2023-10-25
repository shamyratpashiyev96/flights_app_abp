using FlightsApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FlightsApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FlightsAppController : AbpControllerBase
{
    protected FlightsAppController()
    {
        LocalizationResource = typeof(FlightsAppResource);
    }
}
