using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Application.Interfaces
{
    public interface IRealEstateManagementDbContext
    {
        DbSet<Owner> Owners { get; }
        DbSet<Building> Buildings { get; }
        DbSet<Document> Documents { get; }
        DbSet<Floor> Floors { get; }
        DbSet<RentalContract> RentalContracts { get; }
        DbSet<Tenant> Tenants { get; }
        DbSet<Unit> Units { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
