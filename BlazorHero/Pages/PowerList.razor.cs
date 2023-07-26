using BlazorHero.Services;
using BlazorHero.Services.Contracts;
using Domain.Models;
using HeroCRUD.ModelDTO;
using IgniteUI.Blazor.Controls;
using Microsoft.AspNetCore.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorHero.Pages
{
    public partial class PowerListBase: ComponentBase
    {
        
        
        [Inject]
         public IPower _power {  get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Filter { get; set; }
        protected bool modalVisible = false;
        protected bool AddVisible = false;
        protected bool EditVisible = false;
        public List<Powers> PowerList = new List<Powers>();
        public PowerDTO OnePower = new PowerDTO();
        public PowerDTO PowerpopToDelete { get; set; }
        protected string ErrorMessage { get; set; }
        protected string sortColumn;
        protected bool ascending = true;

        protected override async Task OnInitializedAsync()
        {
            PowerList = (await _power.GetPowers()).ToList();
            OnePower = new PowerDTO();
           
        }
        public bool FilltringName(Powers powerfilter)
        {
            if (string.IsNullOrEmpty(Filter))
                return true;
            if (powerfilter.Name.ToString().StartsWith(Filter, StringComparison.OrdinalIgnoreCase)||powerfilter.Id.ToString().StartsWith(Filter))
                return true;
            return false;
        }

        public void SortData()
        {
            sortColumn = "Name";
            ascending = !ascending;

            if (ascending)
            {
                PowerList = PowerList.OrderBy(power => power.Name).ToList();
            }
            else
            {
                PowerList = PowerList.OrderByDescending(power => power.Name).ToList();
            }
        }
        public void SortID()
        {
            sortColumn = "ID";
            ascending = !ascending;

            if (ascending)
            {
                PowerList = PowerList.OrderBy(power => power.Id).ToList();
            }
            else
            {
                PowerList = PowerList.OrderByDescending(power => power.Id).ToList();
            }
        }
        protected async void OpenModal(int id)
        {
            modalVisible = true;
            PowerpopToDelete = await _power.GetOnePower(id);
            StateHasChanged();
        }
        protected async void OpenModalEdit(int id)
        {
            EditVisible = true;
            OnePower = await _power.GetOnePower(id);
            StateHasChanged();
        }
        public void DisplayPopup()
        {
            try
            {
                AddVisible = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        //public void EditPopup()
        //{
        //    try
        //    {
        //        EditVisible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMessage = ex.Message;
        //    }
        //}

        protected void CloseModal()
        {
            modalVisible = false;
            AddVisible = false;
            EditVisible = false;
            OnePower = new PowerDTO();


        }
        protected async Task RefreshPage()
        {
           NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }
        protected async void deleteONe(int id)
        {
            try
            {

                await _power.DeletePower(id);
                modalVisible = false;
                await RefreshPage();

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddPower()
        {
            try
            {
                AddVisible = false;
                
                await _power.AddPower(OnePower, NavigationManager);

               
             
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        protected async void EditPower()
        {
            try
            {
                
                    Console.WriteLine("ID " +OnePower.Id +" " +OnePower.Name );
                    EditVisible = false;

                    await _power.UpdatePower(OnePower);
                
                

               

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

    }
}
