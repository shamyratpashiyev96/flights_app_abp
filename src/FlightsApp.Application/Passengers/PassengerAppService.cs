using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FlightsApp.Passengers
{
    public class PassengerAppService : CrudAppService
        <Passenger,
        PassengerDto,
        int,
        PagedAndSortedResultRequestDto,
        CreatePassengerDto,
        UpdatePassengerDto>
    {
        private readonly IPassengerRepository passengerRepo;
        public PassengerAppService(IPassengerRepository repository) : base(repository)
        {
            passengerRepo = repository;
        }

        public async Task<List<PassengerDto>> GetWithFlights()
        {
            var passengers = await passengerRepo.GetWithFlights();
            var result = ObjectMapper.Map<List<Passenger>, List<PassengerDto>>(passengers);
            return result;
        }
    }
}