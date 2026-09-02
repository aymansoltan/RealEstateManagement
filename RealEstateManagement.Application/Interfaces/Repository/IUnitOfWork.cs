using RealEstateManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
 
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    }
}
