using System;
using System.ComponentModel.DataAnnotations;

namespace FlightsApp.Flights
{
    public class CreateFlightDto
    {
        [Required]
        public int OriginId { get; set; }

        [Required]
        public int DestinationId { get; set; }

        [Required]
        public DateTime DepartureDate { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
    }
}