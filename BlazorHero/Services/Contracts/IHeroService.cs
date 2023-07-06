
using HeroCRUD.ModelDTO;

namespace BlazorHero.Services.Contracts
{
    public interface IHeroService
    {
        Task<IReadOnlyList<HeroDTO>> GetAllHeros();
        
    }
}
