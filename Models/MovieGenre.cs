using System.ComponentModel.DataAnnotations;

namespace FirstApplication.Models
{
  public class MovieGenre
  {
    public byte Id { get; set; }
    [StringLength(100)]
    public string Name { get; set; }
  }
}
