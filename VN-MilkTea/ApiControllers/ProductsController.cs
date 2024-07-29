using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using VN_MilkTea.Models;

namespace VN_MilkTea.ApiControllers
{
    public class ProductsController : ApiController
    {
        public List<Product> get()
        {
            MilkTeaDBContext db = new MilkTeaDBContext();
            var productsData = db.Products.Select(p => new
            {
                p.ProductId,
                p.ProductName,
                p.Price,
                p.Image,
                p.Brand,
                p.Category,
            }).ToList();
            List<Product> products = productsData.Select(p => new Product()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.Price,
                Image = p.Image,
                Brand = p.Brand,
                Category = p.Category,
            }).ToList();

            return products;
        }
        public class ProductDTO
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public double Price { get; set; }
            public string Image { get; set; }
            public string Brand { get; set; }
            public string Category { get; set; }
        }
        public List<ProductDTO> GetProducts(int id)
        {
            MilkTeaDBContext db = new MilkTeaDBContext();
            return (from p in db.Products
                    where p.ProductId == id
                    select new ProductDTO
                    {
                        ProductId = (int)p.ProductId,
                        ProductName = p.ProductName,
                        Price = (double)p.Price,
                        Image = p.Image,
                        Brand = p.Brand.BrandName,
                        Category = p.Category.CategoryName,
                    }).ToList();
        }
        public List<ProductDTO> ProductsByCategory(int categoryId)
        {
            MilkTeaDBContext db = new MilkTeaDBContext();
            return (from p in db.Products
                    where p.CategoryId == categoryId
                    select new ProductDTO
                    {
                        ProductId = (int)p.ProductId,
                        ProductName = p.ProductName,
                        Price = (double)p.Price,
                        Image = p.Image,
                        Brand = p.Brand.BrandName,
                        Category = p.Category.CategoryName,
                    }).ToList();
        }
    }
}
