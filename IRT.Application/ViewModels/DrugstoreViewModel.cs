using IRT.Domain.Entities;
using System;

namespace IRT.Application.ViewModels
{
    public class DrugstoreViewModel
    {
        public DrugstoreViewModel() { }

        public DrugstoreViewModel(Drugstore drugstore)
        {
            Id = drugstore.Id;
            Name = drugstore.Name;
            RoundTheClock = drugstore.RoundTheClock;
            FoundationDate = drugstore.FoundationDate;
            NeighborhoodId = drugstore.NeighborhoodId;

            CanRemove = drugstore.CanRemove();
        }

        public Guid Id { get; private set; }
        public string Name { get; set; }
        public bool RoundTheClock { get; set; }
        public DateTime FoundationDate { get; set; }
        public Guid NeighborhoodId { get; set; }
        public bool CanRemove { get; private set; }
    }
}
