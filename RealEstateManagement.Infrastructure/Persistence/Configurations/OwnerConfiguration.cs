using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateManagement.Domain.Entities;


namespace RealEstateManagement.Infrastructure.Persistence.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(o => o.Id); 

            builder.Property(o => o.Name).IsRequired().HasMaxLength(30); 

            builder.Property(o => o.PhoneNumber).IsRequired().HasMaxLength(11);

            builder.HasMany(o => o.Buildings)
                .WithOne(b => b.Owner)
                .HasForeignKey(b => b.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.IdentityUserId)
                .IsRequired();

            builder.HasIndex(o => o.IdentityUserId)
                .IsUnique();

            builder.HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(o => o.IdentityUserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
