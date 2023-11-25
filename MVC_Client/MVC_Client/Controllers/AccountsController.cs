using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using MVC_Client.Models;

namespace MVC_Client.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(CustomerMVC customer)
        {
            using (HttpClient client = new HttpClient())
            {
                if (!ModelState.IsValid)
                {
                    return View(customer);
                }
                client.BaseAddress = new Uri("https://localhost:44336/api");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("api/Customer", customer).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Registration successful, you can redirect to a success page or login
                    ViewBag.result = "Registration successfull";
                    return RedirectToAction("Login");
                }
                else
                {
                    // Registration failed, handle errors
                    ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                    return View(customer);
                }
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CustomerMVC loginCustomer)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44336/api/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // Build the login URL with parameters
                string loginUrl = $"Customer/Login?customername={loginCustomer.customer_name}&password={loginCustomer.password}";
                HttpResponseMessage response = client.GetAsync(loginUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    var responseData = response.Content.ReadAsAsync<dynamic>().Result;
                    int customerId = responseData.CustomerId;
                    string fullName = responseData.FullName;
                    // You can use these values as needed, for example, set them in session
                    Session["CustomerId"] = customerId;
                    // Login successful
                    return RedirectToAction("Index", "Home"); // Redirect to your dashboard or another secure area
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login failed. Please check your credentials and try again.");
                    return View();
                }
            }
        }

        public ActionResult Signout()
        {
            Session["CustomerId"] = null;
            //FormsAuthentication.SignOut();
            //return RedirectToAction("Login");
            return View();
        }
    }
}