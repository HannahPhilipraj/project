using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductController : ApiController
    {
        ETSDBEntities db = new ETSDBEntities();
        //Get
        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }

        //Get By Id
        public Product Get(int Id)
        {
            return db.Products.FirstOrDefault(x => x.ProductId == Id);
        }

        //Post
        public IHttpActionResult PostNewProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validations Failed");
            }
            db.Products.Add(new Product()
            {
                ProductId = product.ProductId,
                VendorId=product.VendorId,
                BrandName = product.BrandName,
                Price = product.Price,
                Availability = product.Availability
            });
            db.SaveChangesAsync();
            return Ok("Success");
        }

        //Put or Edit
        public IHttpActionResult Put([FromBody] Product p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChangesAsync();
            }
            return Ok("Record Updated");
        }
        //Delete
        public IHttpActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }
            db.Products.Remove(product);
            db.SaveChangesAsync();
            return Ok("Record Deleted");
        }
    }
}
