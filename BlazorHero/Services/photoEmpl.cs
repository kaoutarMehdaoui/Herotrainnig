using BlazorHero.Services.Contracts;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Syncfusion.Blazor.Charts.Chart.Internal;
using System.Net.Http;

namespace BlazorHero.Services
{
    public class photoEmpl : IPhoto
    {
        private readonly HttpClient _httpClient;

        public photoEmpl(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> UploadPhoto(IBrowserFile file, string Name)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "File cannot be null.");
            }

            using var stream = file.OpenReadStream();
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            var fileContent = memoryStream.ToArray();

            var formDataContent = new MultipartFormDataContent() { };
            formDataContent.Add(new ByteArrayContent(fileContent), "file", Name);
             Console.WriteLine(formDataContent.ToString());
            var response = await _httpClient.PostAsync("/api/Photos", formDataContent);
            Console.WriteLine(response.IsSuccessStatusCode);
            if (response.IsSuccessStatusCode)
            {
                var fileName = await response.Content.ReadAsStringAsync();
                return fileName;
            }
            else
            {
                throw new Exception("Failed to upload photo.");
            }
            
        }
    }


}
