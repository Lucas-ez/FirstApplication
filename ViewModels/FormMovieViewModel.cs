using FirstApplication.Models;

namespace FirstApplication.ViewModels
{
  public class FormMovieViewModel
  {
    public Movie Movie { get; set; }
    public IEnumerable<MovieGenre> MovieGenres { get; set; }
  }
}
