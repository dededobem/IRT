using IRT.Domain.Entities;
using IRT.Domain.Interfaces.Base;
using IRT.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRT.Infrastructure.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly IRTDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(IRTDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();

        public async Task<T> GetById(Guid id) => 
            await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

}

