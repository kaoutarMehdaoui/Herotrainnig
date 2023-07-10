﻿using BlazorHero.Services.Contracts;
using Domain.Models;
using HeroCRUD.ModelDTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Runtime.CompilerServices;

namespace BlazorHero.Pages
{
    public partial class AddHeroBase: ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        public HeroDTO HeroToAdd = new HeroDTO()
        {
            photo = "",
            Description = "",
            gender = ""
        };
        public string ErrorMessage { get; set; }
        [Inject]
        public IHeroService _heroService { get; set; }

       protected async override Task OnInitializedAsync()
        {
            if(Id != null && Id!=0) 
            {
                HeroToAdd = await _heroService.GetHeroById(Id);

            }
            else
            {
                HeroToAdd = new HeroDTO() { };
            }
        }


        protected async Task AddHeroClick()
        {
           
            try
            {
                if (Id != null && Id !=0) {

                    await _heroService.UpdateHero(HeroToAdd, NavigationManager);
                }
                else
                {
                    await _heroService.AddHero(HeroToAdd, NavigationManager);
                    Console.WriteLine("Hero added successfully!");
                }
                
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        protected void Cancel() 
        {
            NavigationManager.NavigateTo("/Heros");
        }

    }
}
