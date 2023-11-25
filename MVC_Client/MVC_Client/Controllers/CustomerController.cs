using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Client.Models;
using System.Threading.Tasks;
using System.Net.Http;

namespace MVC_Client.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        //[Authorize(Users ="Admin")]
        public ActionResult Index()
        {
            IEnumerable<CustomerMVC> customerlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customer").Result;
            customerlist = response.Content.ReadAsAsync<IEnumerable<CustomerMVC>>().Result;
            return View(customerlist);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
             HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customer/" + id.ToString()).Result;
             return View(response.Content.ReadAsAsync<CustomerMVC>().Result);          
        }

        [HttpPost]
        public ActionResult Edit(CustomerMVC customer)
        {
              HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Customer/" + customer.customer_id, customer).Result;
              return RedirectToAction("Index");            
        }
        //[Authorize(Users ="Admin")]
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Customer/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
        [Authorize(Users ="Customer")]
        public string BuyProduct(ProductMVC productprice)
        {
            CustomerMVC balance=new CustomerMVC();
            if (balance.account_balance >= productprice.brand_price)
            {
                // User has enough money, deduct the product price from account balance
                balance.account_balance -= productprice.brand_price;
                return "Thank you for shopping";
            }
            else
            {
                // Insufficient funds in the account
                return "Please update your account balance";
            }
        }
    }
}