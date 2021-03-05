using IRT.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

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
            Neighborhood = drugstore.Neighborhood;
            NeighborhoodId = drugstore.NeighborhoodId;

            CanRemove = drugstore.CanRemove();
        }

        public Guid Id { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool RoundTheClock { get; set; }
        [Required]
        public DateTime FoundationDate { get; set; }
        [Required]
        public Guid NeighborhoodId { get; set; }
        public Neighborhood Neighborhood { get; set; }
        public bool CanRemove { get; private set; }
    }
}
