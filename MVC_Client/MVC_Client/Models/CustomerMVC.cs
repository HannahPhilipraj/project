using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Client.Models
{
    public class CustomerMVC
    {
        [DisplayName("Customer ID")]
        public int customer_id { get; set; }

        [DisplayName("Customer Name")][Required]
        public string customer_name { get; set; }

        [DisplayName("Email ID")][Required]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
             ErrorMessage ="Enter Email In correct Format)")]
        [DataType(DataType.EmailAddress)]
        public string email_id { get; set; }

        [DisplayName("Phone no.")][Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must contain only digits")]        
        public Nullable<long> phone_no { get; set; }

        [DisplayName("Address")][Required]
        public string address { get; set; }

        [DisplayName("Account Balance")][Required]
        public Nullable<double> account_balance { get; set; }

        [DataType(DataType.Password)][Required]
        public string password { get; set; }
    }
}