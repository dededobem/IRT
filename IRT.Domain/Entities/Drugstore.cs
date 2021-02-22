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

            Validate();
        }
        protected Drugstore() { }

        public string Name { get; private set; }
        public bool RoundTheClock { get; private set; }
        public DateTime FoundationDate { get; private set; }
        public Guid NeighborhoodId { get; private set; }
        public Neighborhood Neighborhood { get; private set; }

        public bool CanRemove() => (DateTime.Today - FoundationDate).TotalDays >= 365;

        public void Validate()
        {
            Name = Name == "" ? throw new Exception("Name is required!") : Name;
            RoundTheClock = RoundTheClock ? throw new Exception("Round the clock is required!") : RoundTheClock;
            FoundationDate = FoundationDate.ToString() == "" ? throw new Exception("Foundation Date is required!") : FoundationDate;
            NeighborhoodId = NeighborhoodId.ToString() == "" ? throw new Exception("Neighborhood id is required!") : NeighborhoodId;
        }
    }
}
