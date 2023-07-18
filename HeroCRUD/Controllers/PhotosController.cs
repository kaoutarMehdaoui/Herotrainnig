using Application.Migrations;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Numerics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using HeroCRUD.Imagestorage;

namespace HeroCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _photoFolderPath;

        public PhotosController(IWebHostEnvironment webHostEnvironment,IOptions<FilePathSettings> fileSetting)
        {
            _webHostEnvironment = webHostEnvironment;
            _photoFolderPath = fileSetting.Value.PhotoFolder;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file found.");
            }

            string folderPath = Path.Combine(_photoFolderPath, "Images", "PhotoHero");
            string fileName = file.FileName;
            string filePath = Path.Combine(folderPath, fileName);

            Directory.CreateDirectory(folderPath);

            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok(fileName);
        }

    }
}
