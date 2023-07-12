using BlazorHero.Services.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorHero.Pages
{
    public partial class PowerListBase: ComponentBase
    {
        [Inject]
         public IPower _power {  get; set; }
         public List<Powers> PowerList = new List<Powers>();
        protected override async Task OnInitializedAsync()
        {
            PowerList = (await _power.GetPowers()).ToList();
        }
    }
}
