using BlazorHero.Services.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorHero.Pages
{
    public partial class HeroDetailsBase :ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IHeroService _heroService { get; set; }
        public Heros HeroDTODetails = new Heros();
        public string? ErroMessage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                HeroDTODetails = await _heroService.GetHeroById(Id);
            }
            catch (Exception ex)
            {
                ErroMessage = ex.Message;
            }



        }
    }
}
