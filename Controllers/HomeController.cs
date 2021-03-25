using ASSIGNMENT9._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASSIGNMENT9._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieListContext context { get; set; }

        //constructor
        public HomeController(ILogger<HomeController> logger, MovieListContext con)
        {
            _logger = logger;
            context = con;
        }

        public IActionResult Index()
        {
            return View(context.Movies);
        }
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(Movie M)
        {
            //add data 
            if (ModelState.IsValid)
            {
                context.Movies.Add(M);
                context.SaveChanges();
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Podcasts()
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
