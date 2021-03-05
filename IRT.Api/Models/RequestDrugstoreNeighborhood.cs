using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IRT.Api.Models
{
    public class RequestDrugstoreNeighborhood
    {
        [Required]
        public Guid Id { get; set; }
        public bool? FlgRoundTheClock { get; set; }
    }
}
