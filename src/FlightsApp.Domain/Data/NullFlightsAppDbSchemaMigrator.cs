using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FlightsApp.Data;

/* This is used if database provider does't define
 * IFlightsAppDbSchemaMigrator implementation.
 */
public class NullFlightsAppDbSchemaMigrator : IFlightsAppDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
