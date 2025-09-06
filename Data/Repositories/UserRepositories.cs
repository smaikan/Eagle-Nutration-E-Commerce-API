using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.UserDTOs;
using Core.Interfaces;
using Core.Model;
using Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task<User?> CreateAsync(User user)
        {
            await _context.User.AddAsync(user);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<UpdateDTO?> UpdateAsync(int id, UpdateDTO updatedUser)
        {
            var existingUser = await GetByIdAsync(id);
            if (existingUser == null)
            { return null; }

            existingUser.UserName = updatedUser.UserName;
            existingUser.UserEmail = updatedUser.UserEmail;
            existingUser.UserPhone = updatedUser.UserPhone;
            existingUser.UserPassword = updatedUser.Password;
            if (updatedUser.UserAddress != null)
            {
                if (existingUser.UserAddress == null)
                    existingUser.UserAddress = new Address();

                existingUser.UserAddress.Province = updatedUser.UserAddress.Province;
                existingUser.UserAddress.District = updatedUser.UserAddress.District;
                existingUser.UserAddress.Neighbor = updatedUser.UserAddress.Neighbor;
                existingUser.UserAddress.Addressc = updatedUser.UserAddress.Address;

            }
            else
            {

                existingUser.UserAddress = null;
            }
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return updatedUser;
            }
            else
            {
                return null;
            }
        }

        public async Task DeleteAsync(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateRole(int id, string role)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null) return false;
            user.Role = role;
            await _context.SaveChangesAsync();
            return true;
        }

    }

}
