using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Client.Models
{
    public class AdminMVC
    {
        public int admin_id { get; set; }
        [Required]
        public string admin_name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}