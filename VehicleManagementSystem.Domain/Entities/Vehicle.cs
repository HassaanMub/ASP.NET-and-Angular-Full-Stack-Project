using System.ComponentModel.DataAnnotations;
namespace VehicleManagementSystem.Domain.Entities;
public class Vehicle
{
    public int Id { get; set; }
    [Required]
    public string Brand { get; set; } = string.Empty;
    [Required]
    public string Model { get; set; } = string.Empty;
    [Range(1900, 2026)]
    public int Year { get; set; }
    [Required]
    public string RegistrationNumber { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    [Range(0, int.MaxValue)]
    public int Mileage { get; set; }
    public string FuelType { get; set; } = string.Empty;
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}