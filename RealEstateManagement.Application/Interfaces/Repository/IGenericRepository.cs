using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetAllQueryableNoTracking() ;
        IQueryable<T> GetAllQueryableTracking() ;
        Task<T?> GetByIdAsync(Guid id) ;
        Task AddAsync(T entity)  ;
        void Update(T entity) ;
        Task DeleteAsync(Guid id);
    }
}
