using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Infrastructure.Persistence.Configurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(30);
            builder.Property(t => t.PhoneNumber).HasMaxLength(11);

            builder.HasMany(t => t.RentalContracts)
                .WithOne(rc => rc.Tenant)
                .HasForeignKey(rc => rc.TenantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    
    }
}
