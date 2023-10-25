using System.ComponentModel.DataAnnotations;

namespace FlightsApp.Airports
{
    public class UpdateAirportDto
    {
        [Required]
        public string City { get; set; }

        [Required]
        public string Code { get; set; }
    }
}