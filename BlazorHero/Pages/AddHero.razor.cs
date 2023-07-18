using BlazorHero.Services.Contracts;
using Domain.Models;
using HeroCRUD.ModelDTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Tewr.Blazor.FileReader;

namespace BlazorHero.Pages
{
    public partial class AddHeroBase: ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        public string NameImageToSend { get; set; }
        public IBrowserFile fileToSave {get; set;}
        
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
         public bool IsSaved { get; set; }
        public HeroDTO HeroToAdd { get; set; }
        public string ErrorMessage { get; set; }
        [Inject]
        public IHeroService _heroService { get; set; }
        public IBrowserFile selectedImage {get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }   
        bool imagLoad { get; set; }
        [Inject]
        public IPhoto photo { get; set; }
       


        protected async override Task OnInitializedAsync()
        {
            IsSaved= false;
            if(Id != null && Id!=0) 
            {
                HeroToAdd = await _heroService.GetHeroById(Id);
                
            }
            else
            {
                HeroToAdd = new HeroDTO()
                {
                    photo = "",
                    Description = "",
                    gender = ""
                }; 
            } 
        }
        protected async Task LoadFiles(InputFileChangeEventArgs e)
        {
            var file = e.File;

            if (file != null)
            {
                var folderPath = "/Images/PhotoHero";
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.Name)}";
                var filePath = Path.Combine(folderPath, fileName);
                    HeroToAdd.photo = filePath;
                NameImageToSend = fileName;
                fileToSave = file;
               
                Console.WriteLine($"Photo uploaded successfully. File name: {fileName}");
            }
            else
            {
                Console.WriteLine("Failed to upload photo.");
            }
        }



        protected async Task AddHeroClick()
        {
           
            try
            {
                IsSaved= true;
                Console.WriteLine(HeroToAdd.photo);
              
                if (Id != null && Id !=0) {


                    await photo.UploadPhoto(fileToSave, NameImageToSend);
                    Console.WriteLine(HeroToAdd.photo);


                        await _heroService.UpdateHero(HeroToAdd, NavigationManager);
                   
                    Console.WriteLine(HeroToAdd.photo);
                    
                    
                }
                else
                {
                    Console.WriteLine(HeroToAdd.photo);
                    await photo.UploadPhoto(fileToSave, NameImageToSend);
                    await _heroService.AddHero(HeroToAdd, NavigationManager);
                        Console.WriteLine("Hero added successfully!");
                    
                    Console.WriteLine(HeroToAdd.photo);

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
