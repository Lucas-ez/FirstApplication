using FirstApplication.Models;
using FirstApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstApplication.Controllers
{
  public class CustomersController : Controller
  {
    public IActionResult Index()
    {
      var customers = new List<Customer>
      {
        new Customer {Id = 1, Name = "John Smith"},
        new Customer {Id = 2, Name = "Mary Williams"}
      };

      var viewModel = new CustomersViewModel { Customers = customers };

      return View(viewModel);
    }
    public IActionResult Details(int id)
    {

      var customers = new List<Customer>
      {
        new Customer {Id = 1, Name = "John Smith"},
        new Customer {Id = 2, Name = "Mary Williams"}
      };

      var customer = customers.Find(c => c.Id == id);

      if (customer == null) return StatusCode(404);

      return View(customer);
    }
  }
}
