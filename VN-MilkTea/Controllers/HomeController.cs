using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VN_MilkTea.Models;

namespace VN_MilkTea.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        MilkTeaDBContext db = new MilkTeaDBContext();
		public ActionResult Index(string search = "", int PageNo = 1)
		{
			ViewBag.Search = search;
			List<Product> products = db.Products.Where(t => t.ProductName.Contains(search)).ToList();
			int NoOfRecordsPerPage = 12;
			int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
			int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
			ViewBag.PageNo = PageNo;
			ViewBag.NoOfPage = NoOfPages;
			products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
			ViewBag.Brands = db.Brands.ToList();
			return View(products);
		}
		public ActionResult ShowProduct(string search = "", int PageNo = 1)
        {
			ViewBag.Search = search;
			List<Product> products = db.Products.Where(t => t.ProductName.Contains(search)).ToList();
			int NoOfRecordsPerPage = 12;
			int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
			int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
			ViewBag.PageNo = PageNo;
			ViewBag.NoOfPage = NoOfPages;
			products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
			ViewBag.Brands = db.Brands.ToList();
			return View(products);
		}
		public ActionResult Details(long id)
		{
			ViewBag.products = db.Products.ToList();
			ViewBag.Brands = db.Brands.ToList();
			Product p = db.Products.Where(t => t.ProductId == id).FirstOrDefault();
			return View(p);
		}
		public ActionResult GetProductAjax()
        {
			return View();
        }
		public ActionResult Search()
		{
			return View();
		}
		public ActionResult GetBrand()
		{
			MilkTeaDBContext db = new MilkTeaDBContext();
			List<Brand> brands = db.Brands.ToList();
			return View(brands);
		}
		public ActionResult GetCategory()
		{
			MilkTeaDBContext db = new MilkTeaDBContext();
			List<Category> categories = db.Categories.ToList();
			return View(categories);
		}
		public ActionResult ProductCategory(string search = "", int PageNo = 1)
        {
			ViewBag.Search = search;
			List<Product> products = db.Products.Where(t => t.ProductName.Contains(search)).ToList();
			int NoOfRecordsPerPage = 12;
			int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
			int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
			ViewBag.PageNo = PageNo;
			ViewBag.NoOfPage = NoOfPages;
			products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
			ViewBag.Brands = db.Brands.ToList();
			return View(products);
        }
	}
}