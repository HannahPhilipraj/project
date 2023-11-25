using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class VendorController : ApiController
    {
        ETSDBEntities db = new ETSDBEntities();

        //Get
        public IEnumerable<Vendor> GetAll()
        {
            return db.Vendors.ToList();
        }

        //Get By Id
        public Vendor Get(int Id)
        {
            return db.Vendors.FirstOrDefault(x => x.VendorId == Id);
        }

        //Post
        public IHttpActionResult PostNewVendor([FromBody] Vendor v)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validations Failed");
            }
            db.Vendors.Add(new Vendor()
            {
                VendorId = v.VendorId,
                Name = v.Name,
                EmailId=v.EmailId,
                PhoneNo = v.PhoneNo,
                Address = v.Address
            });
            db.SaveChangesAsync();
            return Ok("Success");
        }

        //Put or Edit
        public IHttpActionResult Put([FromBody] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChangesAsync();
            }
            return Ok("Record Updated");
        }
        //Delete
        public IHttpActionResult Delete(int id)
        {
            Vendor vendor = db.Vendors.Find(id);

            if (vendor == null)
            {
                return NotFound();
            }
            db.Vendors.Remove(vendor);
            db.SaveChangesAsync();
            return Ok("Record Deleted");
        }
    }
}
