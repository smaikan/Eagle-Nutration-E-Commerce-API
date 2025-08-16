using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.UserDTOs;
using Core.Interfaces;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> LoginAsync(UserLoginDTO dto)
        {
            var users = await _userRepository.GetAllAsync();
            var user = users.FirstOrDefault(u => u.UserEmail == dto.UserEmail);
            if (user == null)
            {
                throw new Exception("Bu e-posta adresi ile kayıtlı bir kullanıcı bulunamadı.");
            }
            if (user.UserPassword != dto.Password)
            {
                throw new Exception("Şifre hatalı.");
            }
            var userDto = _mapper.Map<UserDTO>(user);
            return userDto;
        }


        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<User> CreateAsync(UserCreateDTO dto)
        {
            var user = _mapper.Map<User>(dto);
            user.Cart = new Cart
            {
                TotalPrice = 0,
                CartItems = new List<CartItem>()
            };
            return await _userRepository.CreateAsync(user);
        }
        public async Task<UpdateDTO> UpdateAsync(int id, UpdateDTO user)
        {
           
            return await _userRepository.UpdateAsync(id, user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            await _userRepository.DeleteAsync(user);
            return true;
        }
    }
}
