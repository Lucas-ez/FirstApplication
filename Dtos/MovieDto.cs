namespace FirstApplication.Dtos
{
  public class MovieDto
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public byte MovieGenreId { get; set; }

    public DateTime ReleaseDate { get; set; }

    public DateTime AddedDate { get; set; }

    public int Stock { get; set; }
  }
}
