using IRT.Domain.Entities;
using IRT.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRT.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User VerifyUser(User user);
    }
}
