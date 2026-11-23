
using System.Net.Http.Json;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Front.Services;

public class RoomService
{
    private readonly HttpClient _http;

    public RoomService(HttpClient http)
    {
        _http = http;
    }

    // GET: api/Room
    public async Task<List<Room>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Room>>(
            "api/Room") ?? new List<Room>();
    }

    // GET: api/Room/{id}
    public async Task<Room?> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Room>(
            $"api/Room/{id}");
    }

    // POST: api/Room
    public async Task CreateAsync(Room room)
    {
        var response = await _http.PostAsJsonAsync(
            "api/Room", room);

        response.EnsureSuccessStatusCode();
    }

    // PUT: api/Room/{id}
    public async Task UpdateAsync(int id, Room room)
    {
        var response = await _http.PutAsJsonAsync(
            $"api/Room/{id}", room);

        response.EnsureSuccessStatusCode();
    }

    // DELETE: api/Room/{id}
    public async Task DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync(
            $"api/Room/{id}");

        response.EnsureSuccessStatusCode();
    }
}
