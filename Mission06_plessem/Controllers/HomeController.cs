using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_plessem.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_plessem.Controllers
{
    public class HomeController : Controller
    {
        
        private MovieDatabaseContext _MovieContext { get; set; }

        //constructor
        public HomeController(MovieDatabaseContext someName)
        {
           
            _MovieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm ()
        {
            ViewBag.Categories = _MovieContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                //Saving changes to database
                _MovieContext.Add(ar);
                _MovieContext.SaveChanges();

                return View("Confirmation", ar);
            }
            //if invalid
            else
            {
                ViewBag.Categories = _MovieContext.Categories.ToList();
                return View(ar);
            }


        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        public IActionResult List()
        {
            var movies = _MovieContext.Responses
                .Include(x=> x.Category)
                .ToList();
            return View(movies);
        }

        //creating edit and delete
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _MovieContext.Categories.ToList();
            var application = _MovieContext.Responses.Single(x=> x.MovieId == id);

            return View("MovieForm", application);
        }

        [HttpPost]
        public IActionResult Edit (ApplicationResponse blah)
        {
            _MovieContext.Update(blah);
            _MovieContext.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
