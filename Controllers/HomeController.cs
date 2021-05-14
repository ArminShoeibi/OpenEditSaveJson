using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OpenEditSaveJson.DTOs;
using OpenEditSaveJson.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenEditSaveJson.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            DirectoryInfo directoryInfo = new(contentRootPath);
            FileInfo[] jsonFiles = directoryInfo.GetFiles(searchPattern: "*.json");

            List<JsonFileViewModel> jsonFileViewModels = jsonFiles.Select(j => new JsonFileViewModel
            {
                Name = j.Name,
                FullName = j.FullName,
                Directory = j.DirectoryName,
            }).ToList();

            return View(jsonFileViewModels);
        }

        public async Task<IActionResult> GetJsonFile(string path)
        {
            bool isJsonFileExist = System.IO.File.Exists(path);

            if (isJsonFileExist is false)
            {
                return Json("Wrong Path, Please refresh the page.");
            }

            string jsonFileAsOneString = await System.IO.File.ReadAllTextAsync(path);

            Dictionary<string,dynamic> deserializedJsonFile = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(jsonFileAsOneString);
         
            return Json(deserializedJsonFile);
            
        }

        [HttpPost]
        public IActionResult UpdateJsonFile(UpdateJsonFileDto dto)
        {
            //TODO:
            return Ok();
        }
    }
}
