using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRT.Application.Interfaces.Base
{
    public interface IApplication<T> where T : class
    {
        Task<T> Add(T entity);

        Task<IEnumerable<T>> GetAll();
    }
}
