using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        ETSDBEntities db = new ETSDBEntities();
        //Get
        public IEnumerable<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        //Get By Id
        public Customer Get(int Id)
        {
            return db.Customers.FirstOrDefault(x => x.CustomerId == Id);
        }

        //Put or Edit
        public IHttpActionResult Put([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok("Record Updated");
        }

        // Delete
        public IHttpActionResult Delete(int id)
        {
            Customer customer = db.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }
            db.Customers.Remove(customer);
            db.SaveChanges();
            return Ok("Deleted");
        }
    }
}
