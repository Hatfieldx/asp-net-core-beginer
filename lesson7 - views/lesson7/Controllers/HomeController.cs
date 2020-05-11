using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lesson7.Models;

namespace lesson7.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Car> cars = new List<Car>
            {
                new Car{Model = "Lada", Company = "Boroneg", Age = 99 },
                new Car{Model = "Q5", Company = "Audi", Age = 2 },
                new Car{Model = "Terrano", Company = "volkswagen", Age = 3 },
                new Car{Model = "Passat", Company = "volkswagen", Age = 5 }
            };
            
            return View(cars);
        }

        [HttpGet]
        public IActionResult Index2()
        {
            List<Car> cars = new List<Car>
            {
                new Car{Model = "Lada", Company = "Boroneg", Age = 99 },
                new Car{Model = "Q5", Company = "Audi", Age = 2 },
                new Car{Model = "Terrano", Company = "volkswagen", Age = 3 },
                new Car{Model = "Passat", Company = "volkswagen", Age = 5 }
            };

            return View(cars);
        }

        [HttpGet]
        public IActionResult Index3()
        {
            List<Car> cars = new List<Car>
            {
                new Car{Model = "Lada", Company = "Boroneg", Age = 99 },
                new Car{Model = "Q5", Company = "Audi", Age = 2 },
                new Car{Model = "Terrano", Company = "volkswagen", Age = 3 },
                new Car{Model = "Passat", Company = "volkswagen", Age = 5 }
            };

            return View(cars);
        }
    }
}