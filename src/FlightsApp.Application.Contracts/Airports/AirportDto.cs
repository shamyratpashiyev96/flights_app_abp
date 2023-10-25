using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;

namespace FlightsApp.Airports
{
    public class AirportDto : AuditedEntityDto<int>
    {
        [Required]
        public string City { get; set; }

        [Required]
        public string Code { get; set; }
    }
}