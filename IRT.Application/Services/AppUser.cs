using IRT.Application.Interfaces;
using IRT.Domain.Entities;
using IRT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRT.Application.Services
{
    public class AppUser : IAppUser
    {
        private readonly IUserRepository _contextUser;

        public AppUser(IUserRepository contextUser)
        {
            _contextUser = contextUser;
        }
        public void Add(User entity) => _contextUser.Add(entity);

        public void Delete(User entity) => _contextUser.Delete(entity);

        public Task<IEnumerable<User>> GetAll() => _contextUser.GetAll();

        public Task<User> GetById(Guid id) => _contextUser.GetById(id);

        public void Update(User entity) => _contextUser.Update(entity);

        public User VerifyUser(User user) => _contextUser.VerifyUser(user);
    }
}
