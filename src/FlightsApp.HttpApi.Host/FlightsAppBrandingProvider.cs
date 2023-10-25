using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FlightsApp;

[Dependency(ReplaceServices = true)]
public class FlightsAppBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FlightsApp";
}
