using Volo.Abp.Domain.Entities.Auditing;

namespace FlightsApp.FlightsPassengers 
{
    public class FlightPassengerPivot : AuditedEntity<int>
    {
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
    }
}