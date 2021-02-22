using IRT.Domain.Entities;
using IRT.Domain.Interfaces;
using IRT.Infrastructure.Data;
using IRT.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRT.Infrastructure.Repository
{
    public class NeighborhoodRepository : Repository<Neighborhood>, INeighborhoodRepository
    {
        private readonly IRTDbContext _dbContext;

        public NeighborhoodRepository(IRTDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<bool> CheckIfExists(string name) =>
            await _dbContext.Neighborhoods.AnyAsync(x => x.Name == name);

        public override async Task<IEnumerable<Neighborhood>> GetAll() =>
            await _dbContext.Neighborhoods.Include(x => x.Drugstores).ToListAsync();

        public async Task<IEnumerable<Neighborhood>> GetByName(string name, int take) =>
            name == null ? await _dbContext.Neighborhoods.Include(x => x.Drugstores).ToListAsync() :
            await _dbContext.Neighborhoods.Include(x => x.Drugstores)
                .Where(x => EF.Functions.Like(x.Name, $"%{name}%")).Take(take).ToListAsync();

    }
}
