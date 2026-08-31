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
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(b=>b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(30);
            builder.Property(b => b.Address).IsRequired().HasMaxLength(100);
            builder.Property(b => b.BuildingNumber).IsRequired();
            builder.HasIndex( b => new { b.BuildingNumber, b.OwnerId }).IsUnique();

            builder.HasMany(f => f.Floors)
                .WithOne(b => b.Building)
                .HasForeignKey(b => b.BuildingId)
                .OnDelete(DeleteBehavior.Restrict);

      

        }
    }
}
