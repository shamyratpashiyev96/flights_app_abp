using System.Threading.Tasks;

namespace FlightsApp.Data;

public interface IFlightsAppDbSchemaMigrator
{
    Task MigrateAsync();
}
