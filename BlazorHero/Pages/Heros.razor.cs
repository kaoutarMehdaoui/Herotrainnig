using BlazorHero.Services.Contracts;
using HeroCRUD.ModelDTO;
using Microsoft.AspNetCore.Components;


namespace BlazorHero.Pages
{
    public partial class HeroBase :ComponentBase
    {
        [Inject]
        public IHeroService _heroService { get; set; }
        public IReadOnlyList<HeroDTO> HeroReturnedFromAPI { get; set;}
       
        protected override async Task OnInitializedAsync()
        {
            HeroReturnedFromAPI = (await _heroService.GetAllHeros()).ToList();
            

         }
        // I added this function to return the request ordered by gender
        protected IOrderedEnumerable<IGrouping<string,HeroDTO>> GetGroupedHeroByGender()
        {
            var result = from hero in HeroReturnedFromAPI group hero by hero.gender into heroByGender orderby heroByGender.Key select heroByGender;
            return result;
        }
        
       
       

    }
}
