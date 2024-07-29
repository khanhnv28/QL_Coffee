using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VN_MilkTea.Models
{
    public class Checkout
    {
        public Order Order { get; set; }

        public List<Product> Products { get; set; }
    }
}