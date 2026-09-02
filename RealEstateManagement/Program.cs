
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RealEstateManagement.Application.Features.Owners.Command.RegisterOwner;
using RealEstateManagement.Application.Interfaces;
using RealEstateManagement.Extensions;
using RealEstateManagement.Infrastructure.Authentication;
using RealEstateManagement.Infrastructure.Persistence;
using System.Text;


namespace RealEstateManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDatabaseServices(builder.Configuration);
            builder.Services.AddAuthServices(builder.Configuration);


         var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
