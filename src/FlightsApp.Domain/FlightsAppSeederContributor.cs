using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightsApp.Airports;
using FlightsApp.Flights;
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

        private readonly IRepository<Flight,int> flightRepo;

        private List<Passenger> passengers;
        private List<Airport> airports;

        public FlightsAppSeederContributor(
            IRepository<Airport,int> _airportRepo, 
            IRepository<Passenger, int> _passengerRepo,
            IRepository<Flight, int> _flightRepo
            )
        {
            airportsRepo = _airportRepo;
            passengersRepo = _passengerRepo;
            flightRepo = _flightRepo;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await AirportsSeeder();
            await PassengersSeeder();
            await FlightsSeeder();
        }

        private async Task AirportsSeeder()
        {
            airports = new(){
                new Airport { City = "New York", Code = "JFK" },
                new Airport { City = "London", Code = "HTR" },
                new Airport { City = "Paris", Code = "CDH" },
                new Airport { City = "Rome", Code = "RMA" },
                new Airport { City = "Shanghai", Code = "SHA" },
            };

            long airportsCount = await airportsRepo.GetCountAsync();
            if(airportsCount < 1)
            {
                await airportsRepo.InsertManyAsync(airports);
            }
        }

        private async Task PassengersSeeder()
        {
            passengers = new(){
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

            long passengersCount = await passengersRepo.GetCountAsync();
            if(passengersCount < 1)
            {
                await passengersRepo.InsertManyAsync(passengers);
            }
        }

        private async Task FlightsSeeder()
        {
            long flightsCount = await flightRepo.GetCountAsync();

            if(flightsCount < 1)
            {
                for(int i = 0; i < 10; i++)
                {
                    int randomNum1 = new Random().Next(1, airports.Count);
                    int randomNum2 = new Random().Next(1, airports.Count);
                    DateTime randomDate1 = new DateTime(new Random().Next(2010,2023), new Random().Next(1,12), new Random().Next(1,28), new Random().Next(0,23), new Random().Next(0,59), new Random().Next(0,59));
                    DateTime randomDate2 = new DateTime(new Random().Next(2010,2023), new Random().Next(1,12), new Random().Next(1,28), new Random().Next(0,23), new Random().Next(0,59), new Random().Next(0,59));
                    
                    await flightRepo.InsertAsync(
                        new Flight{
                            OriginId = randomNum1,
                            DestinationId = randomNum2,
                            ArrivalDate = randomDate1,
                            DepartureDate = randomDate2
                        }
                    );
                }
            }
        }
    }
}