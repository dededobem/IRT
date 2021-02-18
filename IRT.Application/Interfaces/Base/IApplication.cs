using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRT.Application.Interfaces.Base
{
    public interface IApplication<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
    }
}
