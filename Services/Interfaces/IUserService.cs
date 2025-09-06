using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.UserDTOs;
using Core.Model;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO?> GetByIdAsync(int id);
        Task<UserDTO> LoginAsync(UserLoginDTO dto);
        Task<User> CreateAsync(UserCreateDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<UpdateDTO?> UpdateAsync(int id, UpdateDTO user);
        Task<bool> UpdateRole(int id, string role);
    }
}
