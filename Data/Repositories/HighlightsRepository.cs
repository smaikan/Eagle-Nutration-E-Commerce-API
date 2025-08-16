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
    public class HighligtsRepository
    {
        private readonly AppDbContext _context;

        public HighligtsRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Highlights>> GetAllAsync()
        {
            return await _context.Highlights.Include(p => p.Product).ToListAsync();
        }

        public async Task<bool> AddAsync(int id)
        {
            
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return false; 

            
            var alreadyHighlighted = await _context.Highlights
                .AnyAsync(h => h.ProductId == id);

            if (alreadyHighlighted)
                return false;

            
            var highlight = new Highlights
            {
                ProductId = id
            };

            _context.Highlights.Add(highlight);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> RemoveAsync(int id)
        {
           
            var highlight = await _context.Highlights
                .FirstOrDefaultAsync(h => h.ProductId == id);

            if (highlight == null)
                return false; 

            _context.Highlights.Remove(highlight);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}