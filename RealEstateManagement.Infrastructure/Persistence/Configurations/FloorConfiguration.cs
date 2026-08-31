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
    public class FloorConfiguration : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.FloorNumber).IsRequired();
            builder.HasIndex(f => new { f.FloorNumber, f.BuildingId }).IsUnique();

            builder.HasMany(f => f.Units)
                .WithOne(u => u.Floor)
                .HasForeignKey(u => u.FloorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
