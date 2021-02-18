using IRT.Application.Interfaces.Base;
using IRT.Domain.Entities;
using System.Threading.Tasks;

namespace IRT.Application.Interfaces
{
    public interface IAppUser : IApplication<User>
    {
        User VerifyUser(User user);
    }
}
