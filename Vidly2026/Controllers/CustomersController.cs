using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2026.Models;
using Vidly2026.ViewModels;

namespace Vidly2026.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(m => m.MembershipType).ToList();

            return View(customers);
        }
                
        // GET: Customers/New
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };

            return View("CustomerForm", viewModel);
        }

        // POST: Customers/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {                
                var viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = _context.MembershipTypes.ToList(),
                    Customer = customer
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        // GET: Customers/Edit/1
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = customer
            };

            return View("CustomerForm", viewModel);
        }

        // GET: Customers/Details/1
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(m => m.MembershipType).FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        // DELETE: Customers/Delete/1
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.Include(m => m.MembershipType).FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}