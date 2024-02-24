using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Song.Models;
using System.ComponentModel;
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

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", new AddMovie());
        }

        [HttpPost]
        public IActionResult AddMovie(AddMovie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }

        }

        public IActionResult WaitList()
        {
            // Linq
            var applications = _context.Movies.Include("Category").ToList();

            return View(applications);  
        }

        [HttpGet]
        public IActionResult Edit(int id)
        { 
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(AddMovie updatedInfo) 
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("WaitList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(AddMovie application)
        {
            _context.Movies.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("WaitList");
        }

    }
}
