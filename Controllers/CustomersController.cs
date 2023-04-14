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

		public IActionResult New()
		{
			var membershipTypes = _context.MembershipType.ToList();
			var viewModel = new FormCustomerViewModel
			{
				MembershipTypes = membershipTypes
			};
			return View("Form", viewModel);
		}

		[HttpPost]
		public IActionResult Create(Customer customer)
		{
			_context.Customer.Add(customer);
			_context.SaveChanges();

			return RedirectPermanent("/Customers");
		}

		public IActionResult Index()
		{
			var customers = _context.Customer.Include(c => c.MembershipType).ToList();

			var viewModel = new CustomersViewModel { Customers = customers };

			return View(viewModel);
		}
		public IActionResult Details(int id)
		{
			var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

			if (customer == null) return StatusCode(404);

			return View(customer);
		}
	}
}
