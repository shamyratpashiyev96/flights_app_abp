using FlightsApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FlightsApp;

[DependsOn(
    typeof(FlightsAppEntityFrameworkCoreTestModule)
    )]
public class FlightsAppDomainTestModule : AbpModule
{

}
