using System;

namespace IRT.Domain.Entities
{
    public class Drugstore : EntityBase
    {
        public Drugstore(Guid id, string name, bool roundTheClock, DateTime foundationDate, Guid neighborhoodId) : base(id)
        {
            Name = name;
            RoundTheClock = roundTheClock;
            FoundationDate = foundationDate;
            NeighborhoodId = neighborhoodId;
        }
        protected Drugstore() { }

        public string Name { get; private set; }
        public bool RoundTheClock { get; private set; }
        public DateTime FoundationDate { get; private set; }
        public Guid NeighborhoodId { get; private set; }
        public Neighborhood Neighborhood { get; private set; }

        public bool CanRemove() => (DateTime.Today - FoundationDate).TotalDays >= 365;
    }
}
