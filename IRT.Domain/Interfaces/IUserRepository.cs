using IRT.Domain.Entities;
using IRT.Domain.Interfaces.Base;
using System.Threading.Tasks;

namespace IRT.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> VerifyUser(string login, string password);
    }
}
