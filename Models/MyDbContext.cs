using Microsoft.EntityFrameworkCore;

namespace FirstApplication.Models
{
  public class MyDbContext : DbContext
  {
    public MyDbContext()
    {
    }

    // Agrego los modelos / tablas
    public DbSet<Movie> Movie { get; set; }
    public DbSet<Customer> Customer { get; set; }
  }
}
