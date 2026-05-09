using Microsoft.EntityFrameworkCore;
using VehicleManagementSystem.Domain.Entities;
namespace VehicleManagementSystem.Infrastructure.Data;
public class VehicleDbContext : DbContext{
    public VehicleDbContext(DbContextOptions<VehicleDbContext> options)
        : base(options){}
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
}