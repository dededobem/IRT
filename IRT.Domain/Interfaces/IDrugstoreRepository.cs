using IRT.Domain.Entities;
using IRT.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRT.Domain.Interfaces
{
    public interface IDrugstoreRepository : IRepository<Drugstore>
    {
        Task<IEnumerable<Drugstore>> GetByName(string name, int take);
        Task<bool> CheckIfExists(string name);
        Task<IEnumerable<Drugstore>> GetByNeighborhood(Guid id, bool? flgRoundTheClock);
    }
}
