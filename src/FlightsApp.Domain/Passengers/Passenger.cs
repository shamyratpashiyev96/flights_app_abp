using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightsApp.Flights;
using Volo.Abp.Domain.Entities.Auditing;

namespace FlightsApp.Passengers
{
    public class Passenger : AuditedAggregateRoot<int>
    {
        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string LastName { get; set; }

        public List<Flight> Flights { get; set; }
    }
}