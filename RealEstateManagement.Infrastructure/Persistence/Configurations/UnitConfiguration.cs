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
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UnitNumber).IsRequired();
            builder.Property(u => u.Area).IsRequired();
            builder.Property(u => u.NumberOfBathrooms).IsRequired();
            builder.Property(u => u.NumberOfRooms).IsRequired();
            builder.HasIndex(u => new { u.UnitNumber, u.FloorId }).IsUnique();
            builder.Property(u => u.Status).HasConversion<string>().IsRequired();




            builder.HasMany(u => u.RentalContracts)
                .WithOne(rc => rc.Unit)
                .HasForeignKey(rc => rc.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
