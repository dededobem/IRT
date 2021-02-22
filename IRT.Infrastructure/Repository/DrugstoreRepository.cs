using IRT.Domain.Entities;
using IRT.Domain.Interfaces;
using IRT.Infrastructure.Data;
using IRT.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRT.Infrastructure.Repository
{
    public class DrugstoreRepository : Repository<Drugstore>, IDrugstoreRepository
    {
        private readonly IRTDbContext _dbContext;

        public DrugstoreRepository(IRTDbContext context) : base(context)
        {
            _dbContext = context;
        }
                
        public async Task<bool> CheckIfExists(string name) =>
            await _dbContext.Drugstores.AnyAsync(x => x.Name == name);

        public async Task<IEnumerable<Drugstore>> GetByName(string name, int take) =>
            name == null ? await _dbContext.Drugstores.Take(take).ToListAsync() :
            await _dbContext.Drugstores
            .Where(x => EF.Functions.Like(x.Name, $"%{name}%"))
            .Take(take)
            .ToListAsync();

        public async Task<IEnumerable<Drugstore>> GetByNeighborhood(Guid id, bool? flgRoundTheClock) =>
            flgRoundTheClock != null ? 
            await _dbContext.Drugstores.Where(x => x.NeighborhoodId == id && x.RoundTheClock == flgRoundTheClock).ToListAsync() :
            await _dbContext.Drugstores.Where(x => x.NeighborhoodId == id).ToListAsync();
        
    }
}
