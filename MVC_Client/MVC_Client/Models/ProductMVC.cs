using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Client.Models
{
    public class ProductMVC
    {
        [DisplayName("Product ID")]
        public int product_id { get; set; }

        [DisplayName("Vendor ID")][Required]
        public int vendor_id { get; set; }

        [DisplayName("Brand Name")]
        [Required(ErrorMessage ="This field is required")]
        public string brand_name { get; set; }

        [DisplayName("Brand Price")]
        [Required]
        public double brand_price { get; set; }

        [Required]
        [DisplayName("Availability")]
        public bool availability { get; set; }
    }
}