using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVC_Client.Models;
using Newtonsoft.Json;

namespace MVC_Client.Controllers
{
    public class VendorController : Controller
    {
        // GET: Vendor
        //[Authorize(Users ="Admin,Vendors")]
        public ActionResult Index()
        {
            IEnumerable<VendorMVC> vendorlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Vendor").Result;
            vendorlist = response.Content.ReadAsAsync<IEnumerable<VendorMVC>>().Result;
            return View(vendorlist);
        }
        //[Authorize(Users ="Admin")]
        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new VendorMVC());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Vendor/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<VendorMVC>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(VendorMVC vendor)
        {
            if (vendor.vendor_id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Vendor", vendor).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Vendor/" + vendor.vendor_id, vendor).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        //[Authorize(Users ="Admin")]
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Vendor/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }
    }
}
