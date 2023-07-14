using BlazorHero.Services.Contracts;
using Domain.Models;
using HeroCRUD.ModelDTO;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
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

        public async Task AddHero(HeroDTO heroDTO, NavigationManager navigation)
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
                    navigation.NavigateTo("/Heros");
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

        public  async Task DeleteHero(int id,NavigationManager navigationManager)
        {
            try
            {
                var reponse = await _httpClient.DeleteAsync($"api/Heros/{id}");
                if (reponse.IsSuccessStatusCode)
                {

                    navigationManager.NavigateTo("/Heros");

                }
                 else
                {
                    var message = await reponse.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {reponse.StatusCode} message: {message}");
                }

            }
            catch(Exception ex)
            {
                throw;
            }

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

        public async  Task<HeroDTO> GetHeroById(int id)
        {

           ;
            var result = await _httpClient.GetFromJsonAsync<HeroDTO>($"api/Heros/{id}");
                if (result != null)
                    return result;
                throw new Exception("Hero not found!");

            
        }

        public async Task UpdateHero(HeroDTO heroDTO, NavigationManager navigation)
        {

            try
            {
                var rep = await _httpClient.PutAsJsonAsync<HeroDTO>("api/Heros", heroDTO);
                if(rep.IsSuccessStatusCode)
                {
                   
                    navigation.NavigateTo("/Heros");
                }
                else
                {
                    var message = await rep.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {rep.StatusCode} message: {message}");
                }


            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
