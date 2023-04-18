using FirstApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApplication.Controllers.Api
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomersController : ControllerBase
  {
    private MyDbContext _context;

    public CustomersController(MyDbContext context)
    {
      _context = context;
    }

    // GET /api/customers
    [HttpGet]
    public IEnumerable<Customer> GetCustomers()
    {
      return _context.Customer.ToList();
    }

    // GET /api/customers/1
    [HttpGet("{id}")]
    public Customer GetCustomer(int id)
    {
      var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

      if (customer == null)
      {
        throw new Exception();
      }
      return customer;
    }

    // POST /api/customers
    [HttpPost]
    public Customer PostCustomer(Customer customer)
    {
      if (!ModelState.IsValid)
      {
        throw new Exception();
      }

      _context.Customer.Add(customer);
      _context.SaveChanges();

      return customer;

    }

    [HttpPut("{id}")]
    public void UpdateCustomer(int id, Customer customer)
    {
      if (!ModelState.IsValid)
      {
        throw new Exception();
      }

      var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);

      if (customerInDb == null)
        throw new Exception();

      customerInDb.Name = customer.Name;
      customerInDb.Birthdate = customer.Birthdate;
      customerInDb.IsSubcribedToNewsletter = customer.IsSubcribedToNewsletter;
      customerInDb.MemberShipTypeId = customer.MemberShipTypeId;

      _context.SaveChanges();
    }

    // DELETE /api/customers/1
    [HttpDelete("{id}")]
    public void DeleteCustomer(int id)
    {
      var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);

      if (customerInDb == null)
        throw new Exception();

      _context.Customer.Remove(customerInDb);
      _context.SaveChanges();
    }
  }
}
