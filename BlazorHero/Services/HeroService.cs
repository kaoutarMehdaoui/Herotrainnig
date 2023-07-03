using BlazorHero.Services.Contracts;
using HeroCRUD.ModelDTO;
using System.Net.Http.Json;

namespace BlazorHero.Services
{
    public class HeroService :IHeroService 
    {
        private readonly HttpClient _httpClient;
        public HeroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyList<HeroDTO>> GetAllHeros()
        {
            try
            {
                var reponse = await this._httpClient.GetAsync("api/Heros");

                if (reponse.IsSuccessStatusCode)
                {
                    if (reponse.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return  await Task.FromResult(Enumerable.Empty<HeroDTO>().ToList().AsReadOnly());
                    }
                
                    return await reponse.Content.ReadFromJsonAsync<IReadOnlyList<HeroDTO>>();
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
    }
}
