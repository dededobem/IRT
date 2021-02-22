using IRT.Application.Exceptions;
using IRT.Application.Interfaces;
using IRT.Application.ViewModels;
using IRT.Domain.Entities;
using IRT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRT.Application.Services
{
    public class AppDrugstore : IAppDrugstore
    {
        private readonly IDrugstoreRepository _contextDrugstore;
        private readonly INeighborhoodRepository _contextNeighborhood;

        public AppDrugstore(IDrugstoreRepository contextDrugstore, INeighborhoodRepository contextNeighborhood)
        {
            _contextDrugstore = contextDrugstore;
            _contextNeighborhood = contextNeighborhood;
        }

        public async Task<DrugstoreViewModel> Add(DrugstoreViewModel drugstore)
        {
            if (await _contextDrugstore.CheckIfExists(drugstore.Name))
                throw new ApiException("Drugstore already exists!");
            await _contextDrugstore
                .Add(new Drugstore(
                    Guid.NewGuid(),
                    drugstore.Name,
                    drugstore.RoundTheClock,
                    drugstore.FoundationDate,
                    drugstore.NeighborhoodId)
                );
            return drugstore;
        }

        public async Task Delete(Guid id)
        {
            var drugstore = await _contextDrugstore.GetById(id);
            if (drugstore == null)
                throw new ApiException("Drugstore not found!");
            if (drugstore.CanRemove())
                throw new ApiException("Drugstore cannot be removed. Foundation date more than 1 year");
            await _contextDrugstore.Delete(drugstore);
        }

        public async Task<IEnumerable<DrugstoreViewModel>> GetByName(string name, int take) =>
             (await _contextDrugstore.GetByName(name, take)).Select(x => new DrugstoreViewModel(x));

        public async Task<IEnumerable<DrugstoreViewModel>> GetByNeighborhood(Guid id, bool? flgRoundTheClock)
        {
            var neighborhood = await _contextNeighborhood.GetById(id);
            if (neighborhood == null)
                throw new ApiException("Neighborhood not found!");
            return (await _contextDrugstore.GetByNeighborhood(id, flgRoundTheClock)).Select(x => new DrugstoreViewModel(x));
        }

        public async Task<DrugstoreViewModel> Update(Guid id, DrugstoreViewModel drugstoreViewModel)
        {
            var drugstore = await _contextDrugstore.GetById(id);
            if (drugstore == null)
                throw new ApiException("Drugstore not found!");
            if (await _contextDrugstore.CheckIfExists(drugstoreViewModel.Name))
                throw new ApiException("Drugstore already exists!");
            await _contextDrugstore.Update(new Drugstore(
                    id,
                    drugstoreViewModel.Name,
                    drugstoreViewModel.RoundTheClock,
                    drugstoreViewModel.FoundationDate,
                    drugstoreViewModel.NeighborhoodId));
            return drugstoreViewModel;
        }

    }
}
