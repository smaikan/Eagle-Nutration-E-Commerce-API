using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.UserDTOs;
using Core.Model;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> CreateAsync(User user);
        Task DeleteAsync(User user);
        Task<UpdateDTO?> UpdateAsync(int id, UpdateDTO user);
    }
}
