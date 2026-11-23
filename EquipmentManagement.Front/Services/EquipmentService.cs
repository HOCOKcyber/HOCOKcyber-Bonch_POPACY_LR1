using EquipmentManagement.Domain.Entities;
using System.Net.Http.Json;

namespace EquipmentManagement.Front.Services;

public class EquipmentService
{
    private readonly HttpClient _http;

    public EquipmentService(HttpClient http)
    {
        _http = http;
    }

    // GET: api/Equipment
    public async Task<List<Equipment>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Equipment>>(
            "api/Equipment") ?? new List<Equipment>();
    }

    // GET: api/Equipment/{id}
    public async Task<Equipment?> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Equipment>(
            $"api/Equipment/{id}");
    }

    // POST: api/Equipment
    public async Task CreateAsync(Equipment equipment)
    {
        var response = await _http.PostAsJsonAsync(
            "api/Equipment", equipment);

        response.EnsureSuccessStatusCode();
    }

    // PUT: api/Equipment/{id}
    public async Task UpdateAsync(int id, Equipment equipment)
    {
        var response = await _http.PutAsJsonAsync(
            $"api/Equipment/{id}", equipment);

        response.EnsureSuccessStatusCode();
    }

    // DELETE: api/Equipment/{id}
    public async Task DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync(
            $"api/Equipment/{id}");

        response.EnsureSuccessStatusCode();
    }
}