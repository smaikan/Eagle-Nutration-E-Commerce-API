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
        Task<bool> AddCartProductAsync(int id, int UserId);
        Task<bool> RemoveCartProductAsync(int id, int CartId);
    }
}