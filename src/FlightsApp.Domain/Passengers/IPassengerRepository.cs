using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightsApp.Passengers;
using Volo.Abp.Domain.Repositories;

namespace FlightsApp.Passengers
{
    public interface IPassengerRepository : IRepository<Passenger,int>
    {
        Task<List<Passenger>> GetWithFlights();
    }
}