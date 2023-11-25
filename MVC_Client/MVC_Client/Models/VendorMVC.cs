using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Client.Models
{
    public class VendorMVC
    {
        [DisplayName("Vendor ID")]
        public int vendor_id { get; set; }

        [DisplayName("Vendor Name")][Required]
        public string vendor_name { get; set; }

        [DisplayName("Email ID")][Required]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
             ErrorMessage = "Enter Email In correct Format)")]
        [DataType(DataType.EmailAddress)]
        public string email_id { get; set; }

        [DisplayName("Phone no")][Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must contain only digits")]
        public long phone_no { get; set; }

        [DisplayName("Address")][Required]
        public string address { get; set; }

        [Required][DataType(DataType.Password)]
        public string password { get; set; }
    }
}