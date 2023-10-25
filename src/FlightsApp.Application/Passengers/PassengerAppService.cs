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
        public PassengerAppService(IRepository<Passenger, int> repository) : base(repository)
        {
        }
    }
}