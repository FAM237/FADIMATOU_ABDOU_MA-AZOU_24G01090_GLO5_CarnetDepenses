using CarnetDepenses.Models;
using System.Net.Http.Json;

namespace CarnetDepenses.Services
{
    public interface IApiService { Task<TauxReponse> GetTauxAsync(); }

    public class ApiService : IApiService
    {
        private readonly HttpClient _http;
        // HttpClient fourni par injection de dépendances.
        public ApiService(HttpClient http) => _http = http;

        // GET + contrôle du code + lecture + désérialisation.
        public async Task<TauxReponse> GetTauxAsync() =>
            await _http.GetFromJsonAsync<TauxReponse>("https://api.exemple.ce/taux")
            ?? throw new InvalidOperationException("Réponse vide");
    }
}
