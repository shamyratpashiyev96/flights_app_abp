using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightsApp.Flights;
using Volo.Abp.Domain.Entities.Auditing;

namespace FlightsApp.Airports
{
    public class Airport : AuditedAggregateRoot<int>
    {
        [Required]
        [Column(TypeName = "VARCHAR(500)")]
        public string City { get; set; }

        [Column(TypeName = "VARCHAR(500)")]
        [Required]
        public string Code { get; set; }

        public IEnumerable<Flight> Arrivals { get; set; }

        public IEnumerable<Flight> Departures { get; set; }
    }
}