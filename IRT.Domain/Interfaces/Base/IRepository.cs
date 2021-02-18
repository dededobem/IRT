using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRT.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid Id);

    }
}
