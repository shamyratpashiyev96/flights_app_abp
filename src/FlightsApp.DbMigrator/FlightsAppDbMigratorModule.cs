using FlightsApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace FlightsApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FlightsAppEntityFrameworkCoreModule),
    typeof(FlightsAppApplicationContractsModule)
    )]
public class FlightsAppDbMigratorModule : AbpModule
{
}
