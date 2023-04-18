using FirstApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApplication.Controllers.Api
{
  [Route("api/[controller]")]
  [ApiController]
  public class MoviesController : ControllerBase
  {
    private MyDbContext _context;

    public MoviesController(MyDbContext context)
    {
      _context = context;
    }

    // GET /api/movies
    [HttpGet]
    public IEnumerable<Movie> GetMovies()
    {
      return _context.Movie.ToList();
    }

    // GET /api/movies/1
    [HttpGet("{id}")]
    public Movie GetMovie(int id)
    {
      var movie = _context.Movie.SingleOrDefault(c => c.Id == id);

      if (movie == null)
      {
        throw new Exception();
      }
      return movie;
    }

    // POST /api/movies
    [HttpPost]
    public Movie PostCustomer(Movie movie)
    {
      if (!ModelState.IsValid)
      {
        throw new Exception();
      }

      _context.Movie.Add(movie);
      _context.SaveChanges();

      return movie;

    }

    [HttpPut("{id}")]
    public void UpdateMovie(int id, Movie movie)
    {
      if (!ModelState.IsValid)
      {
        throw new Exception();
      }

      var movieInDb = _context.Movie.SingleOrDefault(c => c.Id == id);

      if (movieInDb == null)
        throw new Exception();

      //movieInDb.ReleaseDate = movie.Name;
      //movieInDb.Birthdate = movie.Birthdate;
      //movieInDb.IsSubcribedToNewsletter = movie.IsSubcribedToNewsletter;
      //movieInDb.MemberShipTypeId = movie.MemberShipTypeId;

      _context.SaveChanges();
    }

    // DELETE /api/movies/1
    [HttpDelete("{id}")]
    public void DeleteMovies(int id)
    {
      var movieInDb = _context.Movie.SingleOrDefault(c => c.Id == id);

      if (movieInDb == null)
        throw new Exception();

      _context.Movie.Remove(movieInDb);
      _context.SaveChanges();
    }
  }
}
