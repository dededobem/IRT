using System;
using System.ComponentModel.DataAnnotations;

namespace IRT.Api.Models
{
    public class RequestDrugstoreNeighborhood
    {
        [Required]
        public Guid Id { get; set; }
        public bool? FlgRoundTheClock { get; set; }
    }
}
