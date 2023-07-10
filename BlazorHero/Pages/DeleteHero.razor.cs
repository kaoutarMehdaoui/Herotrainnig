using BlazorHero.Services;
using BlazorHero.Services.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;

namespace BlazorHero.Pages
{
    public partial class DeleteHeroBase: ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
         public Heros herotoremove = new Heros();
        
        [Inject]
        public IHeroService _heroService {get; set;}

        private string ErrorMessage { get; set;}
        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            
            herotoremove = await _heroService.GetHeroById(Id);
            
        }
        protected async void DeleteHero(int id)
        {
            try
            {
                
                await _heroService.DeleteHero(id);
                Console.WriteLine("Hero Deleted successfully!");
                Cancel();// I must Update redirection 

            }
            catch (Exception ex)
            {
                ErrorMessage=ex.Message;
            }
            
        }
        protected void Cancel()
        {
            NavigationManager.NavigateTo("/Heros");
        }
    }
}
