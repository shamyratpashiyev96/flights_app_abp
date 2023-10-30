using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FlightsApp.EntityFrameworkCore;
using FlightsApp.Flights;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Linq;

namespace FlightsApp.Passengers
{
    public class EfCorePassengerRepository : EfCoreRepository<FlightsAppDbContext, Passenger, int>,
        IPassengerRepository
    {

        public EfCorePassengerRepository(
            IDbContextProvider<FlightsAppDbContext> dbContextProvider
        ) : base(dbContextProvider)
        {

        }

        public async Task<List<Passenger>> GetWithFlights()
        {
            var dbSet = await GetDbSetAsync();
            
            return await dbSet.Include(passenger => passenger.Flights).ToListAsync();
        }

    }
}