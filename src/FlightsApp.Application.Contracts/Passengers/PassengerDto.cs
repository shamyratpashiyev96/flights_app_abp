using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace FlightsApp.Passengers
{
    public class PassengerDto : AuditedEntityDto<int>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}