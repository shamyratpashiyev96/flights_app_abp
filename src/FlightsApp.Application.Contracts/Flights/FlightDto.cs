using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlightsApp.Airports;
using Volo.Abp.Application.Dtos;

namespace FlightsApp.Flights
{
    public class FlightDto : AuditedEntityDto<int>
    {
        public int Id { get; set; }
        [Required]
        public int OriginId { get; set; }

        public AirportDto Origin { get; set; }

        [Required]
        public int DestinationId { get; set; }
        public AirportDto Destination { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
    }
}