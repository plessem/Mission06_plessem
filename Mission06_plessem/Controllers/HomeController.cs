using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private MovieDatabaseContext _MovieContext { get; set; }

        //constructor
        public HomeController(ILogger<HomeController> logger, MovieDatabaseContext someName)
        {
            _logger = logger;
            _MovieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            //Saving changes to database
            _MovieContext.Add(ar);
            _MovieContext.SaveChanges();

            return View("Confirmation", ar);
        }

        public IActionResult MyPodcasts()
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
