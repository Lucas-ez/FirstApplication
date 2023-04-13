using FirstApplication.Models;
using FirstApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstApplication.Controllers
{
  public class CustomersController : Controller
  {
    private MyDbContext _context;

    public CustomersController()
    {
      _context = new MyDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }

    public IActionResult Index()
    {
      var customers = _context.Customer.ToList();

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
