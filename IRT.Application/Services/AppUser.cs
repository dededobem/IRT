using IRT.Application.Interfaces;
using IRT.Application.ViewModels;
using IRT.Domain.Entities;
using IRT.Domain.Interfaces;
using IRT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<UserViewModel> Add(UserViewModel user)
        {
            await _contextUser.Add(new User(Guid.NewGuid(), user.Name, user.Login, user.Email, user.Password));
            return user;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll() =>
            (await _contextUser.GetAll()).Select(x => new UserViewModel(x));        

        public async Task<UserViewModel> VerifyUser(string login, string password)
        {
            var user = await _contextUser.VerifyUser(login, new Password(password));
            return user == null ? null : new UserViewModel(user);
        }
            
    }
}
