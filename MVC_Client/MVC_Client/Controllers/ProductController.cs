using MVC_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC_Client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<ProductMVC> productlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product").Result;
            productlist = response.Content.ReadAsAsync<IEnumerable<ProductMVC>>().Result;
            return View(productlist);
        }

        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new ProductMVC());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<ProductMVC>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(ProductMVC product)
        {
            if (product.product_id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Product", product).Result;
                return RedirectToAction("Index");
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Product/" + product.product_id, product).Result;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Product/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}