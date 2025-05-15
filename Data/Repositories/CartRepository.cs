using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Model;
using Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Cart> GetCartAsync(int id)
        {
            return await _context.Cart
        .Include(c => c.User)
        .Include(c => c.Products)
        .FirstOrDefaultAsync(c => c.CartId == id);
        }

        public async Task<bool> AddCartProductAsync(int id,int UserId)
        {
            
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return false; 
            
            var cart = new Cart
            {
                UserId = UserId,
                Products = new List<Product> { product }
            };

            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> RemoveCartProductAsync(int id, int CartId)
        {
            var cart = _context.Cart
     .Include(c => c.Products)
     .FirstOrDefault(c => c.CartId == CartId);

            if (cart != null)
            {
                
                var productToRemove = cart.Products.FirstOrDefault(p => p.ProductId == id);
                if (productToRemove != null)
                {
                    cart.Products.Remove(productToRemove);
                    _context.SaveChanges(); 
                }
            }

                return true;
        }

    }
}