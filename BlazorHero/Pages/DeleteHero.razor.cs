using BlazorHero.Services;
using BlazorHero.Services.Contracts;
using Domain.Models;
using HeroCRUD.ModelDTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;

namespace BlazorHero.Pages
{
    public partial class DeleteHeroBase: ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
         public HeroDTO herotoremove = new HeroDTO();
        
        [Inject]
        public IHeroService _heroService {get; set;}

        private string ErrorMessage { get; set;}
        [Inject]
         public NavigationManager NavigationManager { get; set; }
         protected bool IsSave { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsSave = false;
            herotoremove = await _heroService.GetHeroById(Id);
            
        }
        protected  async Task DeleteHero(int id)
        {
            try
            {
                 IsSave=true;
                 await _heroService.DeleteHero(id, NavigationManager);

            }
            catch (Exception ex)
            {
                ErrorMessage=ex.Message;
            }
            
        }
        protected async  void Cancel()
        {
             NavigationManager.NavigateTo("/Heros");
        }
    }
}
