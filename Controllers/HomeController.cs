using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {

        private MoviesContext DaContext { get; set; }

        public HomeController(MoviesContext x)
        {
            DaContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EnterMovies()
        {
            ViewBag.Categories = DaContext.Categories.ToList();
                        
            return View();
        }
        [HttpPost]
        public IActionResult EnterMovies(EnterMovies em)
        {
            if (ModelState.IsValid)
            {
                DaContext.Add(em);
                DaContext.SaveChanges();

                return View("MovieEntered", em);
            }
            else
            {
                ViewBag.Categories = DaContext.Categories.ToList();

                return View(em);
            }
        }

        public IActionResult MovieList ()
        {
            var movies = DaContext.responses
                .Include(x => x.Category)
                .ToList();
            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = DaContext.Categories.ToList();

            var application = DaContext.responses.Single(x => x.MovieID == movieid);

            return View("EnterMovies", application);
        }
        [HttpPost]
        public  IActionResult Edit (EnterMovies blah)
        {
            DaContext.Update(blah);
            DaContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = DaContext.responses.Single(x => x.MovieID == movieid);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(EnterMovies em)
        {
            DaContext.responses.Remove(em);
            DaContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
