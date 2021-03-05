using IRT.Application.Interfaces.Base;
using IRT.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRT.Application.Interfaces
{
    public interface IAppNeighborhood : IApplication<NeighborhoodViewModel>
    {
        Task<IEnumerable<NeighborhoodViewModel>> GetByName(string name, int take);
        //Task<IEnumerable<NeighborhoodViewModel>> GetAll();
    }
}
