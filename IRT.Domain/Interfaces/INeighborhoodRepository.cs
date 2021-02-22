using IRT.Domain.Entities;
using IRT.Domain.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRT.Domain.Interfaces
{
    public interface INeighborhoodRepository : IRepository<Neighborhood>
    {
        Task<IEnumerable<Neighborhood>> GetByName(string name, int take);
        Task<bool> CheckIfExists(string name);
    }
}
