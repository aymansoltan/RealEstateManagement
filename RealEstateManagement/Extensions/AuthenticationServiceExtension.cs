using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RealEstateManagement.Application.Features.Owners.Command.RegisterOwner;
using RealEstateManagement.Application.Interfaces;
using RealEstateManagement.Application.Interfaces.Repository;
using RealEstateManagement.Infrastructure.Authentication;
using RealEstateManagement.Infrastructure.Persistence;
using RealEstateManagement.Infrastructure.Repository;
using System.Text;

namespace RealEstateManagement.Extensions
{
    public static class AuthenticationServiceExtension
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<RealEstateManagementDbContext>()
                .AddDefaultTokenProviders();
              services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddScoped<ITokenService, TokenService>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings!.Issuer,
                    ValidAudience = jwtSettings.Audience,

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Key))
                };
            });

            return services;
        }

    }
}
