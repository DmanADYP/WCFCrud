using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CRUDWithJSONinWCF_Client.Models
{
    public class Product
    {
        [Display(Name ="ID")]
        public string ID { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
    }
}