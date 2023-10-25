using System.Collections.Generic;
using System.Threading.Tasks;
using FlightsApp.Airports;
using FlightsApp.Passengers;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace FlightsApp
{
    public class FlightsAppSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Airport,int> airportsRepo;

        private readonly IRepository<Passenger,int> passengersRepo;

        public FlightsAppSeederContributor(IRepository<Airport,int> _airportRepo, IRepository<Passenger, int> _passengerRepo)
        {
            airportsRepo = _airportRepo;
            passengersRepo = _passengerRepo;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await AirportsSeeder();
            await PassengersSeeder();
        }

        private async Task AirportsSeeder()
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

        private async Task PassengersSeeder()
        {
            List<Passenger> passengers = new(){
                new Passenger{ FirstName = "John", LastName = "Doe" },
                new Passenger{ FirstName = "Joshua", LastName = "Abigale" },
                new Passenger{ FirstName = "Lily", LastName = "Fletcher" },
                new Passenger{ FirstName = "Rose", LastName = "Gamer" },
                new Passenger{ FirstName = "Carlisle", LastName = "Johnson" },
                new Passenger{ FirstName = "Isabella", LastName = "Watson" },
                new Passenger{ FirstName = "Harry", LastName = "Grint" },
                new Passenger{ FirstName = "Emily", LastName = "Dares" },
                new Passenger{ FirstName = "David", LastName = "Miles" },
                new Passenger{ FirstName = "Dean", LastName = "Simons" },
            };

            await passengersRepo.InsertManyAsync(passengers);
        }
    }
}