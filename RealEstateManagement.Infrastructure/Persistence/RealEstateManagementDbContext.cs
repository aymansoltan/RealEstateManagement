using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Application.Interfaces;
using RealEstateManagement.Domain.Entities;

namespace RealEstateManagement.Infrastructure.Persistence
{
    public class RealEstateManagementDbContext : IdentityDbContext<IdentityUser> , IRealEstateManagementDbContext
    {
        public RealEstateManagementDbContext(DbContextOptions<RealEstateManagementDbContext> options) : base(options)
        {   
        }
        
        public DbSet<Owner> Owners => Set<Owner>();
        public DbSet<Building> Buildings => Set<Building>();
        public DbSet<Document> Documents => Set<Document>();
        public DbSet<Floor> Floors => Set<Floor>();
        public DbSet<RentalContract> RentalContracts => Set<RentalContract>();
        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<Unit> Units => Set<Unit>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RealEstateManagementDbContext).Assembly);
        }
    }
}
