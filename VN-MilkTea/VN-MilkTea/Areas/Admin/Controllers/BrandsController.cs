using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VN_MilkTea.Models;

namespace VN_MilkTea.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Admin/Brands
        public ActionResult Index()
        {
            MilkTeaDBContext db = new MilkTeaDBContext();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}