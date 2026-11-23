using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SoftwareController : ControllerBase
{
    private readonly ISoftwareRepository _repository;

    public SoftwareController(ISoftwareRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Software>>> GetAll()
    {
        var software = await _repository.GetAllAsync();
        return Ok(software);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Software>> GetById(int id)
    {
        var software = await _repository.GetByIdAsync(id);

        if (software == null)
        {
            return NotFound();
        }

        return Ok(software);
    }

    [HttpPost]
    public async Task<ActionResult<Software>> Create(Software software)
    {
        await _repository.AddAsync(software);

        return CreatedAtAction(
            nameof(GetById),
            new { id = software.Id },
            software
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Software software)
    {
        var existingSoftware = await _repository.GetByIdAsync(id);

        if (existingSoftware == null)
        {
            return NotFound();
        }

        software.Id = id;

        await _repository.UpdateAsync(software);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var software = await _repository.GetByIdAsync(id);

        if (software == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(id);

        return NoContent();
    }
}