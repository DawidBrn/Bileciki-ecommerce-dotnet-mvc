using Bileciki_ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bileciki_ecommerce.Data.ShoppingCart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };

        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            if (ShoppingCartItems == null)
                return ShoppingCartItems = _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).Include(x => x.Movie).ToList();
            return ShoppingCartItems;
            
        }
        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId).
                Select(x => x.Movie.Price * x.Amount).Sum();
            return total;
        }
        public void AddItem(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault( x => x.Movie.Id == movie.Id 
            && x.ShoppingCartId == ShoppingCartId);
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
                
            }
            else
            {
                shoppingCartItem.Amount += 1;
            }
            _context.SaveChanges();
        }
        public void RemoveItem(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.Movie.Id == movie.Id
           && x.ShoppingCartId == ShoppingCartId);
            
            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                    shoppingCartItem.Amount -= 1;

            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
            _context.SaveChanges();
        }
    }
}
