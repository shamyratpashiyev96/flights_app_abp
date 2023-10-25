using System.ComponentModel.DataAnnotations;

namespace FlightsApp.Airports
{
    public class CreateAirportDto
    {
        [Required]
        public string City { get; set; }

        [Required]
        public string Code { get; set; }
    }
}