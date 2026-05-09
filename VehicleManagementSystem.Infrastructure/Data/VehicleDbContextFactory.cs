using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using VehicleManagementSystem.Infrastructure.Data;

namespace VehicleManagementSystem.Infrastructure.Data;

public class VehicleDbContextFactory : IDesignTimeDbContextFactory<VehicleDbContext>
{
    public VehicleDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "VehicleManagementSystem.API");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<VehicleDbContext>();

        optionsBuilder.UseSqlite(
            configuration.GetConnectionString("DefaultConnection")
        );

        return new VehicleDbContext(optionsBuilder.Options);
    }
}