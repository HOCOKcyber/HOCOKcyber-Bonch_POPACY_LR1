using Microsoft.AspNetCore.Mvc;
using EquipmentManagement.Domain.Repository;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.API.Controller;


[ApiController]
[Route("api/[controller]")]
public class EquipmentController : ControllerBase
{
    private readonly IEquipmentRepository _repository;

    public EquipmentController(IEquipmentRepository repository)
        {
            _repository = repository;
        }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Equipment>>> GetAll()
    {
        var equipment = await _repository.GetAllAsync();
        return Ok(equipment);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Equipment>> GetById(int id)
    {
        var equipment = await _repository.GetByIdAsync(id);
        
        if (equipment == null)
        {
            return NotFound();
        }
        
        return Ok(equipment);
    }

    [HttpPost]
    public async Task<ActionResult<Equipment>> Create(Equipment equipment)
    {
        await _repository.AddAsync(equipment);

        return CreatedAtAction(nameof(GetById), new { id = equipment.Id }, equipment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Equipment equipment)
    {
        var existingEquipment = await _repository.GetByIdAsync(id);

        if (existingEquipment == null)
        {
            return NotFound();
        }

        equipment.Id = id;

        await _repository.UpdateAsync(equipment);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var equipment = await _repository.GetByIdAsync(id);
        if (equipment == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(id);

        return NoContent();
    }

}