using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoStore.Models;
using VideoStore.ViewModels;

namespace VideoStore.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _db;
        public CustomerController()
        {
            _db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        public ActionResult Customers()
        {

            IEnumerable<Customer> customer = _db.Customers.Include(p => p.MembershipType).ToList();
            return View(customer);

        }

        public ActionResult NewCustomer()
        {
            var memberShip = _db.MembershipTypes.ToList();
            var newCustomerViewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipType = memberShip
            };
            return View(newCustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCust(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                NewCustomerViewModel model = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipType = _db.MembershipTypes.ToList()
                };
                return View("NewCustomer", model);
            }

            if (customer.Id == 0)
                _db.Customers.Add(customer);
            else
            {
                var cust = _db.Customers.Single(m => m.Id == customer.Id);
                cust.Name = customer.Name;
                cust.IsSubscribedToNewsLater = customer.IsSubscribedToNewsLater;
                cust.MembershipTypeId = customer.MembershipTypeId;
                cust.CustomerBirthday = customer.CustomerBirthday;
            }

            _db.SaveChanges();
            return RedirectToAction("Customers", "Movies");
        }


        public ActionResult Edit(int id)
        {
            var customer = _db.Customers.SingleOrDefault(p => p.Id == id);
            if (customer == null) return HttpNotFound();

            NewCustomerViewModel newCustomer = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipType = _db.MembershipTypes.ToList()
            };

            return View("NewCustomer", newCustomer);
        }
    }
}