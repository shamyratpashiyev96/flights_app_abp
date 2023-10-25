using Volo.Abp.Modularity;

namespace FlightsApp;

[DependsOn(
    typeof(FlightsAppApplicationModule),
    typeof(FlightsAppDomainTestModule)
    )]
public class FlightsAppApplicationTestModule : AbpModule
{

}
