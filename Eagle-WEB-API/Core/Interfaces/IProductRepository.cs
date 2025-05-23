using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;

namespace Core.Interfaces
{
   
        public interface IProductRepository
        {
            Task<IEnumerable<Product>> GetAllAsync();
            Task<Product> GetByIdAsync(int id);
        Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);

        Task<Product> AddAsync(Product product);
            Task<bool> UpdateAsync(Product product);
            Task DeleteAsync(int id);
        }
    }

