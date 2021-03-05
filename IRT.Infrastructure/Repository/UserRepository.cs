using IRT.Domain.Entities;
using IRT.Domain.Interfaces;
using IRT.Infrastructure.Data;
using IRT.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IRT.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IRTDbContext _dbContext;
        public UserRepository(IRTDbContext context) : base(context) => _dbContext = context;

        public async Task<User> VerifyUser(string login, string password) =>
            await _dbContext.Users.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);        
    }
}
