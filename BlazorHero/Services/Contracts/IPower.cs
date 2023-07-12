using Domain.Models;
using HeroCRUD.ModelDTO;

namespace BlazorHero.Services.Contracts
{
    public interface IPower
    {
        Task<IReadOnlyList<Powers>> GetPowers();
        Task<PowerDTO>GetOnePower(int id);
        Task AddPower(PowerDTO power);
        Task UpdatePower(PowerDTO power);
        Task DeletePower(int id);
    }
}
