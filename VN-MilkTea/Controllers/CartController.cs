using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VN_MilkTea.Models;


namespace VN_MilkTea.Controllers
{
	
	public class CartController : Controller
    {
		MilkTeaDBContext db = new MilkTeaDBContext();
		// GET: Cart
		private Cart cart = new Cart();
		public ActionResult Index()
		{
			Cart cart = Session["Cart"] as Cart;
			if (cart == null)
			{
				cart = new Cart();
				Session["Cart"] = cart;
			}
			return View(cart);
		}
		
		public ActionResult AddToCart(int productId)
		{

            Product product = db.Products.Find(productId);
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            if (product != null)
            {
                Cart cart = Session["Cart"] as Cart;
                if (cart == null)
                {
                    cart = new Cart();
                }
                CartItem existingItem = cart.Items.FirstOrDefault(item => item.ProductId == productId);

                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    cart.Items.Add(new CartItem
                    {
                        ProductId = productId,
                        ProductName = product.ProductName,
                        Image = product.Image,
                        Price = (decimal)product.Price,
                        Quantity = 1
                    });
                    Session["count"] = Convert.ToInt32(Session["count"])+1;
                }
                Session["Cart"] = cart;
				return Json(new { success = true, cartItemCount = cart.Items.Count });

			}
			return Json(new { success = false, message = "Product not found" });
		}
		public ActionResult RemoveCartItem(int productId)
		{
			Cart cart = Session["Cart"] as Cart;

			if (cart != null)
			{
				CartItem itemToRemove = cart.Items.FirstOrDefault(item => item.ProductId == productId);

				if (itemToRemove != null)
				{
					cart.Items.Remove(itemToRemove);
					Session["count"] = Convert.ToInt32(Session["count"]) - 1;
				}

				Session["Cart"] = cart;
				return Json(new { success = true, cartItemCount = cart.Items.Count });
			}

			return Json(new { success = false, message = "Product not found" });
		}

        public ActionResult Checkout()
        {
            Cart cart = Session["Cart"] as Cart;

            if (cart == null || cart.Items.Count == 0)
            {
                // Nếu giỏ hàng rỗng, in ra thông báo và chuyển hướng về trang chủ
                ViewBag.Message = "Giỏ hàng của bạn đang trống.";
                return RedirectToAction("Index", "Home");
            }
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                // Tạo một đơn hàng mới để lưu thông tin đơn hàng
                Order order = new Order
                {
                    OrderDate = DateTime.Now,
                    OrderStatus = 1, // Đặt trạng thái đơn hàng theo yêu cầu của bạn
                    TotalAmount = cart.Items.Sum(item => item.Price * item.Quantity),
                    UserId = 1, // Thay thế bằng UserID của người dùng thực tế
                };

                // Thêm sản phẩm đã thanh toán vào danh sách sản phẩm
                List<Product> products = new List<Product>();
                foreach (var item in cart.Items)
                {
                    products.Add(new Product
                    {
                        ProductName = item.ProductName,
                        Image = item.Image,

                        // Thêm các thông tin sản phẩm cần thiết
                    });
                }

                // Tạo mô hình Checkout và gán Order và Products vào đó
                Checkout checkout = new Checkout
                {
                    Order = order,
                    Products = products
                };
                Session["count"] = null;
                // Xóa giỏ hàng sau khi thanh toán
                Session["Cart"] = null;

                // Chuyển đến trang Checkout và truyền thông tin về đơn hàng và sản phẩm
                return View("Checkout", checkout);
            }
        }

        public ActionResult Wishlist()
        {
            Wishlist wishlist = Session["Wishlist"] as Wishlist;
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            if (wishlist != null)
            {
                return PartialView("_WishlistPartial", wishlist.Items);
            }

            // Trả về danh sách trống nếu không có sản phẩm trong danh sách yêu thích
            return PartialView("_WishlistPartial", new List<WishlistItem>());
        }

        public ActionResult AddToWishlist(int productId)
        {
            Product product = db.Products.Find(productId);
            
            if (product != null)
            {
                Wishlist wishlist = Session["Wishlist"] as Wishlist;

                if (wishlist == null)
                {
                    wishlist = new Wishlist();
                }

                WishlistItem existingItem = wishlist.Items.FirstOrDefault(item => item.ProductId == productId);

                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    wishlist.Items.Add(new WishlistItem
                    {
                        ProductId = productId,
                        ProductName = product.ProductName,
                        Image = product.Image,
                        Price = (decimal)product.Price,
                        Quantity = 1
                    });
                }

                Session["Wishlist"] = wishlist;
                return Json(new { success = true, wishlistItemCount = wishlist.Items.Count });
            }

            return Json(new { success = false, message = "Không tìm thấy sản phẩm" });
        }

        public ActionResult RemoveFromWishlist(int productId)
        {
            Wishlist wishlist = Session["Wishlist"] as Wishlist;

            if (wishlist != null)
            {
                WishlistItem existingItem = wishlist.Items.FirstOrDefault(item => item.ProductId == productId);

                if (existingItem != null)
                {
                    wishlist.Items.Remove(existingItem);
                    
                }
                Session["Wishlist"] = wishlist;
                return Json(new { success = true, wishlistItemCount = wishlist.Items.Count });
            }

            return Json(new { success = false, message = "Không tìm thấy sản phẩm trong danh sách yêu thích" });
        }

    }
}