using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Client.Models
{
    public class ProductMVC
    {
        public int product_id { get; set; }
        public int vendor_id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string brand_name { get; set; }
        public double brand_price { get; set; }
        public bool availability { get; set; }
    }
}