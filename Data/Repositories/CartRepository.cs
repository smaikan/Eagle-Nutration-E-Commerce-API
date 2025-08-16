using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Model;
using Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cart?> GetCartAsync(int userId)
        {
            return await _context.Cart
                .Include(c => c.User)
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Products)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<bool> AddCartProductAsync(int productId, int userId, string? saroma="")
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
                return false;

            var existingCart = await _context.Cart
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.UserId == userId);

            var existingItem = existingCart?.CartItems
            .FirstOrDefault(ci => ci.ProductId == productId &&
            ci.aroma == saroma);
            if (existingItem != null)
                existingItem.Quantity += 1;
            else
                existingCart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = 1,
                    UnitPrice = product.ProductPrice,
                    aroma = saroma
                });


            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveCartProductAsync(int productId, int userId, string? saroma = "")
        {
            var cart = await _context.Cart
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
                return false;

            var productToRemove = cart.CartItems.FirstOrDefault(p => p.ProductId == productId &&
            p.aroma == saroma);

            if (productToRemove == null)
                return false;

            cart.CartItems.Remove(productToRemove);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> decreaseCartProductAsync(int productId, int userId, string? saroma ="")
        {
            var cart = await _context.Cart
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
                return false;

 var productToRemove = cart.CartItems.FirstOrDefault(p => p.ProductId == productId &&
            p.aroma.OrderBy(a => a).SequenceEqual(saroma.OrderBy(a => a)));
            
            if (productToRemove.Quantity <= 1)
            {
                cart.CartItems.Remove(productToRemove);
            }
            else
            {
                productToRemove.Quantity -= 1;
            }

           
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
