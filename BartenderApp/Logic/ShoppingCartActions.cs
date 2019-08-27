using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BartenderApp.Models;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace BartenderApp.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }

        private BartenderAppContext _db =  new BartenderAppContext();

        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {
            // Retrieve the product from the database.           
            //ShoppingCartId = GetCartId();

            var cartItem = _db.Orders.SingleOrDefault(
                c => c.OrderId == ShoppingCartId
                && c.ProductId == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new Orders
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    OrderId = ShoppingCartId,
                    //Product = _db.Products.SingleOrDefault(
                   //p => p.ProductID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                _db.Orders.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity++;
            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        //public string GetCartId()
        //{
        //    if (HttpContext.Session[CartSessionKey] == null)
        //    {
        //        if (!string.IsNullOrWhiteSpace(HttpContext.User.Identity.Name))
        //        {
        //            HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
        //        }
        //        else
        //        {
        //            // Generate a new random GUID using System.Guid class.     
        //            Guid tempCartId = Guid.NewGuid();
        //            HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
        //        }
        //    }
        //    return HttpContext.Current.Session[CartSessionKey].ToString();
        //}

        public List<Orders> GetCartItems()
        {
            //ShoppingCartId = GetCartId();

            return _db.Orders.Where(
                c => c.OrderId == ShoppingCartId).ToList();
        }
    }
}
