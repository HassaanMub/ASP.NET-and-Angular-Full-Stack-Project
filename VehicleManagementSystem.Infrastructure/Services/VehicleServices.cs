using Microsoft.EntityFrameworkCore;
using VehicleManagementSystem.Application.DTOs;
using VehicleManagementSystem.Application.Services;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Infrastructure.Data;
namespace VehicleManagementSystem.Infrastructure.Services;

public class VehicleService : IVehicleService
{
    private readonly VehicleDbContext _context;

    // public VehicleService(VehicleDbContext context)
    // {
    //     _context = context;
    // }
    public VehicleService(VehicleDbContext context)
    {
        _context = context;
    }

    public async Task<List<VehicleReadDto>> GetAllAsync()
    {
        return await _context.Vehicles
            .Select(v => new VehicleReadDto
            {
                Id = v.Id,
                Brand = v.Brand,
                Model = v.Model,
                Year = v.Year,
                RegistrationNumber = v.RegistrationNumber,
                Color = v.Color,
                Mileage = v.Mileage,
                FuelType = v.FuelType,
                Price = v.Price,
                IsAvailable = v.IsAvailable,
                ImageUrl = v.ImageUrl,
                CreatedAt = v.CreatedAt,
                UpdatedAt = v.UpdatedAt
            })
            .ToListAsync();
    }

    public async Task<VehicleReadDto?> GetByIdAsync(int id)
    {
        var v = await _context.Vehicles.FindAsync(id);
        if (v == null) return null;

        return new VehicleReadDto
        {
            Id = v.Id,
            Brand = v.Brand,
            Model = v.Model,
            Year = v.Year,
            RegistrationNumber = v.RegistrationNumber,
            Color = v.Color,
            Mileage = v.Mileage,
            FuelType = v.FuelType,
            Price = v.Price,
            IsAvailable = v.IsAvailable,
            ImageUrl = v.ImageUrl,
            CreatedAt = v.CreatedAt,
            UpdatedAt = v.UpdatedAt
        };
    }

    public async Task<VehicleReadDto> CreateAsync(VehicleCreateDto dto)
    {
        string imageUrl = string.Empty;
    
        // STEP 1: handle file upload
        if (dto.Image != null && dto.Image.Length > 0){
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Image.FileName);
            // var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            // var folderPath = Path.Combine(_env.WebRootPath, "images");
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            var filePath = Path.Combine(folderPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create)){ await dto.Image.CopyToAsync(stream); }
            // STEP 2: create URL
            imageUrl = "/images/" + fileName;
        }
        // STEP 3: create entity
        var vehicle = new Vehicle{
            Brand = dto.Brand,
            Model = dto.Model,
            Year = dto.Year,
            RegistrationNumber = dto.RegistrationNumber,
            Color = dto.Color,
            Mileage = dto.Mileage,
            FuelType = dto.FuelType,
            Price = dto.Price,
            IsAvailable = dto.IsAvailable,
            ImageUrl = imageUrl,
            CreatedAt = DateTime.UtcNow
        };
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();
        // STEP 4: return DTO
        return new VehicleReadDto {
            Id = vehicle.Id,
            Brand = vehicle.Brand,
            Model = vehicle.Model,
            Year = vehicle.Year,
            RegistrationNumber = vehicle.RegistrationNumber,
            Color = vehicle.Color,
            Mileage = vehicle.Mileage,
            FuelType = vehicle.FuelType,
            Price = vehicle.Price,
            IsAvailable = vehicle.IsAvailable,
            ImageUrl = vehicle.ImageUrl,
            CreatedAt = vehicle.CreatedAt
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle == null) return false;

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> UpdateAsync(int id, VehicleCreateDto dto)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle == null)
            return false;

        vehicle.Brand = dto.Brand;
        vehicle.Model = dto.Model;
        vehicle.Year = dto.Year;
        vehicle.RegistrationNumber = dto.RegistrationNumber;
        vehicle.Color = dto.Color;
        vehicle.Mileage = dto.Mileage;
        vehicle.FuelType = dto.FuelType;
        vehicle.Price = dto.Price;
        vehicle.IsAvailable = dto.IsAvailable;

        // ✅ update image only if new file sent
        if (dto.Image != null)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(dto.Image.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

            using var stream = new FileStream(path, FileMode.Create);
            await dto.Image.CopyToAsync(stream);

            vehicle.ImageUrl = "/images/" + fileName;
        }

        vehicle.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return true;
    }
}