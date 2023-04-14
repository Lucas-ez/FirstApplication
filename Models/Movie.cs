using System.ComponentModel.DataAnnotations;

namespace FirstApplication.Models
{
  public class Movie
  {
    public int Id { get; set; }

    public string Name { get; set; }

    [Display(Name = "Genre")]
    public MovieGenre MovieGenre { get; set; }

    public byte MovieGenreId { get; set; }

    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    public DateTime AddedDate { get; set; }

    [Display(Name = "Number in Stock")]
    public int Stock { get; set; }

  }
}



