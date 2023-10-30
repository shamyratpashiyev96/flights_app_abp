using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightsApp.Airports;
using Volo.Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using FlightsApp.Passengers;

namespace FlightsApp.Flights
{
    public class Flight : AuditedAggregateRoot<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OriginId { get; set; }
        [ForeignKey("OriginId")]
        public Airport Origin { get; set; }

        [Required]
        public int DestinationId { get; set; }
        [ForeignKey("DestinationId")]
        public Airport Destination { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }

        public List<Passenger> Passengers { get; set; }
    }
}