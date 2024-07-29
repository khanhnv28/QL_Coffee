using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VN_MilkTea.Models
{
    public class ProductModel
    {
        public List<Brand> Brands { get; set; }
        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }
    }
}