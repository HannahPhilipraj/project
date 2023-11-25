using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Client.Models
{
    public class CustomerMVC
    {
        public int customer_id { get; set; }        
        public string customer_name { get; set; }
        public string email_id { get; set; }
        public long phone_no { get; set; }
        public string address { get; set; }
        public double account_balance { get; set; }
        public string password { get; set; }
    }
}