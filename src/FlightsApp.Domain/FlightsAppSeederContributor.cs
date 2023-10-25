using System.Collections.Generic;
using System.Threading.Tasks;
using FlightsApp.Airports;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace FlightsApp
{
    public class FlightsAppSeederContributor : IDataSeedContributor, ITransientDependency
    {
        IRepository<Airport,int> airportsRepo;

        public FlightsAppSeederContributor(IRepository<Airport,int> _airportRepo)
        {
            airportsRepo = _airportRepo;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            List<Airport> airports = new(){
                new Airport { City = "New York", Code = "JFK" },
                new Airport { City = "London", Code = "HTR" },
                new Airport { City = "Paris", Code = "CDH" },
                new Airport { City = "Rome", Code = "RMA" },
                new Airport { City = "Shanghai", Code = "SHA" },
            };

            await airportsRepo.InsertManyAsync(airports);
        }
    }
}