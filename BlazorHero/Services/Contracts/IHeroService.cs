
using Domain.Models;
using HeroCRUD.ModelDTO;
using Microsoft.AspNetCore.Components;

namespace BlazorHero.Services.Contracts
{
    public interface IHeroService
    {
        Task<IReadOnlyList<HeroDTO>> GetAllHeros();
        Task<HeroDTO> GetHeroById(int id);
        
        Task AddHero(HeroDTO heroDTO, NavigationManager navigation);
        Task DeleteHero(int id,NavigationManager navigation);
        Task UpdateHero(HeroDTO heroDTO, NavigationManager navigation);
    }
}
