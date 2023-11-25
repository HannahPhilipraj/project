using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC_Client.Models
{
    public class VendorMVC
    {
        [DisplayName("Vendor ID")]
        public int vendor_id { get; set; }
        [DisplayName("Vendor Name")]
        public string vendor_name { get; set; }
        public string email_id { get; set; }
        [DisplayName("Phone no")]
        public long phone_no { get; set; }
        public string address { get; set; }
        public string password { get; set; }
    }
}