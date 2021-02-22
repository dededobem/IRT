using System;
using System.Collections.Generic;
using System.Linq;

namespace IRT.Domain.Entities
{
    public class Neighborhood : EntityBase
    {
        protected Neighborhood() { }
        public Neighborhood(Guid id, string name) : base(id)
        {
            Name = name;
            Validate();
        }

        public string Name { get; private set; }

        public ICollection<Drugstore> Drugstores { get; private set; }
        public int GetCountDrugstore() => Drugstores.Count();
        public int GetCountDrugstoreRoundTheClock() => Drugstores.Where(d => d.RoundTheClock).Count();
        public void Validate() =>
            Name = Name == "" ? throw new Exception("Name is required!") : Name;

    }
}
