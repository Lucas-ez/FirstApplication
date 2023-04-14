using FirstApplication.Models;
using FirstApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApplication.Controllers
{
  public class MoviesController : Controller
  {
    private MyDbContext _context;

    public MoviesController(MyDbContext context)
    {
      _context = context;
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }
    public IActionResult Index()
    {
      var movies = _context.Movie.Include(c => c.MovieGenre).ToList();

      var viewModel = new MoviesViewModel { Movies = movies };

      return View(viewModel);
    }

    public IActionResult Details(int id)
    {
      var movie = _context.Movie.Include(m => m.MovieGenre).SingleOrDefault(m => m.Id == id);

      if (movie == null) return StatusCode(404);

      return View(movie);
    }

  }
}
