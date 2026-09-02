using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Application.Features.Owners.Command.RegisterOwner;
using RealEstateManagement.Application.Interfaces;
using RealEstateManagement.Application.Interfaces.Repository;
using RealEstateManagement.Infrastructure.Persistence;
using RealEstateManagement.Infrastructure.Repository;

namespace RealEstateManagement.Extensions
{
    public static class DatabaseServiceExtension
    {
        public static IServiceCollection AddDatabaseServices (this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<RealEstateManagementDbContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterOwnerCommand).Assembly));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
