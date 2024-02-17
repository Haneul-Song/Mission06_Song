using Microsoft.AspNetCore.Mvc;
using Mission06_Song.Models;
using System.Diagnostics;

namespace Mission06_Song.Controllers
{
    public class HomeController : Controller
    {
        private MovieAddedContext _context;
        public HomeController(MovieAddedContext temp) 
        {
               _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetToKnowJoel()
        {
            return View();
        }
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovie response)
        {
            _context.MoviesAdded.Add(response);
            _context.SaveChanges();
                
            return View("Confirmation");
        }
    }
}
