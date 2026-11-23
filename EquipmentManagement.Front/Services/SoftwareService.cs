
using System.Net.Http.Json;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Front.Services;

public class SoftwareService
{
    private readonly HttpClient _http;

    public SoftwareService(HttpClient http)
    {
        _http = http;
    }

    // GET: api/Software
    public async Task<List<Software>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<Software>>(
            "api/Software") ?? new List<Software>();
    }

    // GET: api/Software/{id}
    public async Task<Software?> GetByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Software>(
            $"api/Software/{id}");
    }

    // POST: api/Software
    public async Task CreateAsync(Software software)
    {
        var response = await _http.PostAsJsonAsync(
            "api/Software", software);

        response.EnsureSuccessStatusCode();
    }

    // PUT: api/Software/{id}
    public async Task UpdateAsync(int id, Software software)
    {
        var response = await _http.PutAsJsonAsync(
            $"api/Software/{id}", software);

        response.EnsureSuccessStatusCode();
    }

    // DELETE: api/Software/{id}
    public async Task DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync(
            $"api/Software/{id}");

        response.EnsureSuccessStatusCode();
    }
}
