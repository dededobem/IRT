using IRT.Application.ViewModels;
using System.Threading.Tasks;

namespace IRT.Application.Interfaces
{
    public interface IAppAuthentication
    {
        Task<AccountViewModel> Authenticate(string login, string password);
    }
}
