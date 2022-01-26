using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission4Assignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieApplicationContext _blahContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieApplicationContext someName)
        {
            //Configures connection to database
            _logger = logger;
            _blahContext = someName;
        }

        public IActionResult Index()
        {
            //Returns homepage view
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            //Returns the AddMovieView when visiting the page
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(ApplicationResponse movie)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            
            //Proposes and saves changes to the database once the form is submitted
            _blahContext.Add(movie);
            _blahContext.SaveChanges();
            return View("Confirmation", movie);
        }

        public IActionResult Podcast()
        {
            //Returns the Podcast view
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
