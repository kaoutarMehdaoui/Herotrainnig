
using Domain.Models;
using HeroCRUD.ModelDTO;

namespace BlazorHero.Services.Contracts
{
    public interface IHeroService
    {
        Task<IReadOnlyList<HeroDTO>> GetAllHeros();
        Task<Heros> GetHeroById(int id);
        
        Task AddHero(HeroDTO heroDTO);
        Task DeleteHero(int id);
        Task UpdateHero(HeroDTO heroDTO);
    }
}
