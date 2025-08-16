using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Model;

namespace Core.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCartAsync(int id);
        Task<bool> AddCartProductAsync(int id, int UserId, string saroma);
        Task<bool> RemoveCartProductAsync(int id, int CartId, string saroma);
        Task<bool> decreaseCartProductAsync(int id, int CartId, string saroma);
        
    }
}