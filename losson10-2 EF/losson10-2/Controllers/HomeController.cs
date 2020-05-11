using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using losson10_2.Models;
using losson10_2.Models.Context;

namespace losson10_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _dbcontext;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;

            _dbcontext = context;
        }

        public IActionResult Create()
        {
            int? lastId = _dbcontext.Companies
                                    .OrderBy(x => x.Id)
                                    .Select(x => x.Id)
                                    .LastOrDefault();

            if (lastId == null)
                lastId = 0;
            else
                lastId += 1;

            List<Company> newCompanies = new List<Company>();
            
            for (int i = lastId.Value; i < lastId.Value + 5; i++)
            {
                newCompanies.Add(new Company {Name = $"Company{i}", Country = $"Country{i}"});
            }

            _dbcontext.Companies.AddRange(newCompanies);

            _dbcontext.SaveChanges();

            return View("CompanyList", _dbcontext.Companies.ToList());
        }

        public IActionResult ShowCompanies()
        {
          return View("CompanyList", _dbcontext.Companies.ToList());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
