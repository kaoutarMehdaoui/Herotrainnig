using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;

namespace BlazorHero.Services.Contracts
{
    public interface IPhoto
    {
        Task<string> UploadPhoto(IBrowserFile file,string Name);
    }
}
