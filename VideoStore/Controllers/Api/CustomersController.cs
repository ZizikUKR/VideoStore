using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoStore.Models;

namespace VideoStore.Controllers.Api
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Customer> Customers()
        {
            return _dbContext.Customers.ToList();
        }

        public Customer Customer (int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(p => p.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int id,Customer customer)
        {
           var customerInDB = _dbContext.Customers.SingleOrDefault(p => p.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            customerInDB.Name = customer.Name;
            customerInDB.MembershipTypeId = customer.MembershipTypeId;
            customerInDB.IsSubscribedToNewsLater = customer.IsSubscribedToNewsLater;
            customerInDB.CustomerBirthday = customer.CustomerBirthday;

            _dbContext.SaveChanges();
            
        }

        [HttpDelete]
        public void DeleteCustome(int id)
        {
            var customerDB = _dbContext.Customers.SingleOrDefault(p => p.Id == id);
            if (customerDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _dbContext.Customers.Remove(customerDB);
            _dbContext.SaveChanges();
        }
    }
}
