using BlazorHero.Services.Contracts;
using HeroCRUD.ModelDTO;
using Microsoft.AspNetCore.Components;

namespace BlazorHero.Pages
{
    public class HeroBase :ComponentBase
    {
        [Inject]
        public IHeroService _heroService { get; set; }
        public IReadOnlyList<HeroDTO> HeroReturnedFromAPI { get; set;}
        protected override async Task OnInitializedAsync()
        {
            HeroReturnedFromAPI = (await _heroService.GetAllHeros()).ToList();
        }
    }
}
