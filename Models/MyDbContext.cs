using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FirstApplication.Models
{
  public class MyDbContext : IdentityDbContext
  {
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    // Agrego los modelos / tablas
    public DbSet<Movie> Movie { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<MembershipType> MembershipType { get; set; }
    public DbSet<MovieGenre> MovieGenre { get; set; }
  }
}
