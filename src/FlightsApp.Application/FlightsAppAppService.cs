using System;
using System.Collections.Generic;
using System.Text;
using FlightsApp.Localization;
using Volo.Abp.Application.Services;

namespace FlightsApp;

/* Inherit your application services from this class.
 */
public abstract class FlightsAppAppService : ApplicationService
{
    protected FlightsAppAppService()
    {
        LocalizationResource = typeof(FlightsAppResource);
    }
}
