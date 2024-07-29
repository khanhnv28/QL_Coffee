using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VN_MilkTea.Models;

namespace VN_MilkTea.ApiControllers
{
    public class BrandController : ApiController
    {
        public List<Brand> GET()
        {
            MilkTeaDBContext db = new MilkTeaDBContext();
            List<Brand> brands = db.Brands.ToList();
            return brands;
        }
        public Brand GetBrandByBrandId(long id)
        {
            MilkTeaDBContext db = new MilkTeaDBContext();
            Brand exitingBrand = db.Brands.Where(t => t.BrandId == id).FirstOrDefault();
            return exitingBrand;
        }
    }
}
