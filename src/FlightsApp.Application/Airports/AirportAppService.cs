using System.Linq.Expressions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FlightsApp.Airports
{
    public class AirportAppService : CrudAppService
        <Airport,
        AirportDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateAirportDto,
        UpdateAirportDto>
    {
        public AirportAppService(IRepository<Airport,int> airportRepo) : base(airportRepo)
        {
            
        }
    }
}