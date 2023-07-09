using BlazorHero.Services.Contracts;
using Domain.Models;
using HeroCRUD.ModelDTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorHero.Pages
{
    public partial class AddHeroBase: ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        public HeroDTO HeroToAdd = new HeroDTO()
        {
            photo = "",
            Description = "",
            gender = ""
        };
        public string ErrorMessage { get; set; }
        [Inject]
        public IHeroService _heroService { get; set; }
        private EditContext editContext;
        protected override async Task OnInitializedAsync()
        {
            editContext=new EditContext(HeroToAdd);
        }
        protected async Task AddHeroClick()
        {
           


            try
            {
                
                await _heroService.AddHero(HeroToAdd);
                Console.WriteLine("Hero added successfully!");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
