using BlazorHero.Services.Contracts;
using Domain.Models;
using HeroCRUD.ModelDTO;
using System.Net.Http.Json;

namespace BlazorHero.Services
{
    public class PowerService : IPower
    {
        private readonly HttpClient _httpClient;
        public PowerService(HttpClient http)
        {
            _httpClient = http;
        }
        public Task AddPower(PowerDTO power)
        {
            throw new NotImplementedException();
        }

        public Task DeletePower(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PowerDTO> GetOnePower(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Powers>> GetPowers()
        {
            try
            {
                var reponse = await this._httpClient.GetAsync("api/Power");
                 if(reponse.IsSuccessStatusCode)
                {
                    if(reponse.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return await Task.FromResult(Enumerable.Empty<Powers>().ToList().AsReadOnly());
                    }
                    return  await reponse.Content.ReadFromJsonAsync<IReadOnlyList<Powers>>();
                }
                else
                {
                    var message = await reponse.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {reponse.StatusCode} message: {message}");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public Task UpdatePower(PowerDTO power)
        {
            throw new NotImplementedException();
        }
    }
}
