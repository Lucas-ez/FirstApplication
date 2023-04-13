using FirstApplication.Models;
using FirstApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApplication.Controllers
{
  public class CustomersController : Controller
  {
    private MyDbContext _context;

    public CustomersController(MyDbContext context)
    {
      _context = context;
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }

    public IActionResult Index()
    {
      var customers = _context.Customer.Include(c => c.MembershipType).ToList();

      var viewModel = new CustomersViewModel { Customers = customers };

      return View(viewModel);
    }
    public IActionResult Details(int id)
    {

      var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

      if (customer == null) return StatusCode(404);

      return View(customer);
    }
  }
}
