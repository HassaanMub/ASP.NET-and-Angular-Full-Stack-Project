using VehicleManagementSystem.Application.DTOs;

namespace VehicleManagementSystem.Application.Services;

public interface IVehicleService
{
    Task<List<VehicleReadDto>> GetAllAsync();
    Task<VehicleReadDto?> GetByIdAsync(int id);
    Task<VehicleReadDto> CreateAsync(VehicleCreateDto dto);
    Task<bool> UpdateAsync(int id, VehicleCreateDto dto);
    Task<bool> DeleteAsync(int id);
}