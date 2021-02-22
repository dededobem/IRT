using IRT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRT.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : EntityBase
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
