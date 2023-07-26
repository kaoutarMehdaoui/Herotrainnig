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
                Console.WriteLine(" UploadPhoto  null");
                throw new ArgumentNullException(nameof(file), "File cannot be null.");
            }
            Console.WriteLine(" UploadPhoto Not null"+file);
            using var stream = file.OpenReadStream();
            using var memoryStream = new MemoryStream();
            Console.WriteLine("console to delete"+ memoryStream);
            await stream.CopyToAsync(memoryStream);
            var fileContent = memoryStream.ToArray();
            Console.WriteLine("console to delete 2" + fileContent);
            var formDataContent = new MultipartFormDataContent() { };
            formDataContent.Add(new ByteArrayContent(fileContent), "file", Name);
            Console.WriteLine("console to delete 2" + formDataContent);
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
