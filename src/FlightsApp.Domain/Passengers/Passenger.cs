using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    }
}