using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AccountsController : ApiController
    {
        ETSDBEntities db = new ETSDBEntities();

        public IHttpActionResult Login(Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Customers.SingleOrDefault(a => a.Name == admin.AdminName && a.Password == admin.Password);
                return Ok("Login successful");
            }
            return BadRequest("Invalid username or password");
        }
        [HttpPost]
        public IHttpActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var newcustomer = new Customer
                {
                    Name=customer.Name,
                    EmailId=customer.EmailId,
                    PhoneNo=customer.PhoneNo,
                    Address=customer.Address,
                    AccountBalance=customer.AccountBalance,
                    Password=customer.Password
                };
                db.Customers.Add(newcustomer);
                db.SaveChangesAsync();
                return Ok("Registration successful");
            }
            return BadRequest("Invalid data Registration");
        }
        public IHttpActionResult Login(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.SingleOrDefault(c => c.Name == customer.Name && c.Password == customer.Password);
                return Ok("Login successful");
            }
            return BadRequest("Invalid username or password");
        }
        [HttpPost]
        public IHttpActionResult Register(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                var newvendor = new Vendor
                {
                    Name = vendor.Name,
                    EmailId = vendor.EmailId,
                    PhoneNo = vendor.PhoneNo,
                    Address = vendor.Address,
                    Password = vendor.Password
                };
                db.Vendors.Add(newvendor);
                db.SaveChangesAsync();
                return Ok("Registration successful");
            }
            return BadRequest("Invalid data Registration");
        }
        public IHttpActionResult Login(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Customers.SingleOrDefault(v => v.Name == vendor.Name && v.Password == vendor.Password);
                return Ok("Login successful");
            }
            return BadRequest("Invalid username or password");
        }
    }
}
