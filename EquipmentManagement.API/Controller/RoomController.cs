using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagement.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomRepository _repository;

    public RoomController(IRoomRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetAll()
    {
        var rooms = await _repository.GetAllAsync();
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetById(int id)
    {
        var room = await _repository.GetByIdAsync(id);

        if (room == null)
        {
            return NotFound();
        }

        return Ok(room);
    }

    [HttpPost]
    public async Task<ActionResult<Room>> Create(Room room)
    {
        await _repository.AddAsync(room);

        return CreatedAtAction(
            nameof(GetById),
            new { id = room.Id },
            room
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Room room)
    {
        var existingRoom = await _repository.GetByIdAsync(id);

        if (existingRoom == null)
        {
            return NotFound();
        }

        room.Id = id;

        await _repository.UpdateAsync(room);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var room = await _repository.GetByIdAsync(id);

        if (room == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(id);

        return NoContent();
    }
}
