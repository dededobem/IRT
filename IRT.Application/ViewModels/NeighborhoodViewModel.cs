using IRT.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace IRT.Application.ViewModels
{
    public class NeighborhoodViewModel
    {
        public NeighborhoodViewModel() { }

        public NeighborhoodViewModel(Neighborhood neighborhood)
        {
            Id = neighborhood.Id;
            Name = neighborhood.Name;
            CountDrugstore = neighborhood.GetCountDrugstore();
        }

        public int CountDrugstore { get; private set; }              
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
