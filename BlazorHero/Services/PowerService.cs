using BlazorHero.Services.Contracts;
using Domain.Models;
using HeroCRUD.ModelDTO;
using Microsoft.AspNetCore.Components;
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
        public async Task AddPower(PowerDTO power,NavigationManager navigationManager)
        {
            
            try
            {
                var reslt = await _httpClient.PostAsJsonAsync<PowerDTO>("api/Power", power);
                if (reslt.IsSuccessStatusCode)
                {
                    if (reslt.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {

                        Console.WriteLine("removed");
                    }
                   
                    PowerDTO PowerDTOAdd = await reslt.Content.ReadFromJsonAsync<PowerDTO>();
                    navigationManager.NavigateTo(navigationManager.Uri, forceLoad: true);
                }
                else
                {
                    var message = await reslt.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {reslt.StatusCode} message: {message}");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeletePower(int id)
        {
            try
            {
                
                var reponse = await _httpClient.DeleteAsync($"api/Power/{id}");
                if (reponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Power Removed");
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

        public async  Task<PowerDTO> GetOnePower(int id)
        {
            try
            {
                
                var result = await _httpClient.GetFromJsonAsync<PowerDTO>($"api/Power/{id}");
                if (result != null)
                {
                   
                    return result;
                }
                    
                throw new Exception("Hero not found!");
            }catch (Exception ex)
            {
                throw;
            }
          
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

        public async Task UpdatePower(PowerDTO power)
        {
            try
            {
                var reslt = await _httpClient.PutAsJsonAsync<PowerDTO>("api/Power", power);

                if (reslt.IsSuccessStatusCode)
                {

                    Console.WriteLine("Power modified");
                }
                else
                {
                    var message = await reslt.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {reslt.StatusCode} message: {message}");
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
