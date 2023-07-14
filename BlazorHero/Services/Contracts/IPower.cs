using Domain.Models;
using HeroCRUD.ModelDTO;
using Microsoft.AspNetCore.Components;

namespace BlazorHero.Services.Contracts
{
    public interface IPower
    {
        Task<IReadOnlyList<Powers>> GetPowers();
        Task<PowerDTO>GetOnePower(int id );
        Task AddPower(PowerDTO power,NavigationManager NavigationManager);
        Task UpdatePower(PowerDTO power);
        Task DeletePower(int id);
    }
}
