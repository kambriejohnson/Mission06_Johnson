using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Johnson.Models;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Johnson.Controllers;

public class HomeController : Controller
{
    private MovieDbContext _context;

    public HomeController(MovieDbContext context)
    {
        _context = context;
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
        ViewBag.Categories = _context.Categories.ToList();
        return View(new Movie());
    }

    [HttpPost]
    public IActionResult AddMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        // IMPORTANT: reload categories when validation fails
        ViewBag.Categories = _context.Categories.ToList();
        return View(movie);
    }
    
    public IActionResult MovieList()
    {
        var movies = _context.Movies.ToList();
        return View(movies);
    }
    
    [HttpGet]
    public IActionResult EditMovie(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }

        ViewBag.Categories = _context.Categories.ToList();  

        return View("AddMovie", movie);
    }
    
    [HttpPost]
    public IActionResult EditMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        ViewBag.Categories = _context.Categories.ToList();
        return View("AddMovie", movie);
    }
    
    [HttpGet]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }
    
    [HttpPost]
    public IActionResult DeleteConfirmed(int movieId)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == movieId);

        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        return RedirectToAction("MovieList");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}