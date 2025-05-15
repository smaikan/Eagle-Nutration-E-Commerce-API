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

        public async Task<bool> CreateAsync(User user)
        {
            await _context.User.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task DeleteAsync(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

}
