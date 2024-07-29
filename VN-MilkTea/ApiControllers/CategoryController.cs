using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VN_MilkTea.Models;

namespace VN_MilkTea.ApiControllers
{
    public class CategoryController : ApiController
    {
        public List<Category> GET()
        {
            MilkTeaDBContext db = new MilkTeaDBContext();
            List<Category> categories = db.Categories.ToList();
            return categories;
        }
        public Category GetCategoryByCategoryId(long id)
        {
            MilkTeaDBContext db = new MilkTeaDBContext();
            Category exitingCategory = db.Categories.Where(t => t.CategoryId == id).FirstOrDefault();
            return exitingCategory;
        }
    }
}
