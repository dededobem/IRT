using IRT.Application.Interfaces;
using IRT.Domain.Entities;
using IRT.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRT.Application.Services
{
    public class AppDrugstore : IAppDrugstore
    {
        private readonly IDrugstoreRepository _contextDrugstore;

        public AppDrugstore(IDrugstoreRepository contextDrugstore)
        {
            _contextDrugstore = contextDrugstore;
        }
        public void Add(Drugstore entity) => _contextDrugstore.Add(entity);

        public void Delete(Drugstore entity) => _contextDrugstore.Delete(entity);

        public Task<IEnumerable<Drugstore>> GetAll() => _contextDrugstore.GetAll();

        public Task<Drugstore> GetById(Guid id) => _contextDrugstore.GetById(id);

        public void Update(Drugstore entity) => _contextDrugstore.Update(entity);
    }
}
