using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lesson6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lesson6.Controllers
{
    public class HomeController : Controller
    {
        [Route("DoOrder")][HttpPost]
        public IActionResult DoOrder(IEnumerable<Product> products)
        {
          return View("ShowOrderedProducts", products);
        }

        [Route("RegisterPizza")][HttpPost]
        public IActionResult RegisterPizza(User user)
        {
            if (user?.Age < 16)
                return Content("Access denied. Your age is less 16");
            else
                return View("InputCount");
        }

        [Route("RegisterPizza")][HttpGet]
        public IActionResult RegisterPizza()
        {
           return View();
        }

        [Route("GetOrderTemplate")][HttpPost]
        public IActionResult GetOrderTemplate(int? count)
        {
            if (count != null && count != 0)
            {
                ViewBag.ProductCount = count;
                return View("OrderTemplate");
            }

            return Content("wrong data");
        }

        public IActionResult Index()
        {
            return View(GetPLModelCollectionn(5));
        }
        [Route("Register")] [HttpPost]
        public IActionResult Register(UserRegistration userData)
        {
            if (userData?.Age < 14)
                return Content("Access denied. Your age is less 14");
            else
                return Content("Gracias seniore");
        }

        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [NonAction]
        private IEnumerable<ProgrammingLanguage> GetPLModelCollectionn(int v)
        {
            var rnd = new Random();

            List<ProgrammingLanguage> result = new List<ProgrammingLanguage>();

            for (int i = 1; i <= v; i++)
            {
                result.Add(new ProgrammingLanguage() {Name = $"Random language number {rnd.Next(1, 1000)}"});
            }
            return result;            
        }
    }
}