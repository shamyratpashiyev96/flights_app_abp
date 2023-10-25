using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FlightsApp.Data;
using Volo.Abp.DependencyInjection;

namespace FlightsApp.EntityFrameworkCore;

public class EntityFrameworkCoreFlightsAppDbSchemaMigrator
    : IFlightsAppDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreFlightsAppDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the FlightsAppDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<FlightsAppDbContext>()
            .Database
            .MigrateAsync();
    }
}
