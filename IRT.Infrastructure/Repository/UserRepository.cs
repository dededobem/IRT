using IRT.Domain.Entities;
using IRT.Domain.Interfaces;
using IRT.Infrastructure.Data;
using IRT.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRT.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IRTDbContext _dbContext;
        public UserRepository(IRTDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public User VerifyUser(User user)
        {
            var _user = _dbContext.Users.FirstOrDefault(x => x.Login == user.Login && x.Password == user.Password);
            if (_user != null)
            {
                return _user;
            }
            return null;
        }
    }
}
