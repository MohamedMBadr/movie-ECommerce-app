using eTickets.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string shoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>() ? .HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string cardID = session.GetString("cardID") ?? Guid.NewGuid().ToString();
            session.SetString("cardID", cardID);
            return new ShoppingCart(context)
            {
                shoppingCartId = cardID
            };
        }

        public void AddMovieToCart(Movie movie)
        {
            var shopingcartItem = _context.shoppingCartItems.FirstOrDefault(n => n.movie.Id == movie.Id && n.ShoppingCartId == shoppingCartId);

            if (shopingcartItem is null)
            {
                shopingcartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = shoppingCartId,
                    movie = movie,
                    Amount = 1
                };

                _context.shoppingCartItems.Add(shopingcartItem);
            }
            else
            {
                shopingcartItem.Amount++;
            }

            _context.SaveChanges();
        }


        public void removeItemFromCart(Movie movie)
        {
            var shopingcartItem = _context.shoppingCartItems.FirstOrDefault(n => n.movie.Id == movie.Id && n.ShoppingCartId == shoppingCartId);

            if (shopingcartItem is not null)
            {


                if (shopingcartItem.Amount > 1)
                    shopingcartItem.Amount--;
                else
                    _context.shoppingCartItems.Remove(shopingcartItem);
            }
            
      
            _context.SaveChanges();

        }

        public List<ShoppingCartItem> GetShoppingCartItems() =>
            ShoppingCartItems ?? (ShoppingCartItems = _context.shoppingCartItems.Where(n => n.ShoppingCartId == shoppingCartId)
                .Include(n => n.movie).ToList());


        public double GetShoppingCartTotal() =>
            _context.shoppingCartItems.Where(n => n.ShoppingCartId == shoppingCartId)
                                .Select(n => n.movie.Price * n.Amount).Sum();


        public async Task clearShoppingCartAsync()
        {
            var itemes = await _context.shoppingCartItems.Where(n => n.ShoppingCartId == shoppingCartId).ToListAsync();

            _context.shoppingCartItems.RemoveRange(itemes);
            await _context.SaveChangesAsync();
            ShoppingCartItems = new List<ShoppingCartItem>();
                            

        }


    }
}
