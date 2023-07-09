using BlazorHero.Services.Contracts;
using Domain.Models;
using HeroCRUD.ModelDTO;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BlazorHero.Services
{
    public class HeroService :IHeroService 
    {
        private readonly HttpClient _httpClient;
        public HeroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddHero(HeroDTO heroDTO)
        {
            try
            {
                var reponse = await _httpClient.PostAsJsonAsync<HeroDTO>("api/Heros", heroDTO);

                if (reponse.IsSuccessStatusCode)
                {
                    if (reponse.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return ;
                    }

                    HeroDTO heroDTOAdd= await reponse.Content.ReadFromJsonAsync<HeroDTO>();
                   
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

        public Task DeleteHero(int id)
        {
            throw new NotImplementedException();
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

        public async  Task<Heros> GetHeroById(int id)
        {
           
           
                var result = await _httpClient.GetFromJsonAsync<Heros>($"api/Heros/{id}");
                if (result != null)
                    return result;
                throw new Exception("Hero not found!");

            
        }

        public Task UpdateHero(HeroDTO heroDTO)
        {
            throw new NotImplementedException();
        }
    }
}
