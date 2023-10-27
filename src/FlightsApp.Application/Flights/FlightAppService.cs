using System.Threading.Tasks;
using FlightsApp.Airports;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.IO;
using System;
using Volo.Abp.OpenIddict;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace FlightsApp.Flights
{
    public class FlightAppService : CrudAppService<
            Flight,
            FlightDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateFlightDto,
            UpdateFlightDto>
    {
        private readonly IRepository<Flight,int> flightRepo;
        private readonly IRepository<Airport,int> airportRepo;

        public FlightAppService(
            IRepository<Flight,int> _flightRepo,
            IRepository<Airport, int> _airportRepo
            ) : base(_flightRepo)
        {
            flightRepo = _flightRepo;
            airportRepo = _airportRepo;
        }

        public async override Task<FlightDto> GetAsync(int id)
        {
            var flightQueryable = await flightRepo.GetQueryableAsync();
            var airportQueryable = await airportRepo.GetQueryableAsync();

            var query = from flight in flightQueryable 
                join origin in airportQueryable
                on flight.OriginId equals origin.Id 
                join destination in airportQueryable
                on flight.DestinationId equals destination.Id
                where flight.Id == id
                select new { flight, origin, destination };
            
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);

            if(queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Flight), id);
            }

            var flightDto = ObjectMapper.Map<Flight, FlightDto>(queryResult.flight);
            flightDto.Origin = ObjectMapper.Map<Airport, AirportDto>(queryResult.origin);
            flightDto.Destination = ObjectMapper.Map<Airport, AirportDto>(queryResult.destination);

            return flightDto;
        }

        public async override Task<PagedResultDto<FlightDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryableFlight = await flightRepo.GetQueryableAsync();
            var queryableAirport = await airportRepo.GetQueryableAsync();

            var query = from flight in queryableFlight
                join origin in queryableAirport
                on flight.OriginId equals origin.Id
                join destination in queryableAirport
                on flight.DestinationId equals destination.Id
                select new { flight, origin, destination };

            query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var flightDtos = queryResult.Select(x => {
                var flightDto = ObjectMapper.Map<Flight, FlightDto>(x.flight);
                flightDto.Origin = ObjectMapper.Map<Airport, AirportDto>(x.origin);
                flightDto.Destination = ObjectMapper.Map<Airport,AirportDto>(x.destination);
                return flightDto;
            }).ToList();

            long totalCount = await flightRepo.GetCountAsync();

            return new PagedResultDto<FlightDto>(
                totalCount,
                flightDtos
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if(sorting.IsNullOrEmpty())
            {
                return $"flight.{nameof(Flight.ArrivalDate)}";
            }
            
            return sorting;
        }

        
    }
}