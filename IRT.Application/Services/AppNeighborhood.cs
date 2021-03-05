using IRT.Application.Interfaces;
using IRT.Application.ViewModels;
using IRT.Domain.Entities;
using IRT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRT.Application.Services
{
    public class AppNeighborhood : IAppNeighborhood
    {        
        private readonly INeighborhoodRepository _contextNeighborhood;

        public AppNeighborhood(INeighborhoodRepository contextNeighborhood) => 
            _contextNeighborhood = contextNeighborhood;
        public async Task<NeighborhoodViewModel> Add(NeighborhoodViewModel neighborhoodViewModel) {
            if (await _contextNeighborhood.CheckIfExists(neighborhoodViewModel.Name))
                throw new Exception("Bairro já cadastrado!");
            await _contextNeighborhood.Add(new Neighborhood(Guid.NewGuid(), neighborhoodViewModel.Name));
            return neighborhoodViewModel;
        }

        public async Task<IEnumerable<NeighborhoodViewModel>> GetAll() =>
            (await _contextNeighborhood.GetAll()).Select(x => new NeighborhoodViewModel(x));

        public async Task<IEnumerable<NeighborhoodViewModel>> GetByName(string name, int take) => 
            (await _contextNeighborhood.GetByName(name, take)).Select(x => new NeighborhoodViewModel(x));
    }
}
