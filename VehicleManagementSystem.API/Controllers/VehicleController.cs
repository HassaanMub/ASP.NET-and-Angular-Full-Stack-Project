using Microsoft.AspNetCore.Mvc;
using VehicleManagementSystem.Application.DTOs;
using VehicleManagementSystem.Application.Services;

namespace VehicleManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _service;

    public VehicleController(IVehicleService service)
    {
        _service = service;
    }

    [HttpGet] // GET: api/vehicle
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")] // GET: api/vehicle/5
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] VehicleCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPut("{id}")] // PUT: api/vehicle/5
    public async Task<IActionResult> Update(int id, VehicleCreateDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);

        if (!updated)
            return NotFound();
        var result = await _service.GetByIdAsync(id);
        return Ok(new {Message = "Successfully Edited", Data = result });
    }

    [HttpDelete("{id}")] // DELETE: api/vehicle/5
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return result ? Ok(new{Data=result}) : NotFound();
    }
}