using RealEstateManagement.Application.Interfaces;
using RealEstateManagement.Application.Interfaces.Repository;
using RealEstateManagement.Domain.Entities;
using RealEstateManagement.Infrastructure.Persistence;


namespace RealEstateManagement.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RealEstateManagementDbContext _context; 

        public UnitOfWork(RealEstateManagementDbContext context)
        {
            _context = context;

        }
        public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            if (_context is IDisposable disposableContext)
            {
                disposableContext.Dispose();
            }
        }
     
    }
}
