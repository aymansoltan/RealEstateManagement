using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateManagement.Domain.Entities;


namespace RealEstateManagement.Infrastructure.Persistence.Configurations
{
    public class RentalContractConfiguration : IEntityTypeConfiguration<RentalContract>
    {
        public void Configure(EntityTypeBuilder<RentalContract> builder)
        {
            builder.HasKey(rc => rc.Id);
            builder.Property(rc => rc.StartDate).IsRequired();
            builder.Property(rc => rc.EndDate).IsRequired();
            builder.Property(rc => rc.RentAmount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(rc => rc.SecurityDeposit).HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(rc => rc.Status).HasConversion<string>().IsRequired();

            builder.HasIndex(rc => rc.UnitId).IsUnique().HasFilter("[Status] = 'Active'");



            builder.HasMany(rc => rc.Documents)
                .WithOne(rc=>rc.RentalContract)
                .HasForeignKey(d => d.RentalContractId)
                .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
