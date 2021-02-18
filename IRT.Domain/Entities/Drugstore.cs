using System;
using System.Collections.Generic;
using System.Text;

namespace IRT.Domain.Entities
{
    public class Drugstore
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool FlgRoundTheClock { get; set; }
        public DateTime FoundationDate { get; set; }
        public Guid NeighborhoodId { get; set; }
        public Neighborhood Neighborhood { get; set; }
    }
}
