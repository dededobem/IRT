using IRT.Application.Interfaces.Base;
using IRT.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRT.Application.Interfaces
{
    public interface IAppDrugstore : IApplication<DrugstoreViewModel>
    {
        Task<DrugstoreViewModel> Update(Guid id, DrugstoreViewModel drugstore);
        Task<DrugstoreViewModel> GetById(Guid id);
        Task Delete(Guid id);
        Task<IEnumerable<DrugstoreViewModel>> GetByName(string name, int take);
        Task<IEnumerable<DrugstoreViewModel>> GetByNeighborhood(Guid id, bool? flgRoundTheClock);
    }
}
