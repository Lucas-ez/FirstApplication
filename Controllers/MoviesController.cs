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

		public IActionResult New()
		{
			var movieGenres = _context.MovieGenre.ToList();

			var viewModel = new FormMovieViewModel
			{
				MovieGenres = movieGenres
			};

			return View("Form", viewModel);
		}

		public IActionResult Edit(int id)
		{
			var movie = _context.Movie.SingleOrDefault(m => m.Id == id);

			if (movie == null) return StatusCode(404);

			var viewModel = new FormMovieViewModel
			{
				Movie = movie,
				MovieGenres = _context.MovieGenre.ToList()
			};
			return View("Form", viewModel);
		}

		[ValidateAntiForgeryToken]
		public IActionResult Save(Movie movie)
		{

			//Validations
			if (!ModelState.IsValid)
			{
				var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
				// Error, toma el campo Genre como required
				if (!(errors.Count == 1 && errors[0].ErrorMessage == "The Genre field is required."))
				{
					var viewModel = new FormMovieViewModel
					{
						Movie = movie,
						MovieGenres = _context.MovieGenre.ToList()
					};

					return View("Form", viewModel);
				}
			}


			if (movie.Id == 0)
			{
				movie.AddedDate = DateTime.Today;
				_context.Movie.Add(movie);
			}
			else
			{
				var movieInDb = _context.Movie.Single(m => m.Id == movie.Id);

				movieInDb.Name = movie.Name;
				movieInDb.Stock = movie.Stock;
				movieInDb.MovieGenreId = movie.MovieGenreId;
				movieInDb.AddedDate = movie.AddedDate;
			}

			_context.SaveChanges();

			return RedirectPermanent("/Movies");
		}
	}
}
