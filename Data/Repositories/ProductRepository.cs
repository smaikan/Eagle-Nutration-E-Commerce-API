using Core.Interfaces;
using Core.Model;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }


        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
        }
        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _context.Products

                .Where(p => p.ProductCategoryId == categoryId).Include(p => p.Category)
                .ToListAsync();
        }


        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA:");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }


            return product;
        }


        public async Task<bool> UpdateAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            _context.Products.Update(product);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }


        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> DecreaseStock(int id, int piece)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return false;

            if (product.Stock < piece)
                return false;

            product.Stock -= piece;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
