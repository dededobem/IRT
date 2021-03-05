using System;

namespace IRT.Domain.Entities
{
    public class Drugstore : EntityBase
    {
        public Drugstore(Guid id, string name, bool roundTheClock, DateTime foundationDate, Guid neighborhoodId, Neighborhood neighborhood) : base(id)
        {
            Name = name;
            RoundTheClock = roundTheClock;
            FoundationDate = foundationDate;
            Neighborhood = neighborhood;
            NeighborhoodId = neighborhoodId;

            Validate();
        }
        protected Drugstore() { }

        public string Name { get; private set; }
        public bool RoundTheClock { get; private set; }
        public DateTime FoundationDate { get; private set; }
        public Guid NeighborhoodId { get; private set; }
        public Neighborhood Neighborhood { get; private set; }

        public bool CanRemove() => (DateTime.Today - FoundationDate).TotalDays < 365;

        public void Validate()
        {
            Name = String.IsNullOrEmpty(Name) ? throw new Exception("Name is required!") : Name;
            FoundationDate = FoundationDate.Equals(DateTime.MinValue) ? throw new Exception("Foundation Date is required!") : FoundationDate;
            NeighborhoodId = NeighborhoodId == Guid.Empty ? throw new Exception("Neighborhood id is required!") : NeighborhoodId;
        }
    }
}
