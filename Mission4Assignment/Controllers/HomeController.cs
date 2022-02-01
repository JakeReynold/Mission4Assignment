using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieApplicationContext MovieContext { get; set; }

        //Constructor
        public HomeController(MovieApplicationContext someName)
        {
            //Configures connection to database
            MovieContext = someName;
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

            ViewBag.Categories = MovieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieInfo movie)
        {
            //If required fields in the modle aren't filled out, this stops the form from submitting
            if(!ModelState.IsValid)
            {
                ViewBag.Categories = MovieContext.Categories.ToList();
                return View();
            }
            
            //Proposes and saves changes to the database once the form is submitted
            MovieContext.Add(movie);
            MovieContext.SaveChanges();
            return View("Confirmation", movie);
        }

        public IActionResult Podcast()
        {
            //Returns the Podcast view
            return View();
        }

        public IActionResult MovieList ()
        {
            //Returns the MovieList View
            var movie = MovieContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movie);
        }
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            var movie = MovieContext.Movies.Single(x => x.MovieID == movieid);

            return View("AddMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieInfo blah)
        {
            MovieContext.Update(blah);
            MovieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = MovieContext.Movies.Single(x => x.MovieID == movieid);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieInfo movie)
        {
            MovieContext.Movies.Remove(movie);
            MovieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
