using IRT.Application.Interfaces.Base;
using IRT.Application.ViewModels;
using System.Threading.Tasks;

namespace IRT.Application.Interfaces
{
    public interface IAppUser : IApplication<UserViewModel>
    {
        Task<UserViewModel> VerifyUser(string login, string password);
    }
}
