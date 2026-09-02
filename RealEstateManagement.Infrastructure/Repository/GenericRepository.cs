using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Application.Interfaces;
using RealEstateManagement.Application.Interfaces.Repository;
using RealEstateManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly RealEstateManagementDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(RealEstateManagementDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>(); 
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.AsNoTracking().ToListAsync();
        public IQueryable<T> GetAllQueryableNoTracking() => _dbSet.AsNoTracking().AsQueryable();
        public IQueryable<T> GetAllQueryableTracking() => _dbSet.AsQueryable();
        public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public async Task DeleteAsync(Guid id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item != null)
                _dbSet.Remove(item);
        }
    }
}
