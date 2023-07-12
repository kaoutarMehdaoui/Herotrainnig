using BlazorHero;

using BlazorHero.Services;
using BlazorHero.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44348/") });
builder.Services.AddScoped<IHeroService, HeroService>();
builder.Services.AddScoped<IPower, PowerService>();
builder.Services.AddIgniteUIBlazor();
builder.Services.AddSyncfusionBlazor();


await builder.Build().RunAsync();
