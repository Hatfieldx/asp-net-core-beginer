using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lesson5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lesson5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var driver = new Person()
            {
                Name = "Jons"
            };

            var carLadaSedan = new Car()
            {
                Id = 50,
                Model = "LadaSedan",
                Driver = driver,
                Price = 10
            };
            
            return View(carLadaSedan);
        }
        
        public string Edit(int? id)
        {
            return $"id was {id}";
        }
    }
}