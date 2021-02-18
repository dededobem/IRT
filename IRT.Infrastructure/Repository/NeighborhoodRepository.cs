using IRT.Domain.Entities;
using IRT.Domain.Interfaces;
using IRT.Infrastructure.Data;
using IRT.Infrastructure.Repository.Base;

namespace IRT.Infrastructure.Repository
{
    public class NeighborhoodRepository : Repository<Neighborhood>, INeighborhoodRepository
    {
        private readonly IRTDbContext _dbContext;

        public NeighborhoodRepository(IRTDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
