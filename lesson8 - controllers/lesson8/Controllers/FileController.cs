using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using lesson8.Models;
using Microsoft.AspNetCore.Hosting;

namespace lesson8.Controllers
{
    public class FileController : Controller
    {
        IWebHostEnvironment _webHost;
        
        [HttpGet]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowFile(Person person)
        {
            var sessionID = HttpContext.Session.Id;

            string path = Path.Combine(_webHost.ContentRootPath, "Files", sessionID + ".txt");

            System.IO.File.WriteAllText(path, $"\nName {person.Name} \nSurname {person.Surname} \nFileName {person.Filename}");

            return PhysicalFile(path, "text/plain", person.Filename);
        }

        public FileController(IWebHostEnvironment env)
        {
            _webHost = env;
        }
    }
}