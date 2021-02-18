using IRT.Application.Interfaces;
using IRT.Domain.Entities;
using IRT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRT.Application.Services
{
    public class AppNeighborhood : IAppNeighborhood
    {
        private readonly INeighborhoodRepository _contextNeighborhood;

        public AppNeighborhood(INeighborhoodRepository contextNeighborhood)
        {
            _contextNeighborhood = contextNeighborhood;
        }
        public void Add(Neighborhood entity) => _contextNeighborhood.Add(entity);

        public void Delete(Neighborhood entity) => _contextNeighborhood.Delete(entity);

        public Task<IEnumerable<Neighborhood>> GetAll() => _contextNeighborhood.GetAll();

        public Task<Neighborhood> GetById(Guid id) => _contextNeighborhood.GetById(id);

        public void Update(Neighborhood entity) => _contextNeighborhood.Update(entity);

    }
}
