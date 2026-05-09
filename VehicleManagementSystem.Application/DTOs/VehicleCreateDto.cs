using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace VehicleManagementSystem.Application.DTOs;
public class VehicleCreateDto
{
    [Required(ErrorMessage = "Brand is Required")]
    [MinLength(2, ErrorMessage = "Brand must be atleast 2 Characters")]
    public string Brand { get; set; } = string.Empty;
    [Required(ErrorMessage = "Model is Required")]
    [MinLength(1, ErrorMessage = "Invalid Model Field")]
    public string Model { get; set; } = string.Empty;
    [Range(1900, 2030, ErrorMessage = "Year must be between 1900 and 2030")]
    public int Year { get; set; }
    [Required(ErrorMessage = "Registration number is required")]
    public string RegistrationNumber { get; set; } = string.Empty;
    public string Color { get; set; } = "N/A";
    [Range(0, int.MaxValue, ErrorMessage = "Mileage cannot be negative")]
    public int Mileage { get; set; }
    public string FuelType { get; set; } = "N/A";
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; } = true;
    public IFormFile? Image { get; set; }
}