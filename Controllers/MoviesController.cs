using FirstApplication.Models;
using FirstApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstApplication.Controllers
{
  public class MoviesController : Controller
  {
    public IActionResult Index()
    {
      var movies = new List<Movie>
      {
        new Movie() {Id = 1, Name = "Shrek"},
        new Movie() {Id = 2, Name = "Wall-e"}
      };

      var viewModel = new MoviesViewModel { Movies = movies };

      return View(viewModel);
    }

    public IActionResult Random()
    {
      var movie = new Movie() { Id = 1, Name = "Harry Potter" };
      var customers = new List<Customer>
      {
        new Customer { Name = "Customer1"},
        new Customer { Name = "Customer2"}
      };

      var viewModel = new RandomMovieViewModel
      {
        Movie = movie,
        Customers = customers
      };

      return View(viewModel);
    }
  }
}
