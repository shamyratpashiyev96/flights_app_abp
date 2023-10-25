using AutoMapper;
using FlightsApp.Airports;
using FlightsApp.Passengers;

namespace FlightsApp;

public class FlightsAppApplicationAutoMapperProfile : Profile
{
    public FlightsAppApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

         CreateMap<Airport, AirportDto>();
         CreateMap<CreateAirportDto, Airport>();
         CreateMap<UpdateAirportDto, Airport>();

         CreateMap<Passenger, PassengerDto>();
         CreateMap<CreatePassengerDto, Passenger>();
         CreateMap<UpdatePassengerDto, Passenger>();
    }
}
