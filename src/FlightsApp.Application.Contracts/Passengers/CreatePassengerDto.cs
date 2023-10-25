using System.ComponentModel.DataAnnotations;

namespace FlightsApp.Passengers
{
    public class CreatePassengerDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}