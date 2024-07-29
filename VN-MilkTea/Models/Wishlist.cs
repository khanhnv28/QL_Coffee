using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VN_MilkTea.Models
{
    public class Wishlist
    {
        public List<WishlistItem> Items { get; set; }
        public Wishlist()
        {
            Items = new List<WishlistItem>();
        }
    }
    public class WishlistItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}