﻿using FirstApplication.Models;
using FirstApplication.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstApplication.Controllers
{
  [Authorize]
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

    [ValidateAntiForgeryToken]
    [HttpPost]
    public IActionResult Save(Customer customer)
    {
      if (customer.Id == 0)
      {
        _context.Customer.Add(customer);
      }
      else
      {
        var customerInDb = _context.Customer.Single(c => c.Id == customer.Id);
        customerInDb.Name = customer.Name;
        customerInDb.Birthdate = customer.Birthdate;
        customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
        customerInDb.IsSubcribedToNewsletter = customer.IsSubcribedToNewsletter;
      }

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
    public IActionResult Edit(int id)
    {
      var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

      if (customer == null) return StatusCode(404);

      var viewModel = new FormCustomerViewModel
      {
        Customer = customer,
        MembershipTypes = _context.MembershipType.ToList()
      };
      return View("Form", viewModel);
    }
  }
}
