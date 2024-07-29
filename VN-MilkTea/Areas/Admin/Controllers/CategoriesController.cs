using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VN_MilkTea.Models;

namespace VN_MilkTea.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Admin/Categories
        public ActionResult Index()
        {
            MilkTeaDBContext db = new MilkTeaDBContext();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}